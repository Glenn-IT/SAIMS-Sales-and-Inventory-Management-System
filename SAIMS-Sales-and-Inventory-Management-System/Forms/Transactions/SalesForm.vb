Public Class SalesForm

    ' Tracks ProductID, unit price, and available stock for each barcode added to the cart
    Private _cartItems As New Dictionary(Of String, (ProductID As Integer, UnitPrice As Decimal, Stock As Integer))

    ' Real-time product search debounce timer (150ms)
    Private WithEvents _searchDebounceTimer As New Timer() With {.Interval = 150}

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        cmbPaymentMethod.SelectedIndex = 0
        txtBarcodeScanner.Focus()
        UpdateTransactionSummary()
        UpdateSelectedCartItemDisplay()
    End Sub

    Private Sub SalesForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If lstSearchResults IsNot Nothing AndAlso lstSearchResults.Visible Then
            PositionSearchResultsDropdown()
        End If
    End Sub

    ' Hands-free scanner auto-focus: intercepts keypresses outside of payment/discount/quantity/search textboxes
    Private Sub SalesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not txtDiscount.Focused AndAlso Not txtAmountTendered.Focused AndAlso
           Not txtBarcodeScanner.Focused AndAlso Not txtItemQty.Focused AndAlso
           Not lstSearchResults.Focused Then
            If (e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z) OrElse
               (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) OrElse
               (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse
               e.KeyCode = Keys.Enter Then
                txtBarcodeScanner.Focus()
            End If
        End If
    End Sub

    ' ─── Barcode scanning & real-time product search ────────────────────────────

    Private Sub PositionSearchResultsDropdown()
        If lstSearchResults Is Nothing OrElse txtBarcodeScanner Is Nothing Then Return
        Dim screenPt As Point = txtBarcodeScanner.Parent.PointToScreen(New Point(txtBarcodeScanner.Left, txtBarcodeScanner.Bottom + 1))
        Dim clientPt As Point = Me.PointToClient(screenPt)
        lstSearchResults.Location = clientPt
        lstSearchResults.Width = Math.Max(txtBarcodeScanner.Width, 520)
        lstSearchResults.BringToFront()
    End Sub

    Private Sub txtBarcodeScanner_TextChanged(sender As Object, e As EventArgs) Handles txtBarcodeScanner.TextChanged
        Dim kw As String = txtBarcodeScanner.Text.Trim()
        If kw.Length >= 1 Then
            _searchDebounceTimer.Stop()
            _searchDebounceTimer.Start()
        Else
            _searchDebounceTimer.Stop()
            lstSearchResults.Visible = False
            lstSearchResults.Items.Clear()
        End If
    End Sub

    Private Sub _searchDebounceTimer_Tick(sender As Object, e As EventArgs) Handles _searchDebounceTimer.Tick
        _searchDebounceTimer.Stop()
        Dim kw As String = txtBarcodeScanner.Text.Trim()
        If kw.Length >= 1 Then
            Dim matches = ProductRepository.SearchActiveProducts(kw)
            DisplaySearchResults(matches)
        Else
            lstSearchResults.Visible = False
        End If
    End Sub

    Private Sub DisplaySearchResults(matches As List(Of ProductSearchResult))
        lstSearchResults.BeginUpdate()
        lstSearchResults.Items.Clear()
        For Each p In matches
            lstSearchResults.Items.Add(p)
        Next
        lstSearchResults.EndUpdate()

        If matches.Count > 0 Then
            PositionSearchResultsDropdown()
            lstSearchResults.Visible = True
            lstSearchResults.BringToFront()
        Else
            lstSearchResults.Visible = False
        End If
    End Sub

    Private Sub txtBarcodeScanner_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcodeScanner.KeyDown
        If e.KeyCode = Keys.Down Then
            If lstSearchResults.Visible AndAlso lstSearchResults.Items.Count > 0 Then
                e.Handled = True
                lstSearchResults.Focus()
                If lstSearchResults.SelectedIndex < 0 Then
                    lstSearchResults.SelectedIndex = 0
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            lstSearchResults.Visible = False
            e.Handled = True
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            ProcessSearchOrBarcodeInput()
        End If
    End Sub

    Private Sub txtBarcodeScanner_Leave(sender As Object, e As EventArgs) Handles txtBarcodeScanner.Leave
        Me.BeginInvoke(Sub()
                           If Not lstSearchResults.Focused Then
                               lstSearchResults.Visible = False
                           End If
                       End Sub)
    End Sub

    Private Sub lstSearchResults_Click(sender As Object, e As EventArgs) Handles lstSearchResults.Click
        SelectCurrentSearchResult()
    End Sub

    Private Sub lstSearchResults_KeyDown(sender As Object, e As KeyEventArgs) Handles lstSearchResults.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            SelectCurrentSearchResult()
        ElseIf e.KeyCode = Keys.Escape Then
            lstSearchResults.Visible = False
            txtBarcodeScanner.Focus()
            e.Handled = True
        ElseIf e.KeyCode = Keys.Up AndAlso lstSearchResults.SelectedIndex = 0 Then
            e.Handled = True
            txtBarcodeScanner.Focus()
            txtBarcodeScanner.SelectionStart = txtBarcodeScanner.Text.Length
        ElseIf (e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z) OrElse
               (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) OrElse
               (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse
               e.KeyCode = Keys.Back Then
            txtBarcodeScanner.Focus()
        End If
    End Sub

    Private Sub lstSearchResults_Leave(sender As Object, e As EventArgs) Handles lstSearchResults.Leave
        Me.BeginInvoke(Sub()
                           If Not txtBarcodeScanner.Focused Then
                               lstSearchResults.Visible = False
                           End If
                       End Sub)
    End Sub

    Private Sub SelectCurrentSearchResult()
        If lstSearchResults.SelectedIndex >= 0 Then
            Dim selected = TryCast(lstSearchResults.SelectedItem, ProductSearchResult)
            If selected IsNot Nothing Then
                AddProductAndReset(selected.Barcode)
            End If
        End If
    End Sub

    Private Sub ProcessSearchOrBarcodeInput()
        _searchDebounceTimer.Stop()
        Dim input As String = InputHelper.SanitizeInput(txtBarcodeScanner.Text).Trim()
        If String.IsNullOrWhiteSpace(input) Then Return

        ' 1. If an item in dropdown is explicitly highlighted, use it
        If lstSearchResults.Visible AndAlso lstSearchResults.SelectedIndex >= 0 Then
            Dim selected = TryCast(lstSearchResults.SelectedItem, ProductSearchResult)
            If selected IsNot Nothing Then
                AddProductAndReset(selected.Barcode)
                Return
            End If
        End If

        ' 2. Try exact barcode match first
        Dim dt As DataTable = ProductRepository.GetByBarcode(input)
        If dt.Rows.Count > 0 Then
            AddProductAndReset(input)
            Return
        End If

        ' 3. If dropdown has search results, pick top match
        If lstSearchResults.Visible AndAlso lstSearchResults.Items.Count > 0 Then
            Dim topResult = TryCast(lstSearchResults.Items(0), ProductSearchResult)
            If topResult IsNot Nothing Then
                AddProductAndReset(topResult.Barcode)
                Return
            End If
        End If

        ' 4. Direct search for matches
        Dim matches = ProductRepository.SearchActiveProducts(input)
        If matches.Count = 1 Then
            AddProductAndReset(matches(0).Barcode)
            Return
        ElseIf matches.Count > 1 Then
            DisplaySearchResults(matches)
            lstSearchResults.Focus()
            lstSearchResults.SelectedIndex = 0
            Return
        End If

        ' 5. Not found
        lstSearchResults.Visible = False
        System.Media.SystemSounds.Hand.Play()
        MessageBox.Show($"No active product found matching '{input}'.",
                        "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtBarcodeScanner.SelectAll()
        txtBarcodeScanner.Focus()
    End Sub

    Private Sub AddProductAndReset(barcode As String)
        lstSearchResults.Visible = False
        txtBarcodeScanner.Clear()
        LookupAndAddProduct(barcode)
        txtBarcodeScanner.Focus()
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Using dlg As New SalesItemDialogForm()
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return
            If String.IsNullOrWhiteSpace(dlg.SelectedBarcode) Then Return
            LookupAndAddProduct(dlg.SelectedBarcode, dlg.SelectedQuantity)
        End Using
        txtBarcodeScanner.Focus()
    End Sub

    Private Sub LookupAndAddProduct(barcode As String, Optional quantityToAdd As Integer = 1)
        Try
            Dim dt As DataTable = ProductRepository.GetByBarcode(barcode)

            If dt.Rows.Count = 0 Then
                System.Media.SystemSounds.Hand.Play()
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
                System.Media.SystemSounds.Hand.Play()
                MessageBox.Show($"Not enough stock for '{productName}'. Available: {stock - alreadyInCart}",
                                "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            AddItemToCart(barcode, productID, productName, price, stock, quantityToAdd)
            System.Media.SystemSounds.Asterisk.Play()

        Catch ex As Exception
            MessageBox.Show("Failed to look up product." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            txtBarcodeScanner.Focus()
        End Try
    End Sub

    Private Sub AddItemToCart(barcode As String, productID As Integer,
                               productName As String, price As Decimal,
                               stock As Integer,
                               Optional quantityToAdd As Integer = 1)
        If Not _cartItems.ContainsKey(barcode) Then
            _cartItems(barcode) = (productID, price, stock)
        End If

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.IsNewRow Then Continue For
            If row.Cells("colBarcode").Value.ToString() = barcode Then
                Dim newQty As Integer = CInt(row.Cells("colQuantity").Value) + quantityToAdd
                row.Cells("colQuantity").Value = newQty
                row.Cells("colTotal").Value    = FormatCurrency(newQty * price)
                dgvCart.ClearSelection()
                row.Selected = True
                UpdateTransactionSummary()
                UpdateSelectedCartItemDisplay()
                Return
            End If
        Next

        Dim newRowIndex As Integer = dgvCart.Rows.Add(barcode, productName, FormatCurrency(price), quantityToAdd, FormatCurrency(quantityToAdd * price))
        dgvCart.ClearSelection()
        dgvCart.Rows(newRowIndex).Selected = True
        UpdateTransactionSummary()
        UpdateSelectedCartItemDisplay()
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
        UpdateSelectedCartItemDisplay()
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
        UpdateSelectedCartItemDisplay()
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

    ' ─── Inline & manual summary quantity editing ───────────────────────────────

    Private Sub dgvCart_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCart.SelectionChanged
        UpdateSelectedCartItemDisplay()
    End Sub

    Private _updatingQtyBox As Boolean = False

    Private Sub UpdateSelectedCartItemDisplay()
        If dgvCart.SelectedRows.Count = 0 Then
            lblSelectedItemName.Text = "(Scan barcode or select item)"
            lblStockInfo.Text = "Stock: --"
            _updatingQtyBox = True
            txtItemQty.Text = "0"
            _updatingQtyBox = False
            btnQtyMinus.Enabled = False
            btnQtyPlus.Enabled = False
            btnQtyAdd5.Enabled = False
            btnQtyAdd10.Enabled = False
            txtItemQty.Enabled = False
            Return
        End If

        Dim row As DataGridViewRow = dgvCart.SelectedRows(0)
        Dim barcode As String = row.Cells("colBarcode").Value.ToString()
        Dim prodName As String = row.Cells("colProductName").Value.ToString()
        Dim qty As Integer = CInt(row.Cells("colQuantity").Value)
        Dim price As Decimal = If(_cartItems.ContainsKey(barcode), _cartItems(barcode).UnitPrice, 0D)
        Dim stock As Integer = If(_cartItems.ContainsKey(barcode), _cartItems(barcode).Stock, 0)

        lblSelectedItemName.Text = $"{prodName} (₱{price:N2})"
        lblStockInfo.Text = $"Stock: {stock}"

        _updatingQtyBox = True
        txtItemQty.Text = qty.ToString()
        _updatingQtyBox = False

        btnQtyMinus.Enabled = True
        btnQtyPlus.Enabled = True
        btnQtyAdd5.Enabled = True
        btnQtyAdd10.Enabled = True
        txtItemQty.Enabled = True
    End Sub

    Public Sub AdjustSelectedItemQuantity(delta As Integer)
        If dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select or scan an item in the cart to adjust its quantity.",
                            "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataGridViewRow = dgvCart.SelectedRows(0)
        Dim barcode As String = row.Cells("colBarcode").Value.ToString()
        Dim currentQty As Integer = CInt(row.Cells("colQuantity").Value)
        Dim newQty As Integer = currentQty + delta

        SetSelectedItemQuantity(row, barcode, newQty)
    End Sub

    Private Sub SetSelectedItemQuantity(row As DataGridViewRow, barcode As String, newQty As Integer)
        If newQty <= 0 Then
            Dim result = MessageBox.Show("Quantity is 0 or less. Do you want to remove this item from the cart?",
                                         "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                dgvCart.Rows.Remove(row)
                _cartItems.Remove(barcode)
                UpdateTransactionSummary()
                UpdateSelectedCartItemDisplay()
            End If
            Return
        End If

        Dim availableStock As Integer = If(_cartItems.ContainsKey(barcode), _cartItems(barcode).Stock, Integer.MaxValue)
        If newQty > availableStock Then
            System.Media.SystemSounds.Hand.Play()
            Dim prodName As String = row.Cells("colProductName").Value.ToString()
            MessageBox.Show($"Cannot set quantity to {newQty}. Available stock for '{prodName}' is {availableStock}.",
                            "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            newQty = availableStock
        End If

        Dim price As Decimal = If(_cartItems.ContainsKey(barcode), _cartItems(barcode).UnitPrice, 0D)
        row.Cells("colQuantity").Value = newQty
        row.Cells("colTotal").Value = FormatCurrency(newQty * price)

        UpdateTransactionSummary()
        UpdateSelectedCartItemDisplay()
    End Sub

    Private Sub btnQtyMinus_Click(sender As Object, e As EventArgs) Handles btnQtyMinus.Click
        AdjustSelectedItemQuantity(-1)
    End Sub

    Private Sub btnQtyPlus_Click(sender As Object, e As EventArgs) Handles btnQtyPlus.Click
        AdjustSelectedItemQuantity(1)
    End Sub

    Private Sub btnQtyAdd5_Click(sender As Object, e As EventArgs) Handles btnQtyAdd5.Click
        AdjustSelectedItemQuantity(5)
    End Sub

    Private Sub btnQtyAdd10_Click(sender As Object, e As EventArgs) Handles btnQtyAdd10.Click
        AdjustSelectedItemQuantity(10)
    End Sub

    Private Sub txtItemQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            ApplyManualQtyFromBox()
        End If
    End Sub

    Private Sub txtItemQty_Leave(sender As Object, e As EventArgs) Handles txtItemQty.Leave
        ApplyManualQtyFromBox()
    End Sub

    Private Sub ApplyManualQtyFromBox()
        If _updatingQtyBox OrElse dgvCart.SelectedRows.Count = 0 Then Return
        Dim enteredQty As Integer
        If Integer.TryParse(txtItemQty.Text, enteredQty) AndAlso enteredQty > 0 Then
            Dim row As DataGridViewRow = dgvCart.SelectedRows(0)
            Dim barcode As String = row.Cells("colBarcode").Value.ToString()
            SetSelectedItemQuantity(row, barcode, enteredQty)
        Else
            UpdateSelectedCartItemDisplay()
        End If
    End Sub

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
        UpdateSelectedCartItemDisplay()
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
            ReceiptPrinter.PrintReceipt(receiptNo)

        Catch ex As Exception
            MessageBox.Show("Failed to save transaction." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
