Public Class SalesForm
    Private cartTotal As Decimal = 0
    Private productsList As New Dictionary(Of String, (Name As String, Price As Decimal, Stock As Integer))

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeProducts()
        cmbPaymentMethod.SelectedIndex = 0
        txtBarcodeScanner.Focus()
        UpdateTransactionSummary()
    End Sub

    Private Sub InitializeProducts()
        productsList.Add("P001", ("Coca Cola 1.5L", 55D, 150))
        productsList.Add("P002", ("Lucky Me Pancit Canton", 12.5D, 200))
        productsList.Add("P003", ("Argentina Corned Beef", 45D, 80))
        productsList.Add("P004", ("Red Horse Beer", 50D, 100))
        productsList.Add("P005", ("Payless White Sugar 1kg", 65D, 60))
        productsList.Add("P006", ("Champion Detergent", 8.5D, 120))
        productsList.Add("P007", ("San Miguel Pale Pilsen", 45D, 5))
        productsList.Add("P008", ("Del Monte Tomato Sauce", 18D, 90))
        productsList.Add("P009", ("Alaska Condensed Milk", 35D, 0))
        productsList.Add("P010", ("Jack n Jill Piattos", 25D, 110))
    End Sub

    Private Sub txtBarcodeScanner_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcodeScanner.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            ProcessBarcodeInput()
        End If
    End Sub

    Private Sub ProcessBarcodeInput()
        Dim barcode As String = txtBarcodeScanner.Text.Trim().ToUpper()

        If String.IsNullOrWhiteSpace(barcode) Then
            Return
        End If

        If productsList.ContainsKey(barcode) Then
            Dim product = productsList(barcode)

            If product.Stock > 0 Then
                AddItemToCart(barcode, product.Name, product.Price)
                txtBarcodeScanner.Clear()
                txtBarcodeScanner.Focus()
            Else
                MessageBox.Show($"Product '{product.Name}' is out of stock!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcodeScanner.Clear()
            End If
        Else
            MessageBox.Show($"Product with barcode '{barcode}' not found!", "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcodeScanner.Clear()
        End If
    End Sub

    Private Sub AddItemToCart(barcode As String, productName As String, price As Decimal)
        Dim itemExists As Boolean = False

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.IsNewRow Then Continue For

            If row.Cells("colBarcode").Value.ToString() = barcode Then
                Dim currentQty As Integer = CInt(row.Cells("colQuantity").Value)
                Dim newQty As Integer = currentQty + 1

                row.Cells("colQuantity").Value = newQty
                row.Cells("colTotal").Value = FormatCurrency(newQty * price)

                itemExists = True
                Exit For
            End If
        Next

        If Not itemExists Then
            Dim total As Decimal = price * 1
            dgvCart.Rows.Add(barcode, productName, FormatCurrency(price), 1, FormatCurrency(total))
        End If

        UpdateTransactionSummary()
    End Sub

    Private Sub UpdateTransactionSummary()
        cartTotal = 0
        Dim itemCount As Integer = 0

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.IsNewRow Then Continue For

            Dim totalText As String = row.Cells("colTotal").Value.ToString().Replace("₱", "").Replace(",", "")
            Dim total As Decimal = CDec(totalText)
            cartTotal += total
            itemCount += 1
        Next

        txtTotalItems.Text = itemCount.ToString()
        txtSubtotal.Text = FormatCurrency(cartTotal)

        Dim discount As Decimal = 0
        If Not String.IsNullOrWhiteSpace(txtDiscount.Text) Then
            Decimal.TryParse(txtDiscount.Text, discount)
        End If

        Dim finalTotal As Decimal = cartTotal - discount
        txtTotalAmount.Text = FormatCurrency(finalTotal)

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
        If Not String.IsNullOrWhiteSpace(txtAmountTendered.Text) Then
            Decimal.TryParse(txtAmountTendered.Text, tendered)
        End If

        Dim totalText As String = txtTotalAmount.Text.Replace("₱", "").Replace(",", "")
        Dim total As Decimal = CDec(totalText)

        Dim change As Decimal = tendered - total
        txtChange.Text = FormatCurrency(change)
    End Sub

    Private Function FormatCurrency(amount As Decimal) As String
        Return "₱" & amount.ToString("N2")
    End Function

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        MessageBox.Show("Manual Add Item - UI Only", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvCart.SelectedRows.Count > 0 Then
            dgvCart.Rows.Remove(dgvCart.SelectedRows(0))
            UpdateTransactionSummary()
        Else
            MessageBox.Show("Please select an item to remove", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        Dim result = MessageBox.Show("Clear all items from cart?", "Clear Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            dgvCart.Rows.Clear()
            txtBarcodeScanner.Clear()
            txtDiscount.Clear()
            txtAmountTendered.Clear()
            UpdateTransactionSummary()
            txtBarcodeScanner.Focus()
        End If
    End Sub

    Private Sub btnSavePrint_Click(sender As Object, e As EventArgs) Handles btnSavePrint.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("No items in cart!", "Save Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("Transaction Saved!" & vbCrLf & "Receipt will be printed - UI Only", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        dgvCart.Rows.Clear()
        txtBarcodeScanner.Clear()
        txtDiscount.Clear()
        txtAmountTendered.Clear()
        UpdateTransactionSummary()
        txtBarcodeScanner.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result = MessageBox.Show("Cancel this transaction?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            dgvCart.Rows.Clear()
            txtBarcodeScanner.Clear()
            txtDiscount.Clear()
            txtAmountTendered.Clear()
            UpdateTransactionSummary()
            txtBarcodeScanner.Focus()
        End If
    End Sub

    Private Sub dgvCart_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellEndEdit
        If e.ColumnIndex = dgvCart.Columns("colQuantity").Index Then
            Dim row As DataGridViewRow = dgvCart.Rows(e.RowIndex)
            Dim qty As Integer = CInt(row.Cells("colQuantity").Value)
            Dim priceText As String = row.Cells("colPrice").Value.ToString().Replace("₱", "").Replace(",", "")
            Dim price As Decimal = CDec(priceText)
            row.Cells("colTotal").Value = FormatCurrency(qty * price)
            UpdateTransactionSummary()
        End If
    End Sub
End Class
