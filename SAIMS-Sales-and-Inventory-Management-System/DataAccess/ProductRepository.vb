Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module ProductRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.ProductID, p.Barcode, p.ProductName,
                        p.CategoryID, c.CategoryName, p.Unit, p.Price, p.Stock, p.LowStockQty, p.Status, p.CreatedAt,
                        CASE
                            WHEN p.Stock = 0             THEN 'Out of Stock'
                            WHEN p.Stock <= p.LowStockQty THEN 'Low Stock'
                            ELSE 'Available'
                        END AS StockStatus
                 FROM tbl_Products p
                 INNER JOIN tbl_Categories c ON p.CategoryID = c.CategoryID
                 ORDER BY p.ProductName ASC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByBarcode(barcode As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.ProductID, p.Barcode, p.ProductName, p.Unit,
                        p.Price, p.Stock, p.Status, p.CreatedAt
                 FROM tbl_Products p
                 WHERE p.Barcode = @barcode AND p.Status = @status", con)
            cmd.Parameters.AddWithValue("@barcode", barcode)
            cmd.Parameters.AddWithValue("@status",  Constants.STATUS_ACTIVE)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByID(productID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.ProductID, p.Barcode, p.ProductName,
                        p.CategoryID, p.Unit, p.Price, p.Stock, p.LowStockQty, p.Status, p.CreatedAt
                 FROM tbl_Products p
                 WHERE p.ProductID = @id", con)
            cmd.Parameters.AddWithValue("@id", productID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetLowStock() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.ProductID, p.Barcode, p.ProductName, p.Unit, p.Stock, p.LowStockQty
                 FROM tbl_Products p
                 WHERE p.Stock <= p.LowStockQty AND p.Stock > 0
                   AND p.Status = @status
                 ORDER BY p.Stock ASC", con)
            cmd.Parameters.AddWithValue("@status", Constants.STATUS_ACTIVE)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function BarcodeExists(barcode As String, Optional excludeID As Integer = 0) As Boolean
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT COUNT(*) FROM tbl_Products
                 WHERE Barcode = @barcode AND ProductID <> @excludeID", con)
            cmd.Parameters.AddWithValue("@barcode",   barcode)
            cmd.Parameters.AddWithValue("@excludeID", excludeID)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Public Sub Insert(barcode As String, productName As String, categoryID As Integer, unit As String,
                      price As Decimal, stock As Integer, lowStockQty As Integer, Optional dateAdded As Nullable(Of DateTime) = Nothing)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Products (Barcode, ProductName, CategoryID, Unit, Price, Stock, LowStockQty, Status, CreatedAt)
                 VALUES (@barcode, @name, @catID, @unit, @price, @stock, @lowStock, @status, @createdAt)", con)
                cmd.Parameters.AddWithValue("@barcode",   barcode)
                cmd.Parameters.AddWithValue("@name",      productName)
                cmd.Parameters.AddWithValue("@catID",     categoryID)
                cmd.Parameters.AddWithValue("@unit",      If(String.IsNullOrWhiteSpace(unit), "pcs", unit))
                cmd.Parameters.AddWithValue("@price",     price)
                cmd.Parameters.AddWithValue("@stock",     stock)
                cmd.Parameters.AddWithValue("@lowStock",  lowStockQty)
                cmd.Parameters.AddWithValue("@status",    Constants.STATUS_ACTIVE)
                cmd.Parameters.AddWithValue("@createdAt", If(dateAdded.HasValue, dateAdded.Value, DateTime.Now))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(productID As Integer, barcode As String, productName As String,
                      categoryID As Integer, unit As String, price As Decimal, lowStockQty As Integer, status As String,
                      Optional dateAdded As Nullable(Of DateTime) = Nothing)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim query As String = "UPDATE tbl_Products SET Barcode = @barcode, ProductName = @name, CategoryID = @catID, Unit = @unit, Price = @price, LowStockQty = @lowStock, Status = @status"
            If dateAdded.HasValue Then
                query &= ", CreatedAt = @createdAt"
            End If
            query &= " WHERE ProductID = @id"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@barcode",  barcode)
                cmd.Parameters.AddWithValue("@name",     productName)
                cmd.Parameters.AddWithValue("@catID",    categoryID)
                cmd.Parameters.AddWithValue("@unit",     If(String.IsNullOrWhiteSpace(unit), "pcs", unit))
                cmd.Parameters.AddWithValue("@price",    price)
                cmd.Parameters.AddWithValue("@lowStock", lowStockQty)
                cmd.Parameters.AddWithValue("@status",   status)
                If dateAdded.HasValue Then
                    cmd.Parameters.AddWithValue("@createdAt", dateAdded.Value)
                End If
                cmd.Parameters.AddWithValue("@id",       productID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateStock(productID As Integer, newStock As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Products SET Stock = @stock WHERE ProductID = @id", con)
                cmd.Parameters.AddWithValue("@stock", newStock)
                cmd.Parameters.AddWithValue("@id",    productID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DeductStock(productID As Integer, quantity As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Products SET Stock = Stock - @qty WHERE ProductID = @id", con)
                cmd.Parameters.AddWithValue("@qty", quantity)
                cmd.Parameters.AddWithValue("@id",  productID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub AddStock(productID As Integer, quantity As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Products SET Stock = Stock + @qty WHERE ProductID = @id", con)
                cmd.Parameters.AddWithValue("@qty", quantity)
                cmd.Parameters.AddWithValue("@id",  productID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(productID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_Products WHERE ProductID = @id", con)
                cmd.Parameters.AddWithValue("@id", productID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SearchActiveProducts(keyword As String) As List(Of ProductSearchResult)
        Dim list As New List(Of ProductSearchResult)()
        If String.IsNullOrWhiteSpace(keyword) Then Return list

        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT TOP 20 p.ProductID, p.Barcode, p.ProductName, p.Unit,
                        p.Price, p.Stock
                 FROM tbl_Products p
                 WHERE (p.ProductName LIKE @kw OR p.Barcode LIKE @kw)
                   AND p.Status = @status
                 ORDER BY p.ProductName ASC", con)
            cmd.Parameters.AddWithValue("@kw", "%" & keyword.Trim() & "%")
            cmd.Parameters.AddWithValue("@status", Constants.STATUS_ACTIVE)
            Using reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(New ProductSearchResult() With {
                        .ProductID   = reader.GetInt32(0),
                        .Barcode     = reader.GetString(1),
                        .ProductName = reader.GetString(2),
                        .Unit        = If(reader.IsDBNull(3), "pcs", reader.GetString(3)),
                        .Price       = reader.GetDecimal(4),
                        .Stock       = reader.GetInt32(5)
                    })
                End While
            End Using
        End Using
        Return list
    End Function

    ''' <summary>
    ''' Retrieves products filtered by a date range based on product creation date or inventory movement activity.
    ''' </summary>
    Public Function GetByDateRange(dateFrom As DateTime, dateTo As DateTime) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.ProductID, p.Barcode, p.ProductName,
                        p.CategoryID, ISNULL(c.CategoryName, 'General') AS CategoryName,
                        p.Unit, p.Price, p.Stock, p.LowStockQty, p.Status, p.CreatedAt,
                        CASE
                            WHEN p.Stock = 0              THEN 'Out of Stock'
                            WHEN p.Stock <= p.LowStockQty THEN 'Low Stock'
                            ELSE 'Available'
                        END AS StockStatus
                 FROM tbl_Products p
                 LEFT JOIN tbl_Categories c ON p.CategoryID = c.CategoryID
                 WHERE CAST(p.CreatedAt AS DATE) BETWEEN @from AND @to
                    OR p.ProductID IN (
                        SELECT sm.ProductID
                        FROM tbl_StockMovements sm
                        WHERE CAST(sm.MovementDate AS DATE) BETWEEN @from AND @to
                    )
                 ORDER BY p.ProductName ASC", con)
            cmd.Parameters.AddWithValue("@from", dateFrom.Date)
            cmd.Parameters.AddWithValue("@to", dateTo.Date)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Returns inventory records enriched with period movements (Stock In, Units Sold, and Sales Revenue).
    ''' </summary>
    Public Function GetInventoryReport(dateFrom As DateTime, dateTo As DateTime) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim query As String =
                "SELECT p.ProductID, p.Barcode, p.ProductName,
                        ISNULL(c.CategoryName, 'General') AS CategoryName,
                        p.Unit, p.Price, p.Stock, p.Stock AS CurrentStock, p.LowStockQty,
                        ISNULL(m_in.StockInQty, 0) AS StockInQty,
                        ISNULL(m_sold.SoldQty, 0) AS SoldQty,
                        ISNULL(m_sold.SalesRevenue, 0) AS SalesRevenue,
                        CASE
                            WHEN p.Stock = 0 THEN 'Out of Stock'
                            WHEN p.Stock <= p.LowStockQty THEN 'Low Stock'
                            ELSE 'Available'
                        END AS StockStatus
                 FROM tbl_Products p
                 LEFT JOIN tbl_Categories c ON p.CategoryID = c.CategoryID
                 LEFT JOIN (
                     SELECT ProductID, SUM(Quantity) AS StockInQty
                     FROM tbl_StockMovements
                     WHERE MovementType = 'StockIn' AND CAST(MovementDate AS DATE) BETWEEN @from AND @to
                     GROUP BY ProductID
                 ) m_in ON p.ProductID = m_in.ProductID
                 LEFT JOIN (
                     SELECT si.ProductID, SUM(si.Quantity) AS SoldQty, SUM(si.LineTotal) AS SalesRevenue
                     FROM tbl_SaleItems si
                     INNER JOIN tbl_Sales s ON si.SaleID = s.SaleID
                     WHERE s.Status = 'Completed' AND CAST(s.SaleDate AS DATE) BETWEEN @from AND @to
                     GROUP BY si.ProductID
                 ) m_sold ON p.ProductID = m_sold.ProductID
                 ORDER BY (ISNULL(m_sold.SoldQty, 0) + ISNULL(m_in.StockInQty, 0)) DESC, p.ProductName ASC"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@from", dateFrom.Date)
                cmd.Parameters.AddWithValue("@to", dateTo.Date)
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Returns aggregated summary metrics for a specific report period (Revenue, Transactions, Units Sold, Stock In, and Current Inventory).
    ''' </summary>
    Public Function GetPeriodSummaryMetrics(dateFrom As DateTime, dateTo As DateTime) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim query As String =
                "SELECT 
                    (SELECT ISNULL(SUM(TotalAmount), 0) FROM tbl_Sales WHERE Status = 'Completed' AND CAST(SaleDate AS DATE) BETWEEN @from AND @to) AS TotalRevenue,
                    (SELECT COUNT(*) FROM tbl_Sales WHERE Status = 'Completed' AND CAST(SaleDate AS DATE) BETWEEN @from AND @to) AS TotalTransactions,
                    (SELECT ISNULL(SUM(si.Quantity), 0) FROM tbl_SaleItems si INNER JOIN tbl_Sales s ON si.SaleID = s.SaleID WHERE s.Status = 'Completed' AND CAST(s.SaleDate AS DATE) BETWEEN @from AND @to) AS UnitsSold,
                    (SELECT ISNULL(SUM(Quantity), 0) FROM tbl_StockMovements WHERE MovementType = 'StockIn' AND CAST(MovementDate AS DATE) BETWEEN @from AND @to) AS StockInQty,
                    (SELECT ISNULL(SUM(Stock), 0) FROM tbl_Products) AS TotalCurrentStock,
                    (SELECT COUNT(*) FROM tbl_Products WHERE Stock <= LowStockQty AND Stock > 0) AS LowStockCount,
                    (SELECT COUNT(*) FROM tbl_Products WHERE Stock = 0) AS OutOfStockCount,
                    (SELECT COUNT(*) FROM tbl_Products) AS TotalProducts"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@from", dateFrom.Date)
                cmd.Parameters.AddWithValue("@to", dateTo.Date)
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

End Module

Public Class ProductSearchResult
    Public Property ProductID As Integer
    Public Property Barcode As String
    Public Property ProductName As String
    Public Property Price As Decimal
    Public Property Stock As Integer
    Public Property Unit As String

    Public Overrides Function ToString() As String
        Return $"{ProductName}  —  ₱{Price:N2}  [Stock: {Stock} {Unit}]  (Barcode: {Barcode})"
    End Function
End Class
