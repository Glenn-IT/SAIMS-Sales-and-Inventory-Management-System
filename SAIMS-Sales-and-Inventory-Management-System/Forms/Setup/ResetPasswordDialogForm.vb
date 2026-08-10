Public Class ResetPasswordDialogForm

    Public Property TargetUsername As String = ""
    Public Property NewPasswordInput As String = ""

    Private Sub ResetPasswordDialogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTargetUser.Text = $"User Account: {TargetUsername}"
        txtNewPassword.Text = ""
        txtConfirmPassword.Text = ""
        txtNewPassword.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim pass As String = txtNewPassword.Text
        Dim confirm As String = txtConfirmPassword.Text

        If String.IsNullOrWhiteSpace(pass) Then
            MessageBox.Show("New Password is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPassword.Focus()
            Return
        End If

        If pass.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPassword.Focus()
            Return
        End If

        If pass <> confirm Then
            MessageBox.Show("Passwords do not match.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPassword.Focus()
            Return
        End If

        NewPasswordInput = pass
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
