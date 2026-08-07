Public Class UsersForm

    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()

        ' Reset Password & Set Security Question buttons — Admin only
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

#Region "Dialog Helper Structures & Functions"

    Private Structure AddUserInputs
        Public Username As String
        Public FullName As String
        Public Password As String
        Public Role As String
        Public SecurityQuestion As String
        Public SecurityAnswer As String
    End Structure

    Private Function ShowAddUserDialog(ByRef result As AddUserInputs) As Boolean
        Using dlg As New Form()
            dlg.Text = "Add New User"
            dlg.Size = New Size(460, 490)
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            dlg.BackColor = Color.FromArgb(245, 247, 250)

            Dim lblTitle As New Label() With {
                .Text = "Create New Account",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(41, 128, 185),
                .Location = New Point(20, 15),
                .AutoSize = True
            }

            ' Username
            Dim lblUser As New Label() With {.Text = "Username:", .Location = New Point(20, 50), .AutoSize = True}
            Dim txtUser As New TextBox() With {.Location = New Point(20, 72), .Width = 400}

            ' Full Name
            Dim lblName As New Label() With {.Text = "Full Name:", .Location = New Point(20, 105), .AutoSize = True}
            Dim txtName As New TextBox() With {.Location = New Point(20, 127), .Width = 400}

            ' Password
            Dim lblPass As New Label() With {.Text = "Password:", .Location = New Point(20, 160), .AutoSize = True}
            Dim txtPass As New TextBox() With {.Location = New Point(20, 182), .Width = 400, .UseSystemPasswordChar = True}

            ' Role ComboBox
            Dim lblRole As New Label() With {.Text = "Role:", .Location = New Point(20, 215), .AutoSize = True}
            Dim cmbRole As New ComboBox() With {
                .Location = New Point(20, 237),
                .Width = 400,
                .DropDownStyle = ComboBoxStyle.DropDownList
            }
            cmbRole.Items.AddRange(New Object() {
                Constants.USERTYPE_ADMIN,
                Constants.USERTYPE_CASHIER,
                Constants.USERTYPE_MANAGER,
                Constants.USERTYPE_STAFF
            })
            cmbRole.SelectedIndex = 0

            ' Security Question ComboBox
            Dim lblQ As New Label() With {.Text = "Security Question:", .Location = New Point(20, 270), .AutoSize = True}
            Dim cmbQ As New ComboBox() With {
                .Location = New Point(20, 292),
                .Width = 400,
                .DropDownStyle = ComboBoxStyle.DropDownList
            }
            cmbQ.Items.AddRange(Constants.SecurityQuestions)
            cmbQ.SelectedIndex = 0

            ' Security Answer
            Dim lblAns As New Label() With {.Text = "Security Answer:", .Location = New Point(20, 325), .AutoSize = True}
            Dim txtAns As New TextBox() With {.Location = New Point(20, 347), .Width = 400}

            ' Buttons
            Dim btnSave As New Button() With {
                .Text = "Save User",
                .DialogResult = DialogResult.OK,
                .Location = New Point(200, 395),
                .Size = New Size(105, 35),
                .BackColor = Color.FromArgb(41, 128, 185),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .UseVisualStyleBackColor = False
            }
            Dim btnCancel As New Button() With {
                .Text = "Cancel",
                .DialogResult = DialogResult.Cancel,
                .Location = New Point(315, 395),
                .Size = New Size(105, 35),
                .BackColor = Color.FromArgb(149, 165, 166),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .UseVisualStyleBackColor = False
            }

            dlg.AcceptButton = btnSave
            dlg.CancelButton = btnCancel

            dlg.Controls.AddRange(New Control() {
                lblTitle, lblUser, txtUser, lblName, txtName, lblPass, txtPass,
                lblRole, cmbRole, lblQ, cmbQ, lblAns, txtAns, btnSave, btnCancel
            })

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                result.Username = InputHelper.SanitizeInput(txtUser.Text)
                result.FullName = InputHelper.SanitizeInput(txtName.Text)
                result.Password = txtPass.Text
                result.Role = cmbRole.SelectedItem.ToString()
                result.SecurityQuestion = cmbQ.SelectedItem.ToString()
                result.SecurityAnswer = txtAns.Text.Trim()
                Return True
            End If
            Return False
        End Using
    End Function

    Private Structure EditUserInputs
        Public FullName As String
        Public Role As String
        Public Status As String
    End Structure

    Private Function ShowEditUserDialog(username As String, currentFullName As String, currentRole As String, currentStatus As String, ByRef result As EditUserInputs) As Boolean
        Using dlg As New Form()
            dlg.Text = $"Edit User - {username}"
            dlg.Size = New Size(460, 350)
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            dlg.BackColor = Color.FromArgb(245, 247, 250)

            Dim lblTitle As New Label() With {
                .Text = $"Edit User: {username}",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(41, 128, 185),
                .Location = New Point(20, 15),
                .AutoSize = True
            }

            ' Full Name
            Dim lblName As New Label() With {.Text = "Full Name:", .Location = New Point(20, 50), .AutoSize = True}
            Dim txtName As New TextBox() With {.Text = currentFullName, .Location = New Point(20, 72), .Width = 400}

            ' Role ComboBox
            Dim lblRole As New Label() With {.Text = "Role:", .Location = New Point(20, 105), .AutoSize = True}
            Dim cmbRole As New ComboBox() With {
                .Location = New Point(20, 127),
                .Width = 400,
                .DropDownStyle = ComboBoxStyle.DropDownList
            }
            cmbRole.Items.AddRange(New Object() {
                Constants.USERTYPE_ADMIN,
                Constants.USERTYPE_CASHIER,
                Constants.USERTYPE_MANAGER,
                Constants.USERTYPE_STAFF
            })
            If cmbRole.Items.Contains(currentRole) Then
                cmbRole.SelectedItem = currentRole
            Else
                cmbRole.SelectedIndex = 0
            End If

            ' Status ComboBox
            Dim lblStatus As New Label() With {.Text = "Status:", .Location = New Point(20, 160), .AutoSize = True}
            Dim cmbStatus As New ComboBox() With {
                .Location = New Point(20, 182),
                .Width = 400,
                .DropDownStyle = ComboBoxStyle.DropDownList
            }
            cmbStatus.Items.AddRange(New Object() {Constants.STATUS_ACTIVE, Constants.STATUS_INACTIVE})
            If cmbStatus.Items.Contains(currentStatus) Then
                cmbStatus.SelectedItem = currentStatus
            Else
                cmbStatus.SelectedIndex = 0
            End If

            ' Buttons
            Dim btnSave As New Button() With {
                .Text = "Save Changes",
                .DialogResult = DialogResult.OK,
                .Location = New Point(200, 250),
                .Size = New Size(115, 35),
                .BackColor = Color.FromArgb(41, 128, 185),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .UseVisualStyleBackColor = False
            }
            Dim btnCancel As New Button() With {
                .Text = "Cancel",
                .DialogResult = DialogResult.Cancel,
                .Location = New Point(325, 250),
                .Size = New Size(95, 35),
                .BackColor = Color.FromArgb(149, 165, 166),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .UseVisualStyleBackColor = False
            }

            dlg.AcceptButton = btnSave
            dlg.CancelButton = btnCancel

            dlg.Controls.AddRange(New Control() {
                lblTitle, lblName, txtName, lblRole, cmbRole, lblStatus, cmbStatus, btnSave, btnCancel
            })

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                result.FullName = InputHelper.SanitizeInput(txtName.Text)
                result.Role = cmbRole.SelectedItem.ToString()
                result.Status = cmbStatus.SelectedItem.ToString()
                Return True
            End If
            Return False
        End Using
    End Function

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

            ' Security Answer
            Dim lblAns As New Label() With {.Text = "Security Answer:", .Location = New Point(20, 105), .AutoSize = True}
            Dim txtAns As New TextBox() With {.Location = New Point(20, 127), .Width = 400}

            ' Buttons
            Dim btnSave As New Button() With {
                .Text = "Save Question",
                .DialogResult = DialogResult.OK,
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

            dlg.AcceptButton = btnSave
            dlg.CancelButton = btnCancel

            dlg.Controls.AddRange(New Control() {
                lblTitle, lblQ, cmbQ, lblAns, txtAns, btnSave, btnCancel
            })

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                result.Question = cmbQ.SelectedItem.ToString()
                result.Answer = txtAns.Text.Trim()
                Return True
            End If
            Return False
        End Using
    End Function

#End Region

    Private Sub btnSetSecurityQuestion_Click(sender As Object, e As EventArgs)
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
        Dim inputs As New AddUserInputs()
        If Not ShowAddUserDialog(inputs) Then Return

        If String.IsNullOrWhiteSpace(inputs.Username) OrElse String.IsNullOrWhiteSpace(inputs.FullName) Then
            MessageBox.Show("Username and Full Name are required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(inputs.Password) OrElse inputs.Password.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(inputs.SecurityAnswer) Then
            MessageBox.Show("A security answer is required so this user can recover their password later.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If UserRepository.UsernameExists(inputs.Username) Then
                MessageBox.Show("That username is already taken.", "Duplicate Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim hash As String = PasswordHelper.HashPassword(inputs.Password)
            Dim answerHash As String = PasswordHelper.HashAnswer(inputs.SecurityAnswer)
            UserRepository.Insert(inputs.Username, hash, inputs.FullName, inputs.Role, inputs.SecurityQuestion, answerHash)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Added user: {inputs.Username} ({inputs.Role})")

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

            Dim inputs As New EditUserInputs()
            If Not ShowEditUserDialog(username, row("FullName").ToString(), row("UserType").ToString(), row("Status").ToString(), inputs) Then Return

            If String.IsNullOrWhiteSpace(inputs.FullName) Then
                MessageBox.Show("Full Name is required.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If userID = SessionManager.UserID AndAlso inputs.Status = Constants.STATUS_INACTIVE Then
                MessageBox.Show("You cannot deactivate your own account.", "Not Allowed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            UserRepository.Update(userID, inputs.FullName, inputs.Role, inputs.Status)
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
