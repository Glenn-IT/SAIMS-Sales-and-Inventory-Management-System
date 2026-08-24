Imports System.IO
Imports System.Diagnostics
Imports System.Text

Public Module ReceiptPrinter

    ''' <summary>
    ''' Generates an HTML PDF-ready receipt for the specified receipt number
    ''' and opens it in Google Chrome (or default browser) to view and print.
    ''' </summary>
    Public Sub PrintReceipt(receiptNo As String)
        Try
            Dim dtSale As DataTable = SalesRepository.GetByReceiptNo(receiptNo)
            If dtSale Is Nothing OrElse dtSale.Rows.Count = 0 Then
                MessageBox.Show($"Receipt {receiptNo} not found.", "Print Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim saleRow As DataRow = dtSale.Rows(0)
            Dim saleID As Integer = CInt(saleRow("SaleID"))
            Dim dtItems As DataTable = SaleItemRepository.GetBySaleID(saleID)

            ' Build receipt HTML string
            Dim html As String = GenerateReceiptHtml(saleRow, dtItems)

            ' Save HTML to temporary file
            Dim tempFolder As String = Path.GetTempPath()
            Dim fileName As String = $"Receipt_{receiptNo}.html"
            Dim filePath As String = Path.Combine(tempFolder, fileName)

            File.WriteAllText(filePath, html, Encoding.UTF8)

            ' Open in Chrome or system default browser
            OpenInChrome(filePath)

        Catch ex As Exception
            MessageBox.Show("Failed to generate receipt for printing." & Environment.NewLine & ex.Message,
                            "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateReceiptHtml(saleRow As DataRow, dtItems As DataTable) As String
        Dim sb As New StringBuilder()

        Dim receiptNo As String = saleRow("ReceiptNo").ToString()
        Dim saleDate As DateTime = CDate(saleRow("SaleDate"))
        Dim cashier As String = saleRow("Cashier").ToString()
        Dim paymentMethod As String = saleRow("PaymentMethod").ToString()
        Dim subTotal As Decimal = CDec(saleRow("SubTotal"))
        Dim discount As Decimal = CDec(saleRow("Discount"))
        Dim totalAmount As Decimal = CDec(saleRow("TotalAmount"))
        Dim tendered As Decimal = CDec(saleRow("AmountTendered"))
        Dim change As Decimal = CDec(saleRow("Change"))

        sb.AppendLine("<!DOCTYPE html>")
        sb.AppendLine("<html lang='en'>")
        sb.AppendLine("<head>")
        sb.AppendLine("  <meta charset='UTF-8'>")
        sb.AppendLine("  <title>Receipt - " & receiptNo & "</title>")
        sb.AppendLine("  <style>")
        sb.AppendLine("    body {")
        sb.AppendLine("      font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;")
        sb.AppendLine("      background-color: #f4f6f9;")
        sb.AppendLine("      margin: 0;")
        sb.AppendLine("      padding: 20px;")
        sb.AppendLine("      display: flex;")
        sb.AppendLine("      flex-direction: column;")
        sb.AppendLine("      align-items: center;")
        sb.AppendLine("    }")
        sb.AppendLine("    .no-print {")
        sb.AppendLine("      margin-bottom: 20px;")
        sb.AppendLine("    }")
        sb.AppendLine("    .btn-print {")
        sb.AppendLine("      background-color: #2ecc71;")
        sb.AppendLine("      color: white;")
        sb.AppendLine("      border: none;")
        sb.AppendLine("      padding: 10px 24px;")
        sb.AppendLine("      font-size: 14px;")
        sb.AppendLine("      font-weight: bold;")
        sb.AppendLine("      border-radius: 4px;")
        sb.AppendLine("      cursor: pointer;")
        sb.AppendLine("      box-shadow: 0 2px 4px rgba(0,0,0,0.1);")
        sb.AppendLine("    }")
        sb.AppendLine("    .btn-print:hover { background-color: #27ae60; }")
        sb.AppendLine("    .receipt-card {")
        sb.AppendLine("      background-color: white;")
        sb.AppendLine("      width: 340px;")
        sb.AppendLine("      padding: 25px 20px;")
        sb.AppendLine("      border: 1px solid #e0e0e0;")
        sb.AppendLine("      box-shadow: 0 4px 12px rgba(0,0,0,0.08);")
        sb.AppendLine("      border-radius: 6px;")
        sb.AppendLine("      color: #333;")
        sb.AppendLine("    }")
        sb.AppendLine("    .header { text-align: center; margin-bottom: 15px; }")
        sb.AppendLine("    .header h2 { margin: 0 0 5px 0; color: #2c3e50; font-size: 20px; }")
        sb.AppendLine("    .header p { margin: 2px 0; color: #7f8c8d; font-size: 12px; }")
        sb.AppendLine("    .divider { border-top: 1px dashed #b2bec3; margin: 12px 0; }")
        sb.AppendLine("    .meta-table, .items-table, .totals-table { width: 100%; border-collapse: collapse; font-size: 13px; }")
        sb.AppendLine("    .meta-table td { padding: 3px 0; color: #555; }")
        sb.AppendLine("    .meta-table td.val { text-align: right; font-weight: 500; color: #2c3e50; }")
        sb.AppendLine("    .items-table th { text-align: left; border-bottom: 1px solid #ddd; padding-bottom: 5px; font-size: 12px; color: #7f8c8d; }")
        sb.AppendLine("    .items-table td { padding: 6px 0; }")
        sb.AppendLine("    .items-table td.qty-price { color: #7f8c8d; font-size: 12px; }")
        sb.AppendLine("    .items-table td.amt { text-align: right; font-weight: bold; }")
        sb.AppendLine("    .totals-table td { padding: 4px 0; }")
        sb.AppendLine("    .totals-table td.val { text-align: right; font-weight: bold; }")
        sb.AppendLine("    .totals-table tr.grand-total td { font-size: 16px; color: #2c3e50; padding-top: 6px; }")
        sb.AppendLine("    .footer { text-align: center; margin-top: 20px; color: #95a5a6; font-size: 12px; }")
        sb.AppendLine("    @media print {")
        sb.AppendLine("      body { background-color: white; padding: 0; }")
        sb.AppendLine("      .no-print { display: none; }")
        sb.AppendLine("      .receipt-card { box-shadow: none; border: none; width: 100%; max-width: 320px; padding: 0; }")
        sb.AppendLine("    }")
        sb.AppendLine("  </style>")
        sb.AppendLine("</head>")
        sb.AppendLine("<body>")
        sb.AppendLine("  <div class='no-print'>")
        sb.AppendLine("    <button class='btn-print' onclick='window.print()'>🖨️ Print Receipt / Save PDF</button>")
        sb.AppendLine("  </div>")
        sb.AppendLine("  <div class='receipt-card'>")
        sb.AppendLine("    <div class='header'>")
        sb.AppendLine("      <h2>SAIMS</h2>")
        sb.AppendLine("      <p>Sales & Inventory Management System</p>")
        sb.AppendLine("      <p>Official Sales Receipt</p>")
        sb.AppendLine("    </div>")
        sb.AppendLine("    <div class='divider'></div>")
        sb.AppendLine("    <table class='meta-table'>")
        sb.AppendLine($"      <tr><td>Receipt No:</td><td class='val'>{receiptNo}</td></tr>")
        sb.AppendLine($"      <tr><td>Date:</td><td class='val'>{saleDate:yyyy-MM-dd HH:mm}</td></tr>")
        sb.AppendLine($"      <tr><td>Cashier:</td><td class='val'>{cashier}</td></tr>")
        sb.AppendLine($"      <tr><td>Payment:</td><td class='val'>{paymentMethod}</td></tr>")
        sb.AppendLine("    </table>")
        sb.AppendLine("    <div class='divider'></div>")
        sb.AppendLine("    <table class='items-table'>")
        sb.AppendLine("      <thead><tr><th>Item</th><th style='text-align:right;'>Total</th></tr></thead>")
        sb.AppendLine("      <tbody>")

        For Each item As DataRow In dtItems.Rows
            Dim prodName As String = item("ProductName").ToString()
            Dim qty As Integer = CInt(item("Quantity"))
            Dim price As Decimal = CDec(item("UnitPrice"))
            Dim lineTotal As Decimal = CDec(item("LineTotal"))

            sb.AppendLine("        <tr>")
            sb.AppendLine($"          <td><div>{prodName}</div><div class='qty-price'>{qty} x ₱{price:N2}</div></td>")
            sb.AppendLine($"          <td class='amt'>₱{lineTotal:N2}</td>")
            sb.AppendLine("        </tr>")
        Next

        sb.AppendLine("      </tbody>")
        sb.AppendLine("    </table>")
        sb.AppendLine("    <div class='divider'></div>")
        sb.AppendLine("    <table class='totals-table'>")
        sb.AppendLine($"      <tr><td>Subtotal:</td><td class='val'>₱{subTotal:N2}</td></tr>")

        If discount > 0 Then
            sb.AppendLine($"      <tr><td>Discount:</td><td class='val'>-₱{discount:N2}</td></tr>")
        End If

        sb.AppendLine($"      <tr class='grand-total'><td><strong>TOTAL:</strong></td><td class='val'>₱{totalAmount:N2}</td></tr>")
        sb.AppendLine($"      <tr><td>Tendered:</td><td class='val'>₱{tendered:N2}</td></tr>")
        sb.AppendLine($"      <tr><td>Change:</td><td class='val'>₱{change:N2}</td></tr>")
        sb.AppendLine("    </table>")
        sb.AppendLine("    <div class='divider'></div>")
        sb.AppendLine("    <div class='footer'>")
        sb.AppendLine("      <p>Thank you for your purchase!</p>")
        sb.AppendLine("      <p>Please keep this receipt for your records.</p>")
        sb.AppendLine("    </div>")
        sb.AppendLine("  </div>")
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

        If File.Exists(chromePath) Then
            Process.Start(chromePath, $"""{filePath}""")
        ElseIf File.Exists(chromeX86Path) Then
            Process.Start(chromeX86Path, $"""{filePath}""")
        Else
            Dim psi As New ProcessStartInfo() With {
                .FileName = filePath,
                .UseShellExecute = True
            }
            Process.Start(psi)
        End If
    End Sub

End Module
