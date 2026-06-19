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

    Private Sub LoadInventorySummary()
        Try
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

            ' All-time movement totals
            Dim movements As DataTable = StockMovementRepository.GetAll()
            Dim totalIn   As Integer   = 0
            Dim totalOut  As Integer   = 0

            For Each row As DataRow In movements.Rows
                Dim qty   As Integer = CInt(row("Quantity"))
                Dim mType As String  = row("MovementType").ToString()
                If mType = Constants.MOVEMENT_STOCKIN Then
                    totalIn += qty
                ElseIf mType = Constants.MOVEMENT_STOCKOUT OrElse mType = Constants.MOVEMENT_SALE Then
                    totalOut += qty
                End If
            Next

            ' Opening = Closing - In + Out  (derived from current stock and all movements)
            Dim opening As Integer = Math.Max(0, totalStock - totalIn + totalOut)

            txtOpeningStock.Text = opening.ToString()
            txtStockIn.Text      = totalIn.ToString()
            txtStockOut.Text     = totalOut.ToString()
            txtClosingStock.Text = totalStock.ToString()

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
        MessageBox.Show($"{cmbReportType.Text} Inventory Report" &
                        Environment.NewLine & Environment.NewLine &
                        $"Total Products:  {txtTotalItems.Text}" &
                        Environment.NewLine &
                        $"Total Stock:     {txtTotalStock.Text} units" &
                        Environment.NewLine &
                        $"Low Stock:       {txtLowStock.Text}" &
                        Environment.NewLine &
                        $"Out of Stock:    {txtOutOfStock.Text}" &
                        Environment.NewLine & Environment.NewLine &
                        $"Stock In:        +{txtStockIn.Text}" &
                        Environment.NewLine &
                        $"Stock Out/Sold:  -{txtStockOut.Text}",
                        "Report Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        MessageBox.Show("PDF export is not yet implemented.", "Export PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        MessageBox.Show("Excel export is not yet implemented.", "Export Excel",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        MessageBox.Show("Print report is not yet implemented.", "Print Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshAll()
    End Sub

    Private Sub cmbReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        lblReportPeriod.Text = $"Report Period: {cmbReportType.Text}"
    End Sub

End Class
