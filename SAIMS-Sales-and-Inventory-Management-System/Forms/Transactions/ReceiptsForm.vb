Public Class ReceiptsForm
    Private Sub ReceiptsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReceiptsData()
    End Sub

    Private Sub LoadReceiptsData()
        dgvReceipts.Rows.Clear()

        dgvReceipts.Rows.Add("R00001", "2024-01-17 10:30 AM", "?520.00", "Cash", "Completed")
        dgvReceipts.Rows.Add("R00002", "2024-01-17 11:15 AM", "?275.50", "GCash", "Completed")
        dgvReceipts.Rows.Add("R00003", "2024-01-17 12:00 PM", "?850.00", "Cash", "Completed")
        dgvReceipts.Rows.Add("R00004", "2024-01-17 01:45 PM", "?320.00", "Credit Card", "Completed")
        dgvReceipts.Rows.Add("R00005", "2024-01-17 02:30 PM", "?195.00", "Cash", "Completed")
        dgvReceipts.Rows.Add("R00006", "2024-01-17 03:15 PM", "?460.50", "Cash", "Completed")
        dgvReceipts.Rows.Add("R00007", "2024-01-17 04:00 PM", "?685.00", "GCash", "Completed")
        dgvReceipts.Rows.Add("R00008", "2024-01-17 04:45 PM", "?125.00", "Cash", "Completed")
    End Sub

    Private Sub btnViewReceipt_Click(sender As Object, e As EventArgs) Handles btnViewReceipt.Click
        If dgvReceipts.SelectedRows.Count > 0 Then
            Dim receiptNo As String = dgvReceipts.SelectedRows(0).Cells("colReceiptNo").Value.ToString()
            MessageBox.Show($"Viewing Receipt: {receiptNo}" & vbCrLf & vbCrLf &
                           "Receipt details would be displayed here." & vbCrLf &
                           "UI Only - No Database",
                           "Receipt Details",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select a receipt to view", "View Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        If dgvReceipts.SelectedRows.Count > 0 Then
            Dim receiptNo As String = dgvReceipts.SelectedRows(0).Cells("colReceiptNo").Value.ToString()
            MessageBox.Show($"Printing Receipt: {receiptNo}" & vbCrLf & vbCrLf &
                           "UI Only - No Printer Integration",
                           "Print Receipt",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select a receipt to print", "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadReceiptsData()
    End Sub

    Private Sub dgvReceipts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReceipts.CellDoubleClick
        If e.RowIndex >= 0 Then
            btnViewReceipt_Click(sender, e)
        End If
    End Sub
End Class
