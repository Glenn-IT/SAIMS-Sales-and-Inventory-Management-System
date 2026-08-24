Public Class ReceiptsForm

    Private _sales As DataTable

    Private Sub ReceiptsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Today.AddDays(-30)
        dtpTo.Value   = DateTime.Today
        LoadReceipts()
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            MessageBox.Show("'From' date cannot be after 'To' date.", "Invalid Range",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        LoadReceiptsByDateRange(dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        LoadReceipts()
    End Sub

    Private Sub LoadReceipts()
        Try
            _sales = SalesRepository.GetAll()
            PopulateGrid(_sales)
        Catch ex As Exception
            MessageBox.Show("Failed to load receipts." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadReceiptsByDateRange(dateFrom As DateTime, dateTo As DateTime)
        Try
            _sales = SalesRepository.GetByDateRange(dateFrom, dateTo)
            PopulateGrid(_sales)
        Catch ex As Exception
            MessageBox.Show("Failed to filter receipts." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateGrid(dt As DataTable)
        dgvReceipts.Rows.Clear()
        For Each row As DataRow In dt.Rows
            dgvReceipts.Rows.Add(
                row("ReceiptNo").ToString(),
                CDate(row("SaleDate")).ToString("yyyy-MM-dd HH:mm"),
                "₱" & CDec(row("TotalAmount")).ToString("N2"),
                row("PaymentMethod").ToString(),
                row("Status").ToString())
        Next
    End Sub

    Private Sub btnViewReceipt_Click(sender As Object, e As EventArgs) Handles btnViewReceipt.Click
        If dgvReceipts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a receipt to view.", "View Receipt",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim receiptNo As String = dgvReceipts.SelectedRows(0).Cells("colReceiptNo").Value.ToString()
        ShowReceiptDetail(receiptNo)
    End Sub

    Private Sub ShowReceiptDetail(receiptNo As String)
        Try
            ' Find the sale row for this receipt
            Dim saleRow As DataRow = Nothing
            For Each r As DataRow In _sales.Rows
                If r("ReceiptNo").ToString() = receiptNo Then
                    saleRow = r
                    Exit For
                End If
            Next
            If saleRow Is Nothing Then Return

            Dim saleID   As Integer = CInt(saleRow("SaleID"))
            Dim items    As DataTable = SaleItemRepository.GetBySaleID(saleID)

            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("══════════════════════════════")
            sb.AppendLine("          SAIMS RECEIPT")
            sb.AppendLine("══════════════════════════════")
            sb.AppendLine($"Receipt No : {saleRow("ReceiptNo")}")
            sb.AppendLine($"Date       : {CDate(saleRow("SaleDate")):yyyy-MM-dd HH:mm}")
            sb.AppendLine($"Cashier    : {saleRow("Cashier")}")
            sb.AppendLine($"Payment    : {saleRow("PaymentMethod")}")
            sb.AppendLine("──────────────────────────────")
            sb.AppendLine("ITEMS:")

            For Each item As DataRow In items.Rows
                Dim lineAmt As String = $"₱{CDec(item("LineTotal")):N2}"
                sb.AppendLine($"  {item("ProductName")}")
                sb.AppendLine($"    {item("Quantity")} x ₱{CDec(item("UnitPrice")):N2} = {lineAmt}")
            Next

            sb.AppendLine("──────────────────────────────")
            sb.AppendLine($"Subtotal   : ₱{CDec(saleRow("SubTotal")):N2}")

            Dim discount As Decimal = CDec(saleRow("Discount"))
            If discount > 0 Then
                sb.AppendLine($"Discount   : -₱{discount:N2}")
            End If

            sb.AppendLine($"TOTAL      : ₱{CDec(saleRow("TotalAmount")):N2}")
            sb.AppendLine($"Tendered   : ₱{CDec(saleRow("AmountTendered")):N2}")
            sb.AppendLine($"Change     : ₱{CDec(saleRow("Change")):N2}")
            sb.AppendLine("══════════════════════════════")
            sb.AppendLine($"Status: {saleRow("Status")}")

            MessageBox.Show(sb.ToString(), $"Receipt — {receiptNo}",
                            MessageBoxButtons.OK, MessageBoxIcon.None)

        Catch ex As Exception
            MessageBox.Show("Failed to load receipt details." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        If dgvReceipts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a receipt to print.", "Print Receipt",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim receiptNo As String = dgvReceipts.SelectedRows(0).Cells("colReceiptNo").Value.ToString()
        MessageBox.Show($"Printer integration is not yet implemented." &
                        Environment.NewLine & Environment.NewLine &
                        $"Receipt: {receiptNo}",
                        "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadReceipts()
    End Sub

    Private Sub dgvReceipts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReceipts.CellDoubleClick
        If e.RowIndex >= 0 Then btnViewReceipt_Click(sender, e)
    End Sub

End Class
