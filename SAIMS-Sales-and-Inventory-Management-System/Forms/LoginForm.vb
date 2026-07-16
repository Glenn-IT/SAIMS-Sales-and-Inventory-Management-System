Imports Microsoft.Data.SqlClient

Public Class LoginForm

    Private Const MAX_ATTEMPTS   As Integer = 3
    Private Const LOCKOUT_SECONDS As Integer = 30

    Private _failedAttempts As Integer = 0
    Private _lockoutSeconds As Integer = 0
    Private WithEvents _lockTimer As New Timer() With {.Interval = 1000}

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblBrandFooter.Text = "SAIMS " & UnderConstructionForm.CURRENT_VERSION
        CheckDatabaseConnection()
        txtUsername.Focus()
    End Sub

    Private Sub CheckDatabaseConnection()
        Try
            Using conn As New SqlConnection(dbconstring.Connection)
                conn.Open()
            End Using
        Catch ex As Exception
            MessageBox.Show("Cannot connect to the database." &
                            Environment.NewLine & Environment.NewLine &
                            ex.Message & Environment.NewLine & Environment.NewLine &
                            "Please check config.txt and ensure SQL Server is running.",
                            "Database Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If _lockTimer.Enabled Then Return

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
                ActivityLogger.Log(username, Constants.LOG_FAILED, "Login failed - username not found.")
                txtPassword.Clear()
                txtUsername.Focus()
                RecordFailedAttempt(username)
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
                ActivityLogger.Log(username, Constants.LOG_FAILED, "Login failed - wrong password.")
                txtPassword.Clear()
                txtPassword.Focus()
                RecordFailedAttempt(username)
                Return
            End If

            ' Reset lockout on successful login
            _failedAttempts = 0
            lblStatus.Text = ""

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

    Private Sub RecordFailedAttempt(username As String)
        _failedAttempts += 1

        If _failedAttempts >= MAX_ATTEMPTS Then
            _lockoutSeconds     = LOCKOUT_SECONDS
            txtUsername.Enabled = False
            txtPassword.Enabled = False
            btnLogin.Enabled    = False
            lblStatus.ForeColor = Color.FromArgb(231, 76, 60)
            lblStatus.Text      = $"Too many failed attempts. Try again in {_lockoutSeconds}s."
            btnLogin.Text       = $"Locked ({_lockoutSeconds}s)"
            _lockTimer.Start()
            ActivityLogger.Log(username, Constants.LOG_WARNING,
                               $"Account locked out after {MAX_ATTEMPTS} failed attempts.")
        Else
            Dim remaining As Integer = MAX_ATTEMPTS - _failedAttempts
            lblStatus.ForeColor = Color.FromArgb(230, 126, 34)
            lblStatus.Text      = $"Invalid username or password. {remaining} attempt{If(remaining = 1, "", "s")} remaining."
        End If
    End Sub

    Private Sub _lockTimer_Tick(sender As Object, e As EventArgs) Handles _lockTimer.Tick
        _lockoutSeconds -= 1
        If _lockoutSeconds <= 0 Then
            _lockTimer.Stop()
            _failedAttempts     = 0
            txtUsername.Enabled = True
            txtPassword.Enabled = True
            btnLogin.Enabled    = True
            btnLogin.Text       = "Login"
            lblStatus.Text      = ""
            txtUsername.Focus()
        Else
            lblStatus.Text = $"Too many failed attempts. Try again in {_lockoutSeconds}s."
            btnLogin.Text  = $"Locked ({_lockoutSeconds}s)"
        End If
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

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = ChrW(0)
        Else
            txtPassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub lnkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgotPassword.LinkClicked
        Using forgotForm As New ForgotPasswordForm()
            forgotForm.ShowDialog()
        End Using
    End Sub

End Class
