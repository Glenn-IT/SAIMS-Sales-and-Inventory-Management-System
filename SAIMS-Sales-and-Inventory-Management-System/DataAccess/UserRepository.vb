Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module UserRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT UserID, Username, FullName, UserType, Status, CreatedAt
                 FROM tbl_Users
                 ORDER BY FullName ASC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByUsername(username As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT UserID, Username, PasswordHash, FullName, UserType, Status
                 FROM tbl_Users
                 WHERE Username = @username", con)
            cmd.Parameters.AddWithValue("@username", username)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByID(userID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT UserID, Username, FullName, UserType, Status
                 FROM tbl_Users
                 WHERE UserID = @id", con)
            cmd.Parameters.AddWithValue("@id", userID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function UsernameExists(username As String, Optional excludeID As Integer = 0) As Boolean
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT COUNT(*) FROM tbl_Users
                 WHERE Username = @username AND UserID <> @excludeID", con)
            cmd.Parameters.AddWithValue("@username",  username)
            cmd.Parameters.AddWithValue("@excludeID", excludeID)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Public Sub Insert(username As String, passwordHash As String, fullName As String, userType As String,
                      securityQuestion As String, securityAnswerHash As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Users (Username, PasswordHash, FullName, UserType, Status, SecurityQuestion, SecurityAnswerHash)
                 VALUES (@username, @hash, @fullName, @userType, @status, @secQuestion, @secAnswerHash)", con)
                cmd.Parameters.AddWithValue("@username",      username)
                cmd.Parameters.AddWithValue("@hash",          passwordHash)
                cmd.Parameters.AddWithValue("@fullName",      fullName)
                cmd.Parameters.AddWithValue("@userType",      userType)
                cmd.Parameters.AddWithValue("@status",        Constants.STATUS_ACTIVE)
                cmd.Parameters.AddWithValue("@secQuestion",    securityQuestion)
                cmd.Parameters.AddWithValue("@secAnswerHash",  securityAnswerHash)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(userID As Integer, fullName As String, userType As String, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users
                 SET FullName = @fullName, UserType = @userType, Status = @status
                 WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@fullName", fullName)
                cmd.Parameters.AddWithValue("@userType", userType)
                cmd.Parameters.AddWithValue("@status",   status)
                cmd.Parameters.AddWithValue("@id",       userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function GetForPasswordReset(username As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT UserID, Username, Status, SecurityQuestion, SecurityAnswerHash
                 FROM tbl_Users
                 WHERE Username = @username", con)
            cmd.Parameters.AddWithValue("@username", username)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub SetSecurityQuestion(userID As Integer, question As String, answerHash As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET SecurityQuestion = @question, SecurityAnswerHash = @answerHash
                 WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@question",   question)
                cmd.Parameters.AddWithValue("@answerHash", answerHash)
                cmd.Parameters.AddWithValue("@id",         userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdatePassword(userID As Integer, newPasswordHash As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET PasswordHash = @hash WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@hash", newPasswordHash)
                cmd.Parameters.AddWithValue("@id",   userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(userID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_Users WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
