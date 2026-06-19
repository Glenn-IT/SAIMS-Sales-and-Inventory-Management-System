Public Class LoginForm

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = InputHelper.SanitizeInput(txtUsername.Text)
        Dim password As String = txtPassword.Text

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter your username and password.",
                            "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        Try
            Dim dt As DataTable = UserRepository.GetByUsername(username)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Invalid username or password.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActivityLogger.Log(username, Constants.LOG_FAILED, "Login failed - username not found.")
                txtPassword.Clear()
                txtUsername.Focus()
                Return
            End If

            Dim row As DataRow = dt.Rows(0)

            If row("Status").ToString() = Constants.STATUS_INACTIVE Then
                MessageBox.Show("Your account has been deactivated. Please contact the administrator.",
                                "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActivityLogger.Log(username, Constants.LOG_FAILED, "Login failed - account inactive.")
                Return
            End If

            Dim storedHash As String = row("PasswordHash").ToString()

            If Not PasswordHelper.VerifyPassword(password, storedHash) Then
                MessageBox.Show("Invalid username or password.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActivityLogger.Log(username, Constants.LOG_FAILED, "Login failed - wrong password.")
                txtPassword.Clear()
                txtPassword.Focus()
                Return
            End If

            ' Populate session
            SessionManager.UserID   = CInt(row("UserID"))
            SessionManager.Username = row("Username").ToString()
            SessionManager.FullName = row("FullName").ToString()
            SessionManager.UserType = row("UserType").ToString()

            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS, "User logged in.")

            Dim mainDashboard As New MainDashboardForm()
            mainDashboard.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("A database error occurred. Please check your connection." &
                            Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then btnLogin_Click(sender, e)
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then txtPassword.Focus()
    End Sub

End Class
