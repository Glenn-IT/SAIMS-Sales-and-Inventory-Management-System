Public Class UsersForm

    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.01
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE

        LoadUsers()

        ' Reset Password button — Admin only
        If SessionManager.UserType = Constants.USERTYPE_ADMIN Then
            Dim btnReset As New Button() With {
                .Text          = "Reset Password",
                .BackColor     = Color.FromArgb(142, 68, 173),
                .ForeColor     = Color.White,
                .FlatStyle     = FlatStyle.Flat,
                .Font          = New Font("Segoe UI", 9, FontStyle.Bold),
                .Location      = New Point(570, 50),
                .Size          = New Size(140, 35),
                .UseVisualStyleBackColor = False
            }
            AddHandler btnReset.Click, AddressOf btnResetPassword_Click
            panelTop.Controls.Add(btnReset)

            Dim btnSecQuestion As New Button() With {
                .Text          = "Set Security Question",
                .BackColor     = Color.FromArgb(52, 73, 94),
                .ForeColor     = Color.White,
                .FlatStyle     = FlatStyle.Flat,
                .Font          = New Font("Segoe UI", 9, FontStyle.Bold),
                .Location      = New Point(720, 50),
                .Size          = New Size(170, 35),
                .UseVisualStyleBackColor = False
            }
            AddHandler btnSecQuestion.Click, AddressOf btnSetSecurityQuestion_Click
            panelTop.Controls.Add(btnSecQuestion)
        End If
    End Sub

    ''' Prompts the admin to pick one of the fixed security questions and returns its text, or Nothing if cancelled.
    Private Function PromptForSecurityQuestion(title As String) As String
        Dim options As String() = Constants.SecurityQuestions
        Dim prompt As New Text.StringBuilder()
        prompt.AppendLine("Choose a security question by number:")
        For i As Integer = 0 To options.Length - 1
            prompt.AppendLine($"{i + 1}. {options(i)}")
        Next

        Dim choice As String = InputBox(prompt.ToString(), title)
        If String.IsNullOrWhiteSpace(choice) Then Return Nothing

        Dim index As Integer
        If Not Integer.TryParse(choice.Trim(), index) OrElse index < 1 OrElse index > options.Length Then
            MessageBox.Show("Please enter a valid question number.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End If

        Return options(index - 1)
    End Function

    Private Sub btnSetSecurityQuestion_Click(sender As Object, e As EventArgs)
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to set the security question for.", "Security Question",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim userID   As Integer = CInt(selectedRow.Cells(0).Value)
        Dim username As String  = selectedRow.Cells(1).Value.ToString()

        Dim question As String = PromptForSecurityQuestion("Set Security Question")
        If question Is Nothing Then Return

        Dim answer As String = InputBox("Answer:", "Set Security Question")
        If String.IsNullOrWhiteSpace(answer) Then
            MessageBox.Show("An answer is required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim answerHash As String = PasswordHelper.HashAnswer(answer)
            UserRepository.SetSecurityQuestion(userID, question, answerHash)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Security question set for user: {username} (ID: {userID})")
            MessageBox.Show("Security question saved.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to save security question." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetPassword_Click(sender As Object, e As EventArgs)
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to reset the password for.", "Reset Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim userID   As Integer = CInt(selectedRow.Cells(0).Value)
        Dim username As String  = selectedRow.Cells(1).Value.ToString()

        Dim newPassword As String = InputBox($"Enter new password for ""{username}"":", "Reset Password")
        If String.IsNullOrWhiteSpace(newPassword) Then Return

        If newPassword.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show($"Reset password for ""{username}""?",
                                      "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Dim hash As String = PasswordHelper.HashPassword(newPassword)
            UserRepository.UpdatePassword(userID, hash)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Password reset for user: {username} (ID: {userID})")
            MessageBox.Show("Password reset successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to reset password." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUsers()
        Try
            Dim dt As DataTable = UserRepository.GetAll()
            dgvUsers.Rows.Clear()

            For Each row As DataRow In dt.Rows
                dgvUsers.Rows.Add(
                    row("UserID").ToString(),
                    row("Username").ToString(),
                    row("UserType").ToString(),
                    row("Status").ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Failed to load users." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim username As String = InputHelper.SanitizeInput(InputBox("Username:", "Add User"))
        If String.IsNullOrWhiteSpace(username) Then Return

        Dim fullName As String = InputHelper.SanitizeInput(InputBox("Full Name:", "Add User"))
        If String.IsNullOrWhiteSpace(fullName) Then Return

        Dim password As String = InputBox("Password:", "Add User")
        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Password is required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If password.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim userType As String = InputHelper.SanitizeInput(
            InputBox("Role (Admin / Cashier / Manager / Staff):", "Add User"))
        Dim validRoles As String() = {Constants.USERTYPE_ADMIN, Constants.USERTYPE_CASHIER,
                                      Constants.USERTYPE_MANAGER, Constants.USERTYPE_STAFF}
        If Array.IndexOf(validRoles, userType) < 0 Then
            MessageBox.Show("Role must be: Admin, Cashier, Manager, or Staff.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim securityQuestion As String = PromptForSecurityQuestion("Add User - Security Question")
        If securityQuestion Is Nothing Then Return

        Dim securityAnswer As String = InputBox("Security Answer (used for password recovery):", "Add User")
        If String.IsNullOrWhiteSpace(securityAnswer) Then
            MessageBox.Show("A security answer is required so this user can recover their password later.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If UserRepository.UsernameExists(username) Then
                MessageBox.Show("That username is already taken.", "Duplicate Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim hash As String = PasswordHelper.HashPassword(password)
            Dim answerHash As String = PasswordHelper.HashAnswer(securityAnswer)
            UserRepository.Insert(username, hash, fullName, userType, securityQuestion, answerHash)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Added user: {username} ({userType})")

            MessageBox.Show("User added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()

        Catch ex As Microsoft.Data.SqlClient.SqlException
            Dim msg As String = InputHelper.GetConstraintMessage(ex)
            MessageBox.Show(If(msg, "Failed to add user." & Environment.NewLine & ex.Message),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Failed to add user." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to edit.", "Edit User",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim userID   As Integer = CInt(selectedRow.Cells(0).Value)
        Dim username As String  = selectedRow.Cells(1).Value.ToString()

        Try
            Dim dt As DataTable = UserRepository.GetByID(userID)
            If dt.Rows.Count = 0 Then Return
            Dim row As DataRow = dt.Rows(0)

            Dim newFullName As String = InputHelper.SanitizeInput(
                InputBox("Full Name:", "Edit User", row("FullName").ToString()))
            If String.IsNullOrWhiteSpace(newFullName) Then Return

            Dim newUserType As String = InputHelper.SanitizeInput(
                InputBox("Role (Admin / Cashier / Manager / Staff):", "Edit User", row("UserType").ToString()))
            Dim validRoles As String() = {Constants.USERTYPE_ADMIN, Constants.USERTYPE_CASHIER,
                                          Constants.USERTYPE_MANAGER, Constants.USERTYPE_STAFF}
            If Array.IndexOf(validRoles, newUserType) < 0 Then
                MessageBox.Show("Role must be: Admin, Cashier, Manager, or Staff.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim newStatus As String = InputHelper.SanitizeInput(
                InputBox("Status (Active / Inactive):", "Edit User", row("Status").ToString()))
            If newStatus <> Constants.STATUS_ACTIVE AndAlso newStatus <> Constants.STATUS_INACTIVE Then
                MessageBox.Show("Status must be: Active or Inactive.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If userID = SessionManager.UserID AndAlso newStatus = Constants.STATUS_INACTIVE Then
                MessageBox.Show("You cannot deactivate your own account.", "Not Allowed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            UserRepository.Update(userID, newFullName, newUserType, newStatus)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Updated user: {username} (ID: {userID})")

            MessageBox.Show("User updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show("Failed to update user." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "Delete User",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim userID   As Integer = CInt(selectedRow.Cells(0).Value)
        Dim username As String  = selectedRow.Cells(1).Value.ToString()

        If userID = SessionManager.UserID Then
            MessageBox.Show("You cannot delete your own account.", "Not Allowed",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show($"Delete user ""{username}""? This cannot be undone.",
                                      "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            UserRepository.Delete(userID)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Deleted user: {username} (ID: {userID})")

            MessageBox.Show("User deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show("Failed to delete user." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadUsers()
    End Sub

End Class
