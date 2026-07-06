Public Class InventoryReportForm

    Private Sub InventoryReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbReportType.Items.AddRange(New String() {"Daily", "Weekly", "Monthly", "Yearly"})
        cmbReportType.SelectedIndex = 2
        RefreshAll()
    End Sub

    Private Sub RefreshAll()
        LoadInventorySummary()
        LoadProductList()
    End Sub

    Private Function GetReportDateRange() As (DateFrom As DateTime, DateTo As DateTime)
        Dim dateTo   As DateTime = DateTime.Today
        Dim dateFrom As DateTime
        Select Case cmbReportType.Text
            Case "Daily"   : dateFrom = dateTo
            Case "Weekly"  : dateFrom = dateTo.AddDays(-6)
            Case "Yearly"  : dateFrom = New DateTime(dateTo.Year, 1, 1)
            Case Else      : dateFrom = New DateTime(dateTo.Year, dateTo.Month, 1) ' Monthly default
        End Select
        Return (dateFrom, dateTo)
    End Function

    Private Sub LoadInventorySummary()
        Try
            ' Current stock stats are always live (not date-filtered)
            Dim products As DataTable = ProductRepository.GetAll()

            Dim totalItems    As Integer = 0
            Dim totalStock    As Integer = 0
            Dim lowStockCount As Integer = 0
            Dim outOfStockCnt As Integer = 0

            For Each row As DataRow In products.Rows
                totalItems += 1
                Dim stock  As Integer = CInt(row("Stock"))
                Dim status As String  = row("StockStatus").ToString()
                totalStock += stock
                If status = "Low Stock"    Then lowStockCount += 1
                If status = "Out of Stock" Then outOfStockCnt += 1
            Next

            txtTotalItems.Text = totalItems.ToString()
            txtTotalStock.Text = totalStock.ToString()
            txtLowStock.Text   = lowStockCount.ToString()
            txtOutOfStock.Text = outOfStockCnt.ToString()

            ' Stock movements filtered to the selected report period
            Dim range     As (DateFrom As DateTime, DateTo As DateTime) = GetReportDateRange()
            Dim movements As DataTable = StockMovementRepository.GetByDateRange(range.DateFrom, range.DateTo)

            Dim totalIn  As Integer = 0
            Dim totalOut As Integer = 0

            For Each row As DataRow In movements.Rows
                Dim qty   As Integer = CInt(row("Quantity"))
                Dim mType As String  = row("MovementType").ToString()
                If mType = Constants.MOVEMENT_STOCKIN Then
                    totalIn += qty
                ElseIf mType = Constants.MOVEMENT_STOCKOUT OrElse mType = Constants.MOVEMENT_SALE Then
                    totalOut += qty
                End If
            Next

            Dim opening As Integer = Math.Max(0, totalStock - totalIn + totalOut)

            txtOpeningStock.Text = opening.ToString()
            txtStockIn.Text      = totalIn.ToString()
            txtStockOut.Text     = totalOut.ToString()
            txtClosingStock.Text = totalStock.ToString()

            lblReportPeriod.Text = $"Period: {range.DateFrom:MMM dd, yyyy}  —  {range.DateTo:MMM dd, yyyy}"

        Catch ex As Exception
            MessageBox.Show("Failed to load inventory summary." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProductList()
        Try
            Dim dt As DataTable = ProductRepository.GetAll()
            dgvInventory.Rows.Clear()

            For Each row As DataRow In dt.Rows
                dgvInventory.Rows.Add(
                    row("ProductName").ToString(),
                    row("CategoryName").ToString(),
                    "₱" & CDec(row("Price")).ToString("N2"),
                    row("Stock").ToString(),
                    row("StockStatus").ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Failed to load product list." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        RefreshAll()

        Try
            Dim range    As (DateFrom As DateTime, DateTo As DateTime) = GetReportDateRange()
            Dim summary  As DataTable = SalesRepository.GetSalesSummary(range.DateFrom, range.DateTo)
            Dim topItems As DataTable = SalesRepository.GetTopSelling(range.DateFrom, range.DateTo, 5)

            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine($"  {cmbReportType.Text} Report  —  {range.DateFrom:MMM dd} to {range.DateTo:MMM dd, yyyy}")
            sb.AppendLine()
            sb.AppendLine("── INVENTORY ──────────────────────")
            sb.AppendLine($"  Total Products : {txtTotalItems.Text}")
            sb.AppendLine($"  Total Stock    : {txtTotalStock.Text} units")
            sb.AppendLine($"  Low Stock      : {txtLowStock.Text}")
            sb.AppendLine($"  Out of Stock   : {txtOutOfStock.Text}")
            sb.AppendLine()
            sb.AppendLine("── STOCK MOVEMENT ─────────────────")
            sb.AppendLine($"  Stock In       : +{txtStockIn.Text}")
            sb.AppendLine($"  Stock Out/Sold : -{txtStockOut.Text}")

            If summary.Rows.Count > 0 Then
                Dim row As DataRow = summary.Rows(0)
                sb.AppendLine()
                sb.AppendLine("── SALES ──────────────────────────")
                sb.AppendLine($"  Transactions   : {row("TotalTransactions")}")
                sb.AppendLine($"  Total Revenue  : ₱{CDec(row("TotalRevenue")):N2}")
                sb.AppendLine($"  Average Sale   : ₱{CDec(row("AverageSale")):N2}")
            End If

            If topItems.Rows.Count > 0 Then
                sb.AppendLine()
                sb.AppendLine("── TOP SELLING PRODUCTS ───────────")
                Dim rank As Integer = 1
                For Each item As DataRow In topItems.Rows
                    sb.AppendLine($"  {rank}. {item("ProductName")} — {item("TotalSold")} units  (₱{CDec(item("TotalRevenue")):N2})")
                    rank += 1
                Next
            End If

            MessageBox.Show(sb.ToString(), "Report Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to generate sales summary." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        MessageBox.Show("PDF export is not yet implemented.", "Export PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Using dlg As New SaveFileDialog()
                dlg.Title            = "Export Inventory Report"
                dlg.Filter           = "Excel Workbook (*.xlsx)|*.xlsx"
                dlg.FileName         = $"InventoryReport_{DateTime.Today:yyyyMMdd}.xlsx"
                If dlg.ShowDialog() <> DialogResult.OK Then Return

                Using wb As New ClosedXML.Excel.XLWorkbook()
                    Dim ws = wb.Worksheets.Add("Inventory")

                    ' Header row
                    Dim headers As String() = {"Product Name", "Category", "Price", "Stock", "Status"}
                    For i As Integer = 0 To headers.Length - 1
                        ws.Cell(1, i + 1).Value = headers(i)
                        ws.Cell(1, i + 1).Style.Font.Bold = True
                        ws.Cell(1, i + 1).Style.Fill.BackgroundColor =
                            ClosedXML.Excel.XLColor.FromArgb(52, 73, 94)
                        ws.Cell(1, i + 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.White
                    Next

                    ' Data rows
                    Dim rowNum As Integer = 2
                    For Each gridRow As DataGridViewRow In dgvInventory.Rows
                        If gridRow.IsNewRow Then Continue For
                        For col As Integer = 0 To 4
                            ws.Cell(rowNum, col + 1).Value =
                                gridRow.Cells(col).Value?.ToString()
                        Next
                        rowNum += 1
                    Next

                    ws.Columns().AdjustToContents()
                    wb.SaveAs(dlg.FileName)
                End Using

                MessageBox.Show($"Report exported to:{Environment.NewLine}{dlg.FileName}",
                                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to export Excel file." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        MessageBox.Show("Print report is not yet implemented.", "Print Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshAll()
    End Sub

    Private Sub cmbReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        RefreshAll()
    End Sub

End Class
