Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module StockMovementRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT sm.MovementID, p.Barcode, p.ProductName, p.Stock AS TotalQuantity, sm.MovementType,
                        sm.Quantity, sm.Reason, sm.MovementDate, u.FullName AS CreatedBy
                 FROM tbl_StockMovements sm
                 INNER JOIN tbl_Products p ON sm.ProductID = p.ProductID
                 INNER JOIN tbl_Users u    ON sm.CreatedBy = u.UserID
                 ORDER BY sm.MovementDate DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Returns distinct products that have stock-in movements with aggregated summary info.
    ''' </summary>
    Public Function GetStockInSummary(Optional filterDate As Nullable(Of DateTime) = Nothing) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim query As String =
                "SELECT p.ProductID, p.Barcode, p.ProductName, 
                        ISNULL(c.CategoryName, 'Uncategorized') AS CategoryName,
                        p.Stock AS CurrentStock,
                        SUM(sm.Quantity) AS TotalStockInQty,
                        MAX(sm.MovementDate) AS LastStockInDate,
                        COUNT(sm.MovementID) AS StockInCount
                 FROM tbl_StockMovements sm
                 INNER JOIN tbl_Products p ON sm.ProductID = p.ProductID
                 LEFT JOIN tbl_Categories c ON p.CategoryID = c.CategoryID
                 WHERE sm.MovementType = @movementType"

            If filterDate.HasValue Then
                query &= " AND CAST(sm.MovementDate AS DATE) = @filterDate"
            End If

            query &= " GROUP BY p.ProductID, p.Barcode, p.ProductName, c.CategoryName, p.Stock
                       ORDER BY MAX(sm.MovementDate) DESC"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@movementType", Constants.MOVEMENT_STOCKIN)
                If filterDate.HasValue Then
                    cmd.Parameters.AddWithValue("@filterDate", filterDate.Value.Date)
                End If
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Returns all Stock In movement records for a specific product including dates, quantities, remarks, and user.
    ''' </summary>
    Public Function GetStockInHistoryByProduct(productID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT sm.MovementID, sm.Quantity, sm.Reason, sm.MovementDate,
                        ISNULL(u.FullName, u.Username) AS CreatedBy
                 FROM tbl_StockMovements sm
                 INNER JOIN tbl_Users u ON sm.CreatedBy = u.UserID
                 WHERE sm.ProductID = @productID AND sm.MovementType = @movementType
                 ORDER BY sm.MovementDate DESC", con)
            cmd.Parameters.AddWithValue("@productID", productID)
            cmd.Parameters.AddWithValue("@movementType", Constants.MOVEMENT_STOCKIN)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByProduct(productID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT sm.MovementID, sm.MovementType, sm.Quantity,
                        sm.Reason, sm.MovementDate, u.FullName AS CreatedBy
                 FROM tbl_StockMovements sm
                 INNER JOIN tbl_Users u ON sm.CreatedBy = u.UserID
                 WHERE sm.ProductID = @productID
                 ORDER BY sm.MovementDate DESC", con)
            cmd.Parameters.AddWithValue("@productID", productID)
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
                "SELECT sm.MovementID, p.Barcode, p.ProductName, p.Stock AS TotalQuantity, sm.MovementType,
                        sm.Quantity, sm.Reason, sm.MovementDate, u.FullName AS CreatedBy
                 FROM tbl_StockMovements sm
                 INNER JOIN tbl_Products p ON sm.ProductID = p.ProductID
                 INNER JOIN tbl_Users u    ON sm.CreatedBy = u.UserID
                 WHERE CAST(sm.MovementDate AS DATE) BETWEEN @from AND @to
                 ORDER BY sm.MovementDate DESC", con)
            cmd.Parameters.AddWithValue("@from", dateFrom.Date)
            cmd.Parameters.AddWithValue("@to",   dateTo.Date)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub Insert(productID As Integer, movementType As String,
                      quantity As Integer, reason As String, createdBy As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_StockMovements
                    (ProductID, MovementType, Quantity, Reason, CreatedBy)
                 VALUES
                    (@productID, @type, @qty, @reason, @createdBy)", con)
                cmd.Parameters.AddWithValue("@productID", productID)
                cmd.Parameters.AddWithValue("@type",      movementType)
                cmd.Parameters.AddWithValue("@qty",       quantity)
                cmd.Parameters.AddWithValue("@reason",    If(String.IsNullOrWhiteSpace(reason), DBNull.Value, CObj(reason)))
                cmd.Parameters.AddWithValue("@createdBy", createdBy)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
