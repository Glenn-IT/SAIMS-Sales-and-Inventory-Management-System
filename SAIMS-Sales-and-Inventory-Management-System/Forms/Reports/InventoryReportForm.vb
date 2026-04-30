Public Class InventoryReportForm
    Private Sub InventoryReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbReportType.Items.AddRange(New String() {"Daily", "Weekly", "Monthly", "Yearly"})
        cmbReportType.SelectedIndex = 2

        LoadInventorySummary()
        LoadProductList()
    End Sub

    Private Sub LoadInventorySummary()
        txtTotalItems.Text = "10"
        txtTotalStock.Text = "915"
        txtLowStock.Text = "1"
        txtOutOfStock.Text = "1"

        txtOpeningStock.Text = "800"
        txtStockIn.Text = "200"
        txtStockOut.Text = "85"
        txtClosingStock.Text = "915"
    End Sub

    Private Sub LoadProductList()
        dgvInventory.Rows.Clear()

        dgvInventory.Rows.Add("Coca Cola 1.5L", "Beverages", "?55.00", "150", "Available")
        dgvInventory.Rows.Add("Lucky Me Pancit Canton", "Noodles", "?12.50", "200", "Available")
        dgvInventory.Rows.Add("Argentina Corned Beef", "Canned Goods", "?45.00", "80", "Available")
        dgvInventory.Rows.Add("Red Horse Beer", "Beverages", "?50.00", "100", "Available")
        dgvInventory.Rows.Add("Payless White Sugar 1kg", "Groceries", "?65.00", "60", "Available")
        dgvInventory.Rows.Add("Champion Detergent", "Household", "?8.50", "120", "Available")
        dgvInventory.Rows.Add("San Miguel Pale Pilsen", "Beverages", "?45.00", "5", "Low Stock")
        dgvInventory.Rows.Add("Del Monte Tomato Sauce", "Canned Goods", "?18.00", "90", "Available")
        dgvInventory.Rows.Add("Alaska Condensed Milk", "Dairy", "?35.00", "0", "Out of Stock")
        dgvInventory.Rows.Add("Jack n Jill Piattos", "Snacks", "?25.00", "110", "Available")
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        MessageBox.Show($"Generating {cmbReportType.Text} Inventory Report..." & vbCrLf & vbCrLf &
                       "UI Only - No Report Generation",
                       "Generate Report",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        MessageBox.Show("Export to PDF functionality" & vbCrLf &
                       "UI Only - No Export",
                       "Export PDF",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        MessageBox.Show("Export to Excel functionality" & vbCrLf &
                       "UI Only - No Export",
                       "Export Excel",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        MessageBox.Show("Print Report functionality" & vbCrLf &
                       "UI Only - No Printer",
                       "Print Report",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadInventorySummary()
        LoadProductList()
    End Sub

    Private Sub cmbReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        lblReportPeriod.Text = $"Report Period: {cmbReportType.Text}"
    End Sub
End Class
