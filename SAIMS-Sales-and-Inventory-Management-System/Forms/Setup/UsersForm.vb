Public Class UsersForm

    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()

        ' Reset Password & Set Security Question buttons — Admin only
        Dim isAdmin As Boolean = (SessionManager.UserType = Constants.USERTYPE_ADMIN)
        btnResetPassword.Visible = isAdmin
        btnSetSecurityQuestion.Visible = isAdmin
    End Sub

#Region "Dialog Helper Structures & Functions"

    Private Structure SecurityQuestionInputs
        Public Question As String
        Public Answer As String
    End Structure

    Private Function ShowSetSecurityQuestionDialog(username As String, ByRef result As SecurityQuestionInputs) As Boolean
        Using dlg As New Form()
            dlg.Text = "Set Security Question"
            dlg.Size = New Size(460, 260)
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            dlg.BackColor = Color.FromArgb(245, 247, 250)

            Dim lblTitle As New Label() With {
                .Text = $"Security Question for: {username}",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(52, 73, 94),
                .Location = New Point(20, 15),
                .AutoSize = True
            }

            ' Security Question ComboBox
            Dim lblQ As New Label() With {.Text = "Security Question:", .Location = New Point(20, 50), .AutoSize = True}
            Dim cmbQ As New ComboBox() With {
                .Location = New Point(20, 72),
                .Width = 400,
                .DropDownStyle = ComboBoxStyle.DropDownList
            }
            cmbQ.Items.AddRange(Constants.SecurityQuestions)
            cmbQ.SelectedIndex = 0

            ' Custom / New Security Question TextBox
            Dim lblNewQ As New Label() With {.Text = "New Security Question:", .Location = New Point(20, 105), .AutoSize = True, .Visible = False}
            Dim txtNewQ As New TextBox() With {.Location = New Point(20, 127), .Width = 400, .Visible = False}

            ' Security Answer
            Dim lblAns As New Label() With {.Text = "Security Answer:", .Location = New Point(20, 105), .AutoSize = True}
            Dim txtAns As New TextBox() With {.Location = New Point(20, 127), .Width = 400}

            ' Buttons
            Dim btnSave As New Button() With {
                .Text = "Save Question",
                .Location = New Point(200, 170),
                .Size = New Size(115, 35),
                .BackColor = Color.FromArgb(52, 73, 94),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .UseVisualStyleBackColor = False
            }
            Dim btnCancel As New Button() With {
                .Text = "Cancel",
                .DialogResult = DialogResult.Cancel,
                .Location = New Point(325, 170),
                .Size = New Size(95, 35),
                .BackColor = Color.FromArgb(149, 165, 166),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .UseVisualStyleBackColor = False
            }

            AddHandler cmbQ.SelectedIndexChanged, Sub(sender As Object, e As EventArgs)
                Dim isOther As Boolean = (cmbQ.SelectedItem IsNot Nothing AndAlso cmbQ.SelectedItem.ToString() = "Other")
                lblNewQ.Visible = isOther
                txtNewQ.Visible = isOther
                If isOther Then
                    lblAns.Location = New Point(20, 160)
                    txtAns.Location = New Point(20, 182)
                    btnSave.Location = New Point(200, 225)
                    btnCancel.Location = New Point(325, 225)
                    dlg.Size = New Size(460, 315)
                Else
                    lblAns.Location = New Point(20, 105)
                    txtAns.Location = New Point(20, 127)
                    btnSave.Location = New Point(200, 170)
                    btnCancel.Location = New Point(325, 170)
                    dlg.Size = New Size(460, 260)
                End If
            End Sub

            Dim capturedQuestion As String = ""
            Dim capturedAnswer As String = ""

            AddHandler btnSave.Click, Sub(sender As Object, e As EventArgs)
                Dim selectedQ As String = If(cmbQ.SelectedItem IsNot Nothing, cmbQ.SelectedItem.ToString(), "")
                If selectedQ = "Other" Then
                    Dim customQ As String = txtNewQ.Text.Trim()
                    If String.IsNullOrWhiteSpace(customQ) Then
                        MessageBox.Show("Please enter your new security question.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtNewQ.Focus()
                        Return
                    End If
                    capturedQuestion = customQ
                Else
                    capturedQuestion = selectedQ
                End If

                If String.IsNullOrWhiteSpace(txtAns.Text.Trim()) Then
                    MessageBox.Show("An answer is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAns.Focus()
                    Return
                End If

                capturedAnswer = txtAns.Text.Trim()
                dlg.DialogResult = DialogResult.OK
                dlg.Close()
            End Sub

            dlg.CancelButton = btnCancel

            dlg.Controls.AddRange(New Control() {
                lblTitle, lblQ, cmbQ, lblNewQ, txtNewQ, lblAns, txtAns, btnSave, btnCancel
            })

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                result.Question = capturedQuestion
                result.Answer = capturedAnswer
                Return True
            End If
            Return False
        End Using
    End Function

    Private Sub PerformAutoLogout()
        MessageBox.Show("Your account credentials have been updated successfully. You will now be automatically logged out.",
                        "Auto Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS, "Updated own credentials — Auto logged out.")
        SessionManager.Clear()

        Dim loginForm As New LoginForm()
        loginForm.Show()

        Dim openForms As New List(Of Form)(Application.OpenForms.Cast(Of Form)())
        For Each f As Form In openForms
            If f IsNot loginForm Then
                Try
                    f.Hide()
                    f.Close()
                Catch
                End Try
            End If
        Next
    End Sub

#End Region

    Private Sub btnSetSecurityQuestion_Click(sender As Object, e As EventArgs) Handles btnSetSecurityQuestion.Click
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to set the security question for.", "Security Question",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim userID   As Integer = CInt(selectedRow.Cells(0).Value)
        Dim username As String  = selectedRow.Cells(1).Value.ToString()

        Dim inputs As New SecurityQuestionInputs()
        If Not ShowSetSecurityQuestionDialog(username, inputs) Then Return

        If String.IsNullOrWhiteSpace(inputs.Answer) Then
            MessageBox.Show("An answer is required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim answerHash As String = PasswordHelper.HashAnswer(inputs.Answer)
            UserRepository.SetSecurityQuestion(userID, inputs.Question, answerHash)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Security question set for user: {username} (ID: {userID})")

            Dim isSelf As Boolean = (userID = SessionManager.UserID OrElse
                                     String.Equals(username.Trim(), SessionManager.Username.Trim(), StringComparison.OrdinalIgnoreCase))
            If isSelf Then
                PerformAutoLogout()
                Return
            End If

            MessageBox.Show("Security question saved.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to save security question." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to reset the password for.", "Reset Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim userID   As Integer = CInt(selectedRow.Cells(0).Value)
        Dim username As String  = selectedRow.Cells(1).Value.ToString()

        Using dlg As New ResetPasswordDialogForm()
            dlg.TargetUsername = username
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

            Dim newPassword As String = dlg.NewPasswordInput
            If String.IsNullOrWhiteSpace(newPassword) Then Return

            Try
                Dim newHash As String = PasswordHelper.HashPassword(newPassword)
                UserRepository.UpdatePassword(userID, newHash)
                ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                                   $"Reset password for user: {username} (ID: {userID})")

                Dim isSelf As Boolean = (userID = SessionManager.UserID OrElse
                                         String.Equals(username.Trim(), SessionManager.Username.Trim(), StringComparison.OrdinalIgnoreCase))
                If isSelf Then
                    PerformAutoLogout()
                    Return
                End If

                MessageBox.Show("Password reset successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Failed to reset password." & Environment.NewLine & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
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

            UpdateRecordCount()

        Catch ex As Exception
            MessageBox.Show("Failed to load users." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateRecordCount()
        Dim visible = dgvUsers.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow AndAlso r.Visible)
        lblTotalRecords.Text = "Total Record: " & visible & " users"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using dlg As New UserDialogForm()
            dlg.IsEditMode = False
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

            Try
                If UserRepository.UsernameExists(dlg.UsernameInput) Then
                    MessageBox.Show("That username is already taken.", "Duplicate Username",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim hash As String = PasswordHelper.HashPassword(dlg.PasswordInput)
                Dim answerHash As String = PasswordHelper.HashAnswer(dlg.SecurityAnswerInput)
                UserRepository.Insert(dlg.UsernameInput, hash, dlg.FullNameInput, dlg.RoleInput, dlg.SecurityQuestionInput, answerHash)
                ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                                   $"Added user: {dlg.UsernameInput} ({dlg.RoleInput})")

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
        End Using
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

            Using dlg As New UserDialogForm()
                dlg.IsEditMode = True
                dlg.UserID = userID
                dlg.UsernameInput = username
                dlg.FullNameInput = row("FullName").ToString()
                dlg.RoleInput = row("UserType").ToString()
                dlg.StatusInput = row("Status").ToString()

                If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

                If userID = SessionManager.UserID AndAlso dlg.StatusInput = Constants.STATUS_INACTIVE Then
                    MessageBox.Show("You cannot deactivate your own account.", "Not Allowed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                UserRepository.Update(userID, dlg.FullNameInput, dlg.RoleInput, dlg.StatusInput)
                ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                                   $"Updated user: {username} (ID: {userID})")

                Dim isSelf As Boolean = (userID = SessionManager.UserID OrElse
                                         String.Equals(username.Trim(), SessionManager.Username.Trim(), StringComparison.OrdinalIgnoreCase))
                If isSelf Then
                    PerformAutoLogout()
                    Return
                End If

                MessageBox.Show("User updated successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadUsers()
            End Using

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
