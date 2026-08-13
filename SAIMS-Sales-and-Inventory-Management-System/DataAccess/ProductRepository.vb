Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module ProductRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.ProductID, p.Barcode, p.ProductName,
                        p.CategoryID, c.CategoryName, p.Unit, p.Price, p.Stock, p.LowStockQty, p.Status,
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
                        p.Price, p.Stock, p.Status
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
                        p.CategoryID, p.Unit, p.Price, p.Stock, p.LowStockQty, p.Status
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
                      price As Decimal, stock As Integer, lowStockQty As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Products (Barcode, ProductName, CategoryID, Unit, Price, Stock, LowStockQty, Status)
                 VALUES (@barcode, @name, @catID, @unit, @price, @stock, @lowStock, @status)", con)
                cmd.Parameters.AddWithValue("@barcode",  barcode)
                cmd.Parameters.AddWithValue("@name",     productName)
                cmd.Parameters.AddWithValue("@catID",    categoryID)
                cmd.Parameters.AddWithValue("@unit",     If(String.IsNullOrWhiteSpace(unit), "pcs", unit))
                cmd.Parameters.AddWithValue("@price",    price)
                cmd.Parameters.AddWithValue("@stock",    stock)
                cmd.Parameters.AddWithValue("@lowStock", lowStockQty)
                cmd.Parameters.AddWithValue("@status",   Constants.STATUS_ACTIVE)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(productID As Integer, barcode As String, productName As String,
                      categoryID As Integer, unit As String, price As Decimal, lowStockQty As Integer, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Products
                 SET Barcode = @barcode, ProductName = @name, CategoryID = @catID, Unit = @unit,
                     Price = @price, LowStockQty = @lowStock, Status = @status
                 WHERE ProductID = @id", con)
                cmd.Parameters.AddWithValue("@barcode",  barcode)
                cmd.Parameters.AddWithValue("@name",     productName)
                cmd.Parameters.AddWithValue("@catID",    categoryID)
                cmd.Parameters.AddWithValue("@unit",     If(String.IsNullOrWhiteSpace(unit), "pcs", unit))
                cmd.Parameters.AddWithValue("@price",    price)
                cmd.Parameters.AddWithValue("@lowStock", lowStockQty)
                cmd.Parameters.AddWithValue("@status",   status)
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

End Module
