Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module CategoryRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT CategoryID, CategoryName, Description, Status, CreatedAt
                 FROM tbl_Categories
                 ORDER BY CategoryName ASC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetActive() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT CategoryID, CategoryName
                 FROM tbl_Categories
                 WHERE Status = @status
                 ORDER BY CategoryName ASC", con)
            cmd.Parameters.AddWithValue("@status", Constants.STATUS_ACTIVE)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByID(categoryID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT CategoryID, CategoryName, Description, Status
                 FROM tbl_Categories
                 WHERE CategoryID = @id", con)
            cmd.Parameters.AddWithValue("@id", categoryID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function Exists(categoryName As String, Optional excludeID As Integer = 0) As Boolean
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT COUNT(*) FROM tbl_Categories
                 WHERE CategoryName = @name AND CategoryID <> @excludeID", con)
            cmd.Parameters.AddWithValue("@name",      categoryName)
            cmd.Parameters.AddWithValue("@excludeID", excludeID)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Public Sub Insert(categoryName As String, description As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Categories (CategoryName, Description, Status)
                 VALUES (@name, @desc, @status)", con)
                cmd.Parameters.AddWithValue("@name",   categoryName)
                cmd.Parameters.AddWithValue("@desc",   description)
                cmd.Parameters.AddWithValue("@status", Constants.STATUS_ACTIVE)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(categoryID As Integer, categoryName As String, description As String, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Categories
                 SET CategoryName = @name, Description = @desc, Status = @status
                 WHERE CategoryID = @id", con)
                cmd.Parameters.AddWithValue("@name",   categoryName)
                cmd.Parameters.AddWithValue("@desc",   description)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@id",     categoryID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(categoryID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_Categories WHERE CategoryID = @id", con)
                cmd.Parameters.AddWithValue("@id", categoryID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
