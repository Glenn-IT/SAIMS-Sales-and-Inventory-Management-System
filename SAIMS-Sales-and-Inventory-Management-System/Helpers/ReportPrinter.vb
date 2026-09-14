Imports System.IO
Imports System.Diagnostics
Imports System.Text

Public Module ReportPrinter

    ''' <summary>
    ''' Generates an HTML PDF-ready Inventory Report and opens it in Google Chrome (or default browser).
    ''' </summary>
    Public Sub PrintInventoryReport(reportType As String,
                                   dateFrom As DateTime,
                                   dateTo As DateTime,
                                   signatoryName As String,
                                   totalItems As Integer,
                                   totalStock As Integer,
                                   lowStockCount As Integer,
                                   outOfStockCount As Integer,
                                   productsTable As DataTable,
                                   salesSummary As DataTable)
        Try
            Dim html As String = GenerateReportHtml(reportType, dateFrom, dateTo, signatoryName,
                                                    totalItems, totalStock, lowStockCount, outOfStockCount,
                                                    productsTable, salesSummary)

            ' Save HTML to temporary file
            Dim tempFolder As String = Path.GetTempPath()
            Dim fileName As String = $"InventoryReport_{DateTime.Now:yyyyMMdd_HHmmss}.html"
            Dim filePath As String = Path.Combine(tempFolder, fileName)

            File.WriteAllText(filePath, html, Encoding.UTF8)

            ' Open in Chrome or default browser
            OpenInChrome(filePath)

        Catch ex As Exception
            MessageBox.Show("Failed to generate report for printing." & Environment.NewLine & ex.Message,
                            "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateReportHtml(reportType As String,
                                        dateFrom As DateTime,
                                        dateTo As DateTime,
                                        signatoryName As String,
                                        totalItems As Integer,
                                        totalStock As Integer,
                                        lowStockCount As Integer,
                                        outOfStockCount As Integer,
                                        productsTable As DataTable,
                                        salesSummary As DataTable) As String
        Dim sb As New StringBuilder()

        Dim generatedOn As String = DateTime.Now.ToString("MMMM dd, yyyy  hh:mm tt")
        Dim periodStr As String = If(reportType = "Daily",
                                     dateTo.ToString("MMMM dd, yyyy"),
                                     $"{dateFrom:MMM dd, yyyy} — {dateTo:MMM dd, yyyy}")

        Dim currentUser As String = If(Not String.IsNullOrEmpty(SessionManager.FullName),
                                       $"{SessionManager.FullName} ({SessionManager.UserType})",
                                       "System User")

        ' Calculate total inventory valuation
        Dim totalValuation As Decimal = 0
        If productsTable IsNot Nothing Then
            For Each row As DataRow In productsTable.Rows
                Dim price As Decimal = 0
                Dim stock As Integer = 0
                Decimal.TryParse(row("Price").ToString(), price)
                Integer.TryParse(row("Stock").ToString(), stock)
                totalValuation += (price * stock)
            Next
        End If

        sb.AppendLine("<!DOCTYPE html>")
        sb.AppendLine("<html lang='en'>")
        sb.AppendLine("<head>")
        sb.AppendLine("  <meta charset='UTF-8'>")
        sb.AppendLine("  <title>Inventory Report - " & reportType & " - " & DateTime.Now.ToString("yyyy-MM-dd") & "</title>")
        sb.AppendLine("  <style>")
        sb.AppendLine("    * { box-sizing: border-box; }")
        sb.AppendLine("    body {")
        sb.AppendLine("      font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, Roboto, Helvetica, Arial, sans-serif;")
        sb.AppendLine("      background-color: #f1f5f9;")
        sb.AppendLine("      color: #1e293b;")
        sb.AppendLine("      margin: 0;")
        sb.AppendLine("      padding: 24px;")
        sb.AppendLine("      display: flex;")
        sb.AppendLine("      flex-direction: column;")
        sb.AppendLine("      align-items: center;")
        sb.AppendLine("    }")
        sb.AppendLine("    .no-print {")
        sb.AppendLine("      margin-bottom: 20px;")
        sb.AppendLine("      display: flex;")
        sb.AppendLine("      gap: 12px;")
        sb.AppendLine("    }")
        sb.AppendLine("    .btn-action {")
        sb.AppendLine("      background-color: #0284c7;")
        sb.AppendLine("      color: white;")
        sb.AppendLine("      border: none;")
        sb.AppendLine("      padding: 10px 22px;")
        sb.AppendLine("      font-size: 14px;")
        sb.AppendLine("      font-weight: 600;")
        sb.AppendLine("      border-radius: 6px;")
        sb.AppendLine("      cursor: pointer;")
        sb.AppendLine("      box-shadow: 0 2px 5px rgba(0,0,0,0.12);")
        sb.AppendLine("      display: inline-flex;")
        sb.AppendLine("      align-items: center;")
        sb.AppendLine("      gap: 8px;")
        sb.AppendLine("    }")
        sb.AppendLine("    .btn-action:hover { background-color: #0369a1; }")
        sb.AppendLine("    .btn-close { background-color: #64748b; }")
        sb.AppendLine("    .btn-close:hover { background-color: #475569; }")
        sb.AppendLine("    .report-container {")
        sb.AppendLine("      background-color: #ffffff;")
        sb.AppendLine("      width: 100%;")
        sb.AppendLine("      max-width: 880px;")
        sb.AppendLine("      padding: 40px 45px;")
        sb.AppendLine("      border-radius: 8px;")
        sb.AppendLine("      box-shadow: 0 4px 16px rgba(0,0,0,0.08);")
        sb.AppendLine("      border: 1px solid #e2e8f0;")
        sb.AppendLine("    }")
        sb.AppendLine("    /* Report Header */")
        sb.AppendLine("    .report-header {")
        sb.AppendLine("      border-bottom: 2px solid #0f172a;")
        sb.AppendLine("      padding-bottom: 16px;")
        sb.AppendLine("      margin-bottom: 24px;")
        sb.AppendLine("      display: flex;")
        sb.AppendLine("      justify-content: space-between;")
        sb.AppendLine("      align-items: flex-start;")
        sb.AppendLine("    }")
        sb.AppendLine("    .brand-title { font-size: 22px; font-weight: 800; color: #0f172a; letter-spacing: -0.5px; margin: 0 0 4px 0; }")
        sb.AppendLine("    .brand-subtitle { font-size: 13px; color: #64748b; margin: 0; }")
        sb.AppendLine("    .report-badge-container { text-align: right; }")
        sb.AppendLine("    .report-badge {")
        sb.AppendLine("      display: inline-block;")
        sb.AppendLine("      background-color: #0284c7;")
        sb.AppendLine("      color: white;")
        sb.AppendLine("      padding: 6px 14px;")
        sb.AppendLine("      border-radius: 4px;")
        sb.AppendLine("      font-size: 13px;")
        sb.AppendLine("      font-weight: 700;")
        sb.AppendLine("      text-transform: uppercase;")
        sb.AppendLine("      letter-spacing: 0.5px;")
        sb.AppendLine("    }")
        sb.AppendLine("    .report-title-section { margin-bottom: 20px; }")
        sb.AppendLine("    .report-title { font-size: 18px; font-weight: 700; color: #1e293b; margin: 0 0 10px 0; }")
        sb.AppendLine("    .meta-grid {")
        sb.AppendLine("      display: grid;")
        sb.AppendLine("      grid-template-columns: repeat(2, 1fr);")
        sb.AppendLine("      gap: 8px 24px;")
        sb.AppendLine("      background-color: #f8fafc;")
        sb.AppendLine("      border: 1px solid #e2e8f0;")
        sb.AppendLine("      border-radius: 6px;")
        sb.AppendLine("      padding: 12px 16px;")
        sb.AppendLine("      font-size: 13px;")
        sb.AppendLine("    }")
        sb.AppendLine("    .meta-item { display: flex; justify-content: space-between; }")
        sb.AppendLine("    .meta-label { color: #64748b; font-weight: 500; }")
        sb.AppendLine("    .meta-val { color: #0f172a; font-weight: 600; }")
        sb.AppendLine("    /* Stats Cards */")
        sb.AppendLine("    .stats-grid {")
        sb.AppendLine("      display: grid;")
        sb.AppendLine("      grid-template-columns: repeat(4, 1fr);")
        sb.AppendLine("      gap: 12px;")
        sb.AppendLine("      margin: 20px 0 24px 0;")
        sb.AppendLine("    }")
        sb.AppendLine("    .stat-card {")
        sb.AppendLine("      background: #f8fafc;")
        sb.AppendLine("      border: 1px solid #e2e8f0;")
        sb.AppendLine("      border-radius: 6px;")
        sb.AppendLine("      padding: 12px 14px;")
        sb.AppendLine("      text-align: center;")
        sb.AppendLine("    }")
        sb.AppendLine("    .stat-label { font-size: 11px; font-weight: 700; text-transform: uppercase; color: #64748b; margin-bottom: 4px; }")
        sb.AppendLine("    .stat-value { font-size: 20px; font-weight: 800; color: #0f172a; }")
        sb.AppendLine("    .stat-val-blue { color: #0284c7; }")
        sb.AppendLine("    .stat-val-green { color: #16a34a; }")
        sb.AppendLine("    .stat-val-orange { color: #ea580c; }")
        sb.AppendLine("    .stat-val-red { color: #dc2626; }")
        sb.AppendLine("    /* Table */")
        sb.AppendLine("    .table-container { margin-bottom: 24px; }")
        sb.AppendLine("    .table-title { font-size: 14px; font-weight: 700; color: #334155; margin-bottom: 8px; }")
        sb.AppendLine("    table.report-table {")
        sb.AppendLine("      width: 100%;")
        sb.AppendLine("      border-collapse: collapse;")
        sb.AppendLine("      font-size: 12px;")
        sb.AppendLine("    }")
        sb.AppendLine("    table.report-table th {")
        sb.AppendLine("      background-color: #0f172a;")
        sb.AppendLine("      color: #ffffff;")
        sb.AppendLine("      padding: 9px 10px;")
        sb.AppendLine("      text-align: left;")
        sb.AppendLine("      font-weight: 600;")
        sb.AppendLine("      font-size: 11px;")
        sb.AppendLine("      text-transform: uppercase;")
        sb.AppendLine("      letter-spacing: 0.3px;")
        sb.AppendLine("    }")
        sb.AppendLine("    table.report-table td {")
        sb.AppendLine("      padding: 8px 10px;")
        sb.AppendLine("      border-bottom: 1px solid #e2e8f0;")
        sb.AppendLine("      color: #334155;")
        sb.AppendLine("    }")
        sb.AppendLine("    table.report-table tbody tr:nth-child(even) { background-color: #f8fafc; }")
        sb.AppendLine("    table.report-table tfoot td {")
        sb.AppendLine("      background-color: #f1f5f9;")
        sb.AppendLine("      font-weight: 700;")
        sb.AppendLine("      border-top: 2px solid #0f172a;")
        sb.AppendLine("      border-bottom: 2px solid #0f172a;")
        sb.AppendLine("      color: #0f172a;")
        sb.AppendLine("    }")
        sb.AppendLine("    .badge {")
        sb.AppendLine("      display: inline-block;")
        sb.AppendLine("      padding: 2px 8px;")
        sb.AppendLine("      border-radius: 9999px;")
        sb.AppendLine("      font-size: 10px;")
        sb.AppendLine("      font-weight: 700;")
        sb.AppendLine("      text-transform: uppercase;")
        sb.AppendLine("    }")
        sb.AppendLine("    .badge-instock { background-color: #dcfce7; color: #166534; }")
        sb.AppendLine("    .badge-lowstock { background-color: #ffedd5; color: #9a3412; }")
        sb.AppendLine("    .badge-outofstock { background-color: #fee2e2; color: #991b1b; }")
        sb.AppendLine("    /* Sales highlights */")
        sb.AppendLine("    .sales-box {")
        sb.AppendLine("      background-color: #f8fafc;")
        sb.AppendLine("      border-left: 4px solid #0284c7;")
        sb.AppendLine("      padding: 10px 16px;")
        sb.AppendLine("      margin-bottom: 28px;")
        sb.AppendLine("      font-size: 12px;")
        sb.AppendLine("      color: #475569;")
        sb.AppendLine("    }")
        sb.AppendLine("    .sales-box strong { color: #0f172a; }")
        sb.AppendLine("    /* Signatories */")
        sb.AppendLine("    .signatories-section {")
        sb.AppendLine("      margin-top: 36px;")
        sb.AppendLine("      padding-top: 20px;")
        sb.AppendLine("      border-top: 1px solid #cbd5e1;")
        sb.AppendLine("      page-break-inside: avoid;")
        sb.AppendLine("    }")
        sb.AppendLine("    .signatories-title { font-size: 13px; font-weight: 700; color: #475569; text-transform: uppercase; margin-bottom: 24px; letter-spacing: 0.5px; }")
        sb.AppendLine("    .signatories-grid {")
        sb.AppendLine("      display: grid;")
        sb.AppendLine("      grid-template-columns: repeat(2, 1fr);")
        sb.AppendLine("      gap: 40px;")
        sb.AppendLine("    }")
        sb.AppendLine("    .signatory-box { text-align: left; }")
        sb.AppendLine("    .signatory-role-label { font-size: 12px; color: #64748b; font-weight: 600; margin-bottom: 40px; }")
        sb.AppendLine("    .signatory-line { border-bottom: 1.5px solid #0f172a; margin-bottom: 6px; }")
        sb.AppendLine("    .signatory-name { font-size: 14px; font-weight: 700; color: #0f172a; margin: 0; text-transform: uppercase; }")
        sb.AppendLine("    .signatory-title { font-size: 12px; color: #64748b; margin: 2px 0 0 0; }")
        sb.AppendLine("    .signatory-date { font-size: 11px; color: #94a3b8; margin: 4px 0 0 0; }")
        sb.AppendLine("    /* Report Footer */")
        sb.AppendLine("    .report-footer {")
        sb.AppendLine("      margin-top: 30px;")
        sb.AppendLine("      padding-top: 12px;")
        sb.AppendLine("      border-top: 1px dashed #cbd5e1;")
        sb.AppendLine("      display: flex;")
        sb.AppendLine("      justify-content: space-between;")
        sb.AppendLine("      font-size: 10px;")
        sb.AppendLine("      color: #94a3b8;")
        sb.AppendLine("    }")
        sb.AppendLine("    /* Print Styles */")
        sb.AppendLine("    @page {")
        sb.AppendLine("      size: A4 portrait;")
        sb.AppendLine("      margin: 10mm 12mm 10mm 12mm;")
        sb.AppendLine("    }")
        sb.AppendLine("    @media print {")
        sb.AppendLine("      body {")
        sb.AppendLine("        background-color: #ffffff !important;")
        sb.AppendLine("        padding: 0 !important;")
        sb.AppendLine("        margin: 0 !important;")
        sb.AppendLine("      }")
        sb.AppendLine("      .no-print { display: none !important; }")
        sb.AppendLine("      .report-container {")
        sb.AppendLine("        max-width: 100% !important;")
        sb.AppendLine("        width: 100% !important;")
        sb.AppendLine("        padding: 0 !important;")
        sb.AppendLine("        border: none !important;")
        sb.AppendLine("        box-shadow: none !important;")
        sb.AppendLine("        border-radius: 0 !important;")
        sb.AppendLine("      }")
        sb.AppendLine("      table.report-table th {")
        sb.AppendLine("        background-color: #0f172a !important;")
        sb.AppendLine("        color: #ffffff !important;")
        sb.AppendLine("        -webkit-print-color-adjust: exact;")
        sb.AppendLine("        print-color-adjust: exact;")
        sb.AppendLine("      }")
        sb.AppendLine("      .report-badge, .stat-card, .meta-grid, .badge, .sales-box {")
        sb.AppendLine("        -webkit-print-color-adjust: exact;")
        sb.AppendLine("        print-color-adjust: exact;")
        sb.AppendLine("      }")
        sb.AppendLine("    }")
        sb.AppendLine("  </style>")
        sb.AppendLine("</head>")
        sb.AppendLine("<body>")

        ' Screen toolbar
        sb.AppendLine("  <div class='no-print'>")
        sb.AppendLine("    <button class='btn-action' onclick='window.print()'>🖨️ Print / Save as PDF</button>")
        sb.AppendLine("    <button class='btn-action btn-close' onclick='window.close()'>✕ Close</button>")
        sb.AppendLine("  </div>")

        ' Main Report Container
        sb.AppendLine("  <div class='report-container'>")

        ' Top Header
        sb.AppendLine("    <div class='report-header'>")
        sb.AppendLine("      <div>")
        sb.AppendLine("        <h1 class='brand-title'>SAIMS</h1>")
        sb.AppendLine("        <p class='brand-subtitle'>Sales & Inventory Management System</p>")
        sb.AppendLine("      </div>")
        sb.AppendLine("      <div class='report-badge-container'>")
        sb.AppendLine($"        <span class='report-badge'>{reportType} Inventory Report</span>")
        sb.AppendLine("      </div>")
        sb.AppendLine("    </div>")

        ' Report Metadata Headings
        sb.AppendLine("    <div class='report-title-section'>")
        sb.AppendLine("      <div class='report-title'>Official Inventory & Stock Valuation Report</div>")
        sb.AppendLine("      <div class='meta-grid'>")
        sb.AppendLine($"        <div class='meta-item'><span class='meta-label'>Report Period:</span><span class='meta-val'>{periodStr}</span></div>")
        sb.AppendLine($"        <div class='meta-item'><span class='meta-label'>Report Type:</span><span class='meta-val'>{reportType}</span></div>")
        sb.AppendLine($"        <div class='meta-item'><span class='meta-label'>Date Generated:</span><span class='meta-val'>{generatedOn}</span></div>")
        sb.AppendLine($"        <div class='meta-item'><span class='meta-label'>Generated By:</span><span class='meta-val'>{currentUser}</span></div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("    </div>")

        ' Summary Cards
        sb.AppendLine("    <div class='stats-grid'>")
        sb.AppendLine($"      <div class='stat-card'><div class='stat-label'>Total Products</div><div class='stat-value stat-val-blue'>{totalItems}</div></div>")
        sb.AppendLine($"      <div class='stat-card'><div class='stat-label'>Total Units in Stock</div><div class='stat-value stat-val-green'>{totalStock:N0}</div></div>")
        sb.AppendLine($"      <div class='stat-card'><div class='stat-label'>Low Stock Alert</div><div class='stat-value stat-val-orange'>{lowStockCount}</div></div>")
        sb.AppendLine($"      <div class='stat-card'><div class='stat-label'>Out of Stock</div><div class='stat-value stat-val-red'>{outOfStockCount}</div></div>")
        sb.AppendLine("    </div>")

        ' Sales Highlights (if available for period)
        If salesSummary IsNot Nothing AndAlso salesSummary.Rows.Count > 0 Then
            Dim sRow As DataRow = salesSummary.Rows(0)
            Dim txns As Integer = 0
            Dim rev As Decimal = 0
            If Not IsDBNull(sRow("TotalTransactions")) Then Integer.TryParse(sRow("TotalTransactions").ToString(), txns)
            If Not IsDBNull(sRow("TotalRevenue")) Then Decimal.TryParse(sRow("TotalRevenue").ToString(), rev)

            sb.AppendLine("    <div class='sales-box'>")
            sb.AppendLine($"      <strong>Sales Activity in this Period ({periodStr}):</strong> ")
            sb.AppendLine($"      Completed Transactions: <strong>{txns:N0}</strong> &nbsp;|&nbsp; ")
            sb.AppendLine($"      Total Revenue: <strong>₱{rev:N2}</strong>")
            sb.AppendLine("    </div>")
        End If

        ' Products Table
        sb.AppendLine("    <div class='table-container'>")
        sb.AppendLine("      <div class='table-title'>Product Inventory Breakdown</div>")
        sb.AppendLine("      <table class='report-table'>")
        sb.AppendLine("        <thead>")
        sb.AppendLine("          <tr>")
        sb.AppendLine("            <th style='width: 35px; text-align:center;'>#</th>")
        sb.AppendLine("            <th>Product Name</th>")
        sb.AppendLine("            <th>Category</th>")
        sb.AppendLine("            <th style='text-align: right;'>Unit Price</th>")
        sb.AppendLine("            <th style='text-align: right;'>Stock</th>")
        sb.AppendLine("            <th style='text-align: right;'>Total Value</th>")
        sb.AppendLine("            <th style='text-align: center; width: 100px;'>Status</th>")
        sb.AppendLine("          </tr>")
        sb.AppendLine("        </thead>")
        sb.AppendLine("        <tbody>")

        If productsTable IsNot Nothing AndAlso productsTable.Rows.Count > 0 Then
            Dim idx As Integer = 1
            For Each row As DataRow In productsTable.Rows
                Dim pName As String = row("ProductName").ToString()
                Dim catName As String = If(productsTable.Columns.Contains("CategoryName") AndAlso Not IsDBNull(row("CategoryName")), row("CategoryName").ToString(), "-")
                Dim price As Decimal = 0
                Dim stock As Integer = 0
                Decimal.TryParse(row("Price").ToString(), price)
                Integer.TryParse(row("Stock").ToString(), stock)
                Dim lineVal As Decimal = price * stock
                Dim status As String = row("StockStatus").ToString()

                Dim badgeClass As String = "badge-instock"
                If status = "Low Stock" Then
                    badgeClass = "badge-lowstock"
                ElseIf status = "Out of Stock" Then
                    badgeClass = "badge-outofstock"
                End If

                sb.AppendLine("          <tr>")
                sb.AppendLine($"            <td style='text-align:center;'>{idx}</td>")
                sb.AppendLine($"            <td><strong>{pName}</strong></td>")
                sb.AppendLine($"            <td>{catName}</td>")
                sb.AppendLine($"            <td style='text-align: right;'>₱{price:N2}</td>")
                sb.AppendLine($"            <td style='text-align: right;'>{stock:N0}</td>")
                sb.AppendLine($"            <td style='text-align: right;'>₱{lineVal:N2}</td>")
                sb.AppendLine($"            <td style='text-align: center;'><span class='badge {badgeClass}'>{status}</span></td>")
                sb.AppendLine("          </tr>")
                idx += 1
            Next
        Else
            sb.AppendLine("          <tr><td colspan='7' style='text-align:center; padding: 15px;'>No inventory records found.</td></tr>")
        End If

        sb.AppendLine("        </tbody>")
        sb.AppendLine("        <tfoot>")
        sb.AppendLine("          <tr>")
        sb.AppendLine("            <td colspan='3'><strong>TOTAL INVENTORY SUMMARY</strong></td>")
        sb.AppendLine("            <td></td>")
        sb.AppendLine($"            <td style='text-align: right;'><strong>{totalStock:N0} units</strong></td>")
        sb.AppendLine($"            <td style='text-align: right;'><strong>₱{totalValuation:N2}</strong></td>")
        sb.AppendLine("            <td></td>")
        sb.AppendLine("          </tr>")
        sb.AppendLine("        </tfoot>")
        sb.AppendLine("      </table>")
        sb.AppendLine("    </div>")

        ' Signatories Section
        Dim finalSignatory As String = If(String.IsNullOrWhiteSpace(signatoryName), "Authorized Personnel", signatoryName.Trim())
        sb.AppendLine("    <div class='signatories-section'>")
        sb.AppendLine("      <div class='signatories-title'>Report Signatories & Verification</div>")
        sb.AppendLine("      <div class='signatories-grid'>")

        ' Prepared by box
        sb.AppendLine("        <div class='signatory-box'>")
        sb.AppendLine("          <div class='signatory-role-label'>Prepared & Certified By:</div>")
        sb.AppendLine("          <div class='signatory-line'></div>")
        sb.AppendLine($"          <p class='signatory-name'>{finalSignatory}</p>")
        sb.AppendLine("          <p class='signatory-title'>Designated Report Signatory / Inventory Officer</p>")
        sb.AppendLine($"          <p class='signatory-date'>Date: {DateTime.Now:MMMM dd, yyyy}</p>")
        sb.AppendLine("        </div>")

        ' Approved by box
        sb.AppendLine("        <div class='signatory-box'>")
        sb.AppendLine("          <div class='signatory-role-label'>Noted & Approved By:</div>")
        sb.AppendLine("          <div class='signatory-line'></div>")
        sb.AppendLine("          <p class='signatory-name'>Store / Operations Manager</p>")
        sb.AppendLine("          <p class='signatory-title'>Authorized Management Signatory</p>")
        sb.AppendLine("          <p class='signatory-date'>Date: ________________________</p>")
        sb.AppendLine("        </div>")

        sb.AppendLine("      </div>")
        sb.AppendLine("    </div>")

        ' Footer
        sb.AppendLine("    <div class='report-footer'>")
        sb.AppendLine("      <span>SAIMS &copy; " & DateTime.Now.Year.ToString() & " - Sales & Inventory Management System</span>")
        sb.AppendLine($"      <span>Confidential Business Document &bull; Generated: {generatedOn}</span>")
        sb.AppendLine("    </div>")

        sb.AppendLine("  </div>") ' end report-container

        ' Chrome Auto-print Script
        sb.AppendLine("  <script>")
        sb.AppendLine("    window.onload = function() {")
        sb.AppendLine("      setTimeout(function() { window.print(); }, 400);")
        sb.AppendLine("    };")
        sb.AppendLine("  </script>")
        sb.AppendLine("</body>")
        sb.AppendLine("</html>")

        Return sb.ToString()
    End Function

    Private Sub OpenInChrome(filePath As String)
        Dim chromePath As String = "C:\Program Files\Google\Chrome\Application\chrome.exe"
        Dim chromeX86Path As String = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
        Dim localAppDataChrome As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\Chrome\Application\chrome.exe")

        If File.Exists(chromePath) Then
            Process.Start(chromePath, $"""{filePath}""")
        ElseIf File.Exists(chromeX86Path) Then
            Process.Start(chromeX86Path, $"""{filePath}""")
        ElseIf File.Exists(localAppDataChrome) Then
            Process.Start(localAppDataChrome, $"""{filePath}""")
        Else
            Dim psi As New ProcessStartInfo() With {
                .FileName = filePath,
                .UseShellExecute = True
            }
            Process.Start(psi)
        End If
    End Sub

End Module
