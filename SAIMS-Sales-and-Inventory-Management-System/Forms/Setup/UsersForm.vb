Public Class UsersForm

    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
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

        Dim userType As String = InputHelper.SanitizeInput(
            InputBox("Role (Admin / Cashier / Manager / Staff):", "Add User"))
        Dim validRoles As String() = {Constants.USERTYPE_ADMIN, Constants.USERTYPE_CASHIER,
                                      Constants.USERTYPE_MANAGER, Constants.USERTYPE_STAFF}
        If Array.IndexOf(validRoles, userType) < 0 Then
            MessageBox.Show("Role must be: Admin, Cashier, Manager, or Staff.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If UserRepository.UsernameExists(username) Then
                MessageBox.Show("That username is already taken.", "Duplicate Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim hash As String = PasswordHelper.HashPassword(password)
            UserRepository.Insert(username, hash, fullName, userType)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Added user: {username} ({userType})")

            MessageBox.Show("User added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()

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
