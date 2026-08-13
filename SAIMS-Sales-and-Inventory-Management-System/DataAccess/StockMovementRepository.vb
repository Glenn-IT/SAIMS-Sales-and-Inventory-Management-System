Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module StockMovementRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT sm.MovementID, p.Barcode, p.ProductName, sm.MovementType,
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
                "SELECT sm.MovementID, p.Barcode, p.ProductName, sm.MovementType,
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
