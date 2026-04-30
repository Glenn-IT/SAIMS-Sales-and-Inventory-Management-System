Public Class StockInForm
    Private Sub StockInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbProduct.Items.AddRange(New String() {
            "Coca Cola 1.5L",
            "Lucky Me Pancit Canton",
            "Argentina Corned Beef",
            "Red Horse Beer",
            "Payless White Sugar 1kg"
        })

        If cmbProduct.Items.Count > 0 Then
            cmbProduct.SelectedIndex = 0
        End If

        dtpDate.Value = DateTime.Now
        LoadStockInHistory()
    End Sub

    Private Sub LoadStockInHistory()
        dgvStockIn.Rows.Clear()

        dgvStockIn.Rows.Add("SI001", "Coca Cola 1.5L", "50", "2024-01-15", "Initial Stock")
        dgvStockIn.Rows.Add("SI002", "Lucky Me Pancit Canton", "100", "2024-01-15", "Restock")
        dgvStockIn.Rows.Add("SI003", "Red Horse Beer", "30", "2024-01-16", "New Delivery")
        dgvStockIn.Rows.Add("SI004", "Argentina Corned Beef", "25", "2024-01-16", "Restock")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            MessageBox.Show("Please enter quantity!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show($"Stock In Added!" & vbCrLf &
                       $"Product: {cmbProduct.Text}" & vbCrLf &
                       $"Quantity: {txtQuantity.Text}" & vbCrLf &
                       $"Date: {dtpDate.Value.ToShortDateString()}" & vbCrLf &
                       $"Remarks: {txtRemarks.Text}" & vbCrLf & vbCrLf &
                       "UI Only - No Database",
                       "Stock In Success",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)

        ClearFields()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        If cmbProduct.Items.Count > 0 Then
            cmbProduct.SelectedIndex = 0
        End If
        txtQuantity.Clear()
        txtRemarks.Clear()
        dtpDate.Value = DateTime.Now
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStockInHistory()
    End Sub
End Class
