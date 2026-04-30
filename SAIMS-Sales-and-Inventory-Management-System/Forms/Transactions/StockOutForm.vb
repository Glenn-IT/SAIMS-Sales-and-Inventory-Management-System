Public Class StockOutForm
    Private Sub StockOutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbProduct.Items.AddRange(New String() {
            "Coca Cola 1.5L",
            "Lucky Me Pancit Canton",
            "Argentina Corned Beef",
            "Red Horse Beer",
            "Payless White Sugar 1kg"
        })

        cmbReason.Items.AddRange(New String() {
            "Damaged",
            "Expired",
            "Returns",
            "Wastage",
            "Other"
        })

        If cmbProduct.Items.Count > 0 Then
            cmbProduct.SelectedIndex = 0
        End If

        If cmbReason.Items.Count > 0 Then
            cmbReason.SelectedIndex = 0
        End If

        dtpDate.Value = DateTime.Now
        LoadStockOutHistory()
    End Sub

    Private Sub LoadStockOutHistory()
        dgvStockOut.Rows.Clear()

        dgvStockOut.Rows.Add("SO001", "Coca Cola 1.5L", "5", "Damaged", "2024-01-15", "Broken bottles")
        dgvStockOut.Rows.Add("SO002", "Lucky Me Pancit Canton", "10", "Expired", "2024-01-16", "Past expiry date")
        dgvStockOut.Rows.Add("SO003", "Red Horse Beer", "3", "Damaged", "2024-01-16", "Dented cans")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            MessageBox.Show("Please enter quantity!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show($"Stock Out Recorded!" & vbCrLf &
                       $"Product: {cmbProduct.Text}" & vbCrLf &
                       $"Quantity: {txtQuantity.Text}" & vbCrLf &
                       $"Reason: {cmbReason.Text}" & vbCrLf &
                       $"Date: {dtpDate.Value.ToShortDateString()}" & vbCrLf &
                       $"Remarks: {txtRemarks.Text}" & vbCrLf & vbCrLf &
                       "UI Only - No Database",
                       "Stock Out Success",
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
        If cmbReason.Items.Count > 0 Then
            cmbReason.SelectedIndex = 0
        End If
        txtQuantity.Clear()
        txtRemarks.Clear()
        dtpDate.Value = DateTime.Now
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStockOutHistory()
    End Sub
End Class
