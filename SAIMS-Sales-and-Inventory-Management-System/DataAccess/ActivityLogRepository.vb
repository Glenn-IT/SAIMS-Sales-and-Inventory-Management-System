Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module ActivityLogRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT LogID, Username, LogDate, Result, Description
                 FROM tbl_ActivityLogs
                 ORDER BY LogDate DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub Insert(username As String, result As String, description As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_ActivityLogs (Username, Result, Description)
                 VALUES (@username, @result, @description)", con)
                cmd.Parameters.AddWithValue("@username",    username)
                cmd.Parameters.AddWithValue("@result",      result)
                cmd.Parameters.AddWithValue("@description", description)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
