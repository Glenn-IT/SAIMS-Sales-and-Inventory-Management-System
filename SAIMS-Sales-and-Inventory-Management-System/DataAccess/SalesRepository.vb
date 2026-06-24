Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module SalesRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT s.SaleID, s.ReceiptNo, u.FullName AS Cashier,
                        s.SaleDate, s.SubTotal, s.Discount, s.TotalAmount,
                        s.AmountTendered, s.Change, s.PaymentMethod, s.Status
                 FROM tbl_Sales s
                 INNER JOIN tbl_Users u ON s.CashierID = u.UserID
                 ORDER BY s.SaleDate DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByReceiptNo(receiptNo As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT s.SaleID, s.ReceiptNo, u.FullName AS Cashier,
                        s.SaleDate, s.SubTotal, s.Discount, s.TotalAmount,
                        s.AmountTendered, s.Change, s.PaymentMethod, s.Status
                 FROM tbl_Sales s
                 INNER JOIN tbl_Users u ON s.CashierID = u.UserID
                 WHERE s.ReceiptNo = @receiptNo", con)
            cmd.Parameters.AddWithValue("@receiptNo", receiptNo)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByDateRange(dateFrom As DateTime, dateTo As DateTime) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT s.SaleID, s.ReceiptNo, u.FullName AS Cashier,
                        s.SaleDate, s.TotalAmount, s.PaymentMethod, s.Status
                 FROM tbl_Sales s
                 INNER JOIN tbl_Users u ON s.CashierID = u.UserID
                 WHERE CAST(s.SaleDate AS DATE) BETWEEN @from AND @to
                 ORDER BY s.SaleDate DESC", con)
            cmd.Parameters.AddWithValue("@from", dateFrom.Date)
            cmd.Parameters.AddWithValue("@to",   dateTo.Date)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetSalesSummary(dateFrom As DateTime, dateTo As DateTime) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT COUNT(*)          AS TotalTransactions,
                        ISNULL(SUM(TotalAmount), 0) AS TotalRevenue,
                        ISNULL(AVG(TotalAmount), 0) AS AverageSale
                 FROM tbl_Sales
                 WHERE CAST(SaleDate AS DATE) BETWEEN @from AND @to
                   AND Status = 'Completed'", con)
            cmd.Parameters.AddWithValue("@from", dateFrom.Date)
            cmd.Parameters.AddWithValue("@to",   dateTo.Date)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetTopSelling(dateFrom As DateTime, dateTo As DateTime,
                                  Optional topN As Integer = 5) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
               $"SELECT TOP {topN} p.ProductName,
                        SUM(si.Quantity) AS TotalSold,
                        SUM(si.LineTotal) AS TotalRevenue
                 FROM tbl_SaleItems si
                 INNER JOIN tbl_Products p ON si.ProductID = p.ProductID
                 INNER JOIN tbl_Sales    s ON si.SaleID    = s.SaleID
                 WHERE CAST(s.SaleDate AS DATE) BETWEEN @from AND @to
                   AND s.Status = 'Completed'
                 GROUP BY p.ProductName
                 ORDER BY TotalSold DESC", con)
            cmd.Parameters.AddWithValue("@from", dateFrom.Date)
            cmd.Parameters.AddWithValue("@to",   dateTo.Date)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GenerateReceiptNo() As String
        Return "RCP-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
    End Function

    Public Function Insert(receiptNo As String, cashierID As Integer,
                           subTotal As Decimal, discount As Decimal, totalAmount As Decimal,
                           amountTendered As Decimal, change As Decimal,
                           paymentMethod As String) As Integer
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Sales
                    (ReceiptNo, CashierID, SubTotal, Discount, TotalAmount,
                     AmountTendered, Change, PaymentMethod, Status)
                 VALUES
                    (@receiptNo, @cashierID, @subTotal, @discount, @totalAmount,
                     @tendered, @change, @payment, @status);
                 SELECT SCOPE_IDENTITY();", con)
                cmd.Parameters.AddWithValue("@receiptNo",  receiptNo)
                cmd.Parameters.AddWithValue("@cashierID",  cashierID)
                cmd.Parameters.AddWithValue("@subTotal",   subTotal)
                cmd.Parameters.AddWithValue("@discount",   discount)
                cmd.Parameters.AddWithValue("@totalAmount",totalAmount)
                cmd.Parameters.AddWithValue("@tendered",   amountTendered)
                cmd.Parameters.AddWithValue("@change",     change)
                cmd.Parameters.AddWithValue("@payment",    paymentMethod)
                cmd.Parameters.AddWithValue("@status",     Constants.SALE_COMPLETED)
                Return CInt(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Sub Void(saleID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Sales SET Status = @status WHERE SaleID = @id", con)
                cmd.Parameters.AddWithValue("@status", Constants.SALE_VOIDED)
                cmd.Parameters.AddWithValue("@id",     saleID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
