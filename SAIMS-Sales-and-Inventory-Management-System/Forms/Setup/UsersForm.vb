Public Class UsersForm
    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSampleData()
    End Sub

    Private Sub LoadSampleData()
        dgvUsers.Rows.Clear()

        dgvUsers.Rows.Add("U001", "admin", "Administrator", "Active")
        dgvUsers.Rows.Add("U002", "cashier1", "Cashier", "Active")
        dgvUsers.Rows.Add("U003", "cashier2", "Cashier", "Active")
        dgvUsers.Rows.Add("U004", "manager", "Manager", "Active")
        dgvUsers.Rows.Add("U005", "staff1", "Staff", "Inactive")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MessageBox.Show("Add User functionality - UI Only", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            MessageBox.Show("Edit User functionality - UI Only", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select a user to edit", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim result = MessageBox.Show("Delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                MessageBox.Show("Delete functionality - UI Only", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Please select a user to delete", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadSampleData()
    End Sub
End Class
