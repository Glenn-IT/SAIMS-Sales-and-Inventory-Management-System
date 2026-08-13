Public Class ForgotPasswordForm

    Private Const MAX_ANSWER_ATTEMPTS As Integer = 5

    Private _username As String = String.Empty
    Private _userID As Integer
    Private _correctQuestion As String = String.Empty
    Private _answerHash As String = String.Empty
    Private _answerAttempts As Integer = 0

    Private Sub ForgotPasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbQuestion.Items.Clear()
        For Each q As String In Constants.SecurityQuestions
            If q <> "Other" Then
                cmbQuestion.Items.Add(q)
            End If
        Next
        txtUsername.Focus()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim username As String = InputHelper.SanitizeInput(txtUsername.Text)
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Please enter your username.", "Forgot Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim dt As DataTable = UserRepository.GetForPasswordReset(username)

            If dt.Rows.Count = 0 Then
                ShowNoRecoveryMessage()
                Return
            End If

            Dim row As DataRow = dt.Rows(0)

            If row("Status").ToString() = Constants.STATUS_INACTIVE Then
                MessageBox.Show("Your account has been deactivated. Please contact the administrator.",
                                "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If IsDBNull(row("SecurityQuestion")) OrElse String.IsNullOrWhiteSpace(row("SecurityQuestion").ToString()) Then
                ShowNoRecoveryMessage()
                Return
            End If

            _username = username
            _userID = CInt(row("UserID"))
            _correctQuestion = row("SecurityQuestion").ToString()
            _answerHash = row("SecurityAnswerHash").ToString()
            _answerAttempts = 0

            cmbQuestion.SelectedIndex = -1
            ShowStep2()
            cmbQuestion.Focus()

        Catch ex As Exception
            MessageBox.Show("A database error occurred. Please check your connection." &
                            Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowNoRecoveryMessage()
        MessageBox.Show("No recoverable account was found for that username." &
                        Environment.NewLine & "Please contact your administrator.",
                        "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ShowStep2()
        lblStep1Info.Visible = False
        lblUsername.Visible = False
        txtUsername.Visible = False
        btnNext.Visible = False
        btnCancelStep1.Visible = False

        If Not String.IsNullOrWhiteSpace(_correctQuestion) AndAlso Not cmbQuestion.Items.Contains(_correctQuestion) Then
            cmbQuestion.Items.Add(_correctQuestion)
        End If

        lblQuestionPrompt.Visible = True
        cmbQuestion.Visible = True
        lblAnswer.Visible = True
        txtAnswer.Visible = True
        lblNewPassword.Visible = True
        txtNewPassword.Visible = True
        lblConfirmPassword.Visible = True
        txtConfirmPassword.Visible = True
        btnReset.Visible = True
        btnBack.Visible = True
    End Sub

    Private Sub ShowStep1()
        lblQuestionPrompt.Visible = False
        cmbQuestion.SelectedIndex = -1
        cmbQuestion.Visible = False
        lblAnswer.Visible = False
        txtAnswer.Clear()
        txtAnswer.Visible = False
        lblNewPassword.Visible = False
        txtNewPassword.Clear()
        txtNewPassword.Visible = False
        lblConfirmPassword.Visible = False
        txtConfirmPassword.Clear()
        txtConfirmPassword.Visible = False
        btnReset.Visible = False
        btnBack.Visible = False

        lblStep1Info.Visible = True
        lblUsername.Visible = True
        txtUsername.Visible = True
        btnNext.Visible = True
        btnCancelStep1.Visible = True
        txtUsername.Focus()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ShowStep1()
    End Sub

    Private Sub btnCancelStep1_Click(sender As Object, e As EventArgs) Handles btnCancelStep1.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim answer As String = txtAnswer.Text
        Dim newPassword As String = txtNewPassword.Text
        Dim confirmPassword As String = txtConfirmPassword.Text

        If cmbQuestion.SelectedIndex = -1 Then
            MessageBox.Show("Please select your security question.", "Forgot Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(answer) Then
            MessageBox.Show("Please answer the security question.", "Forgot Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(newPassword) OrElse newPassword.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If newPassword <> confirmPassword Then
            MessageBox.Show("Passwords do not match.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim questionMatches As Boolean = String.Equals(cmbQuestion.SelectedItem?.ToString(), _correctQuestion,
                                                        StringComparison.Ordinal)

        If Not questionMatches OrElse Not PasswordHelper.VerifyAnswer(answer, _answerHash) Then
            _answerAttempts += 1
            ActivityLogger.Log(_username, Constants.LOG_FAILED,
                               "Forgot-password attempt failed - wrong security question or answer.")

            If _answerAttempts >= MAX_ANSWER_ATTEMPTS Then
                MessageBox.Show("Too many incorrect attempts. Please try again later.",
                                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return
            End If

            MessageBox.Show("The selected question or answer is incorrect.", "Forgot Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAnswer.Clear()
            txtAnswer.Focus()
            Return
        End If

        Try
            Dim hash As String = PasswordHelper.HashPassword(newPassword)
            UserRepository.UpdatePassword(_userID, hash)
            ActivityLogger.Log(_username, Constants.LOG_SUCCESS,
                               "Password reset via security question.")

            MessageBox.Show("Your password has been reset. You can now log in.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Failed to reset password." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
