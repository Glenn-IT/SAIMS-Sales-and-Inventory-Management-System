Public Class SalesForm

    ' Tracks ProductID and unit price for each barcode added to the cart
    Private _cartItems As New Dictionary(Of String, (ProductID As Integer, UnitPrice As Decimal))

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPaymentMethod.SelectedIndex = 0
        txtBarcodeScanner.Focus()
        UpdateTransactionSummary()
    End Sub

    ' ─── Barcode scanning ───────────────────────────────────────────────────────

    Private Sub txtBarcodeScanner_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcodeScanner.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            ProcessBarcodeInput()
        End If
    End Sub

    Private Sub ProcessBarcodeInput()
        Dim barcode As String = InputHelper.SanitizeInput(txtBarcodeScanner.Text).ToUpper()
        If String.IsNullOrWhiteSpace(barcode) Then Return
        LookupAndAddProduct(barcode)
        txtBarcodeScanner.Clear()
        txtBarcodeScanner.Focus()
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Using dlg As New SalesItemDialogForm()
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return
            If String.IsNullOrWhiteSpace(dlg.SelectedBarcode) Then Return
            LookupAndAddProduct(dlg.SelectedBarcode, dlg.SelectedQuantity)
        End Using
    End Sub

    Private Sub LookupAndAddProduct(barcode As String, Optional quantityToAdd As Integer = 1)
        Try
            Dim dt As DataTable = ProductRepository.GetByBarcode(barcode)

            If dt.Rows.Count = 0 Then
                MessageBox.Show($"Product with barcode '{barcode}' not found or is inactive.",
                                "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row         As DataRow = dt.Rows(0)
            Dim productID   As Integer = CInt(row("ProductID"))
            Dim productName As String  = row("ProductName").ToString()
            Dim price       As Decimal = CDec(row("Price"))
            Dim stock       As Integer = CInt(row("Stock"))

            ' Count how many are already in the cart
            Dim alreadyInCart As Integer = 0
            For Each gr As DataGridViewRow In dgvCart.Rows
                If gr.IsNewRow Then Continue For
                If gr.Cells("colBarcode").Value.ToString() = barcode Then
                    alreadyInCart = CInt(gr.Cells("colQuantity").Value)
                    Exit For
                End If
            Next

            If stock - (alreadyInCart + quantityToAdd) < 0 Then
                MessageBox.Show($"Not enough stock for '{productName}'. Available: {stock - alreadyInCart}",
                                "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            AddItemToCart(barcode, productID, productName, price, quantityToAdd)

        Catch ex As Exception
            MessageBox.Show("Failed to look up product." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddItemToCart(barcode As String, productID As Integer,
                               productName As String, price As Decimal,
                               Optional quantityToAdd As Integer = 1)
        If Not _cartItems.ContainsKey(barcode) Then
            _cartItems(barcode) = (productID, price)
        End If

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.IsNewRow Then Continue For
            If row.Cells("colBarcode").Value.ToString() = barcode Then
                Dim newQty As Integer = CInt(row.Cells("colQuantity").Value) + quantityToAdd
                row.Cells("colQuantity").Value = newQty
                row.Cells("colTotal").Value    = FormatCurrency(newQty * price)
                UpdateTransactionSummary()
                Return
            End If
        Next

        dgvCart.Rows.Add(barcode, productName, FormatCurrency(price), quantityToAdd, FormatCurrency(quantityToAdd * price))
        UpdateTransactionSummary()
    End Sub

    ' ─── Cart management ────────────────────────────────────────────────────────

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to remove.", "Remove Item",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim barcode As String = dgvCart.SelectedRows(0).Cells("colBarcode").Value.ToString()
        dgvCart.Rows.Remove(dgvCart.SelectedRows(0))
        _cartItems.Remove(barcode)
        UpdateTransactionSummary()
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        Dim result = MessageBox.Show("Clear all items from cart?", "Clear Cart",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then ClearCart()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result = MessageBox.Show("Cancel this transaction?", "Cancel",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then ClearCart()
    End Sub

    Private Sub ClearCart()
        dgvCart.Rows.Clear()
        _cartItems.Clear()
        txtBarcodeScanner.Clear()
        txtDiscount.Text       = "0"
        txtAmountTendered.Text = "0"
        UpdateTransactionSummary()
        txtBarcodeScanner.Focus()
    End Sub

    ' ─── Transaction summary ────────────────────────────────────────────────────

    Private _updatingSummary As Boolean = False

    Private Sub UpdateTransactionSummary()
        If _updatingSummary Then Return
        _updatingSummary = True

        Dim subTotal  As Decimal = 0
        Dim itemCount As Integer = 0

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.IsNewRow Then Continue For
            Dim lineText As String = row.Cells("colTotal").Value?.ToString() _
                                        .Replace("₱", "").Replace(",", "")
            Dim lineAmt As Decimal
            If Decimal.TryParse(lineText, lineAmt) Then subTotal += lineAmt
            itemCount += 1
        Next

        txtTotalItems.Text = itemCount.ToString()
        txtSubtotal.Text   = FormatCurrency(subTotal)

        Dim discount As Decimal = 0
        Decimal.TryParse(txtDiscount.Text, discount)
        If discount < 0 Then
            discount = 0
            txtDiscount.Text = "0"
        ElseIf discount > subTotal Then
            discount = subTotal
            txtDiscount.Text = subTotal.ToString("F2")
        End If

        Dim finalTotal As Decimal = subTotal - discount
        txtTotalAmount.Text = FormatCurrency(finalTotal)

        _updatingSummary = False
        CalculateChange()
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        UpdateTransactionSummary()
    End Sub

    Private Sub txtAmountTendered_TextChanged(sender As Object, e As EventArgs) Handles txtAmountTendered.TextChanged
        CalculateChange()
    End Sub

    Private Sub CalculateChange()
        Dim tendered As Decimal = 0
        Decimal.TryParse(txtAmountTendered.Text, tendered)

        Dim total As Decimal = 0
        Decimal.TryParse(txtTotalAmount.Text.Replace("₱", "").Replace(",", ""), total)

        Dim change As Decimal = tendered - total
        txtChange.Text      = FormatCurrency(change)
        txtChange.ForeColor = If(change < 0, Color.Red, Color.Black)
    End Sub

    Private Function FormatCurrency(amount As Decimal) As String
        Return "₱" & amount.ToString("N2")
    End Function

    ' ─── Inline quantity editing ─────────────────────────────────────────────────

    Private Sub dgvCart_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellEndEdit
        If e.ColumnIndex <> dgvCart.Columns("colQuantity").Index Then Return

        Dim row As DataGridViewRow = dgvCart.Rows(e.RowIndex)
        Dim qty As Integer
        If Not Integer.TryParse(row.Cells("colQuantity").Value?.ToString(), qty) OrElse qty <= 0 Then
            MessageBox.Show("Quantity must be a positive number.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            row.Cells("colQuantity").Value = 1
            qty = 1
        End If

        Dim barcode As String  = row.Cells("colBarcode").Value.ToString()
        Dim price   As Decimal = If(_cartItems.ContainsKey(barcode), _cartItems(barcode).UnitPrice, 0D)
        row.Cells("colTotal").Value = FormatCurrency(qty * price)
        UpdateTransactionSummary()
    End Sub

    ' ─── Save & complete transaction ─────────────────────────────────────────────

    Private Sub btnSavePrint_Click(sender As Object, e As EventArgs) Handles btnSavePrint.Click
        Dim itemCount As Integer = dgvCart.Rows.Cast(Of DataGridViewRow)() _
                                              .Count(Function(r) Not r.IsNewRow)
        If itemCount = 0 Then
            MessageBox.Show("No items in cart.", "Save Transaction",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim subTotal As Decimal = 0
        Decimal.TryParse(txtSubtotal.Text.Replace("₱", "").Replace(",", ""), subTotal)

        Dim discount As Decimal = 0
        Decimal.TryParse(txtDiscount.Text, discount)
        If discount < 0 Then discount = 0

        Dim totalAmount As Decimal = 0
        Decimal.TryParse(txtTotalAmount.Text.Replace("₱", "").Replace(",", ""), totalAmount)

        Dim tendered As Decimal = 0
        Decimal.TryParse(txtAmountTendered.Text, tendered)

        If tendered < totalAmount Then
            MessageBox.Show("Amount tendered is less than the total amount.", "Insufficient Payment",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim change        As Decimal = tendered - totalAmount
        Dim paymentMethod As String  = cmbPaymentMethod.SelectedItem.ToString()
        Dim receiptNo     As String  = SalesRepository.GenerateReceiptNo()

        Try
            Dim saleID As Integer = SalesRepository.Insert(
                receiptNo, SessionManager.UserID,
                subTotal, discount, totalAmount,
                tendered, change, paymentMethod)

            For Each gridRow As DataGridViewRow In dgvCart.Rows
                If gridRow.IsNewRow Then Continue For

                Dim barcode   As String  = gridRow.Cells("colBarcode").Value.ToString()
                Dim qty       As Integer = CInt(gridRow.Cells("colQuantity").Value)
                Dim productID As Integer = _cartItems(barcode).ProductID
                Dim unitPrice As Decimal = _cartItems(barcode).UnitPrice
                Dim lineTotal As Decimal = qty * unitPrice

                SaleItemRepository.Insert(saleID, productID, qty, unitPrice, lineTotal)
                ProductRepository.DeductStock(productID, qty)
                StockMovementRepository.Insert(
                    productID, Constants.MOVEMENT_SALE, qty,
                    $"Sale: {receiptNo}", SessionManager.UserID)
            Next

            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Sale completed: {receiptNo} — Total: {FormatCurrency(totalAmount)}")

            MessageBox.Show($"Transaction saved successfully!" &
                            Environment.NewLine & Environment.NewLine &
                            $"Receipt No:  {receiptNo}" &
                            Environment.NewLine &
                            $"Total:       {FormatCurrency(totalAmount)}" &
                            Environment.NewLine &
                            $"Change:      {FormatCurrency(change)}",
                            "Sale Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearCart()

        Catch ex As Exception
            MessageBox.Show("Failed to save transaction." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
