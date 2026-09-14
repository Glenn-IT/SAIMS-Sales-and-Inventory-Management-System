Public Class InventoryReportForm

    Private Sub InventoryReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbReportType.Items.AddRange(New String() {"Daily", "Weekly", "Monthly", "Yearly"})
        cmbReportType.SelectedIndex = 2

        If Not String.IsNullOrWhiteSpace(SessionManager.FullName) Then
            txtSignatory.Text = SessionManager.FullName
        End If

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

            Dim range As (DateFrom As DateTime, DateTo As DateTime) = GetReportDateRange()
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim signatoryName As String = txtSignatory.Text.Trim()

            ' If user didn't enter a signatory name, prompt with a dialog before printing
            If String.IsNullOrWhiteSpace(signatoryName) Then
                Dim defaultName As String = If(Not String.IsNullOrWhiteSpace(SessionManager.FullName), SessionManager.FullName, "")
                signatoryName = InputBox("Please enter the name of the signatory for the report:", "Report Signatory Required", defaultName).Trim()

                If String.IsNullOrWhiteSpace(signatoryName) Then
                    MessageBox.Show("Signatory name is required to print the report.",
                                    "Signatory Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSignatory.Focus()
                    Return
                End If

                txtSignatory.Text = signatoryName
            End If

            ' Retrieve data for the report
            Dim range As (DateFrom As DateTime, DateTo As DateTime) = GetReportDateRange()
            Dim products As DataTable = ProductRepository.GetAll()
            Dim salesSummary As DataTable = SalesRepository.GetSalesSummary(range.DateFrom, range.DateTo)

            Dim totalItems As Integer = 0
            Dim totalStock As Integer = 0
            Dim lowStockCount As Integer = 0
            Dim outOfStockCnt As Integer = 0

            Integer.TryParse(txtTotalItems.Text, totalItems)
            Integer.TryParse(txtTotalStock.Text, totalStock)
            Integer.TryParse(txtLowStock.Text, lowStockCount)
            Integer.TryParse(txtOutOfStock.Text, outOfStockCnt)

            ' Generate printable HTML and redirect to Chrome print/PDF preview
            ReportPrinter.PrintInventoryReport(
                cmbReportType.Text,
                range.DateFrom,
                range.DateTo,
                signatoryName,
                totalItems,
                totalStock,
                lowStockCount,
                outOfStockCnt,
                products,
                salesSummary)

            Dim user As String = If(String.IsNullOrEmpty(SessionManager.Username), "SYSTEM", SessionManager.Username)
            ActivityLogger.Log(user, Constants.LOG_SUCCESS,
                               $"Printed {cmbReportType.Text} inventory report signed by '{signatoryName}'.")

        Catch ex As Exception
            MessageBox.Show("An error occurred while printing the report." & Environment.NewLine & ex.Message,
                            "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshAll()
    End Sub

    Private Sub cmbReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        RefreshAll()
    End Sub

End Class
