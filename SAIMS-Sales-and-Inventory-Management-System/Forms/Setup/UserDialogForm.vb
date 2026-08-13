Public Class UserDialogForm

    Public Property IsEditMode As Boolean = False
    Public Property UserID As Integer = 0
    Public Property UsernameInput As String = ""
    Public Property FullNameInput As String = ""
    Public Property RoleInput As String = Constants.USERTYPE_CASHIER
    Public Property StatusInput As String = Constants.STATUS_ACTIVE
    Public Property PasswordInput As String = ""
    Public Property SecurityQuestionInput As String = ""
    Public Property SecurityAnswerInput As String = ""

    Private Sub UserDialogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Security Questions
        cboSecurityQuestion.Items.Clear()
        cboSecurityQuestion.Items.AddRange(Constants.SecurityQuestions)
        If cboSecurityQuestion.Items.Count > 0 Then cboSecurityQuestion.SelectedIndex = 0

        cboRole.SelectedItem = Constants.USERTYPE_CASHIER
        cboStatus.SelectedItem = Constants.STATUS_ACTIVE

        If IsEditMode Then
            lblHeaderTitle.Text = "Edit User Account"
            Me.Text = "Edit User Account"
            txtUsername.Text = UsernameInput
            txtUsername.ReadOnly = True ' Don't allow changing username on edit
            txtFullName.Text = FullNameInput

            If Not String.IsNullOrEmpty(RoleInput) AndAlso cboRole.Items.Contains(RoleInput) Then
                cboRole.SelectedItem = RoleInput
            End If

            If Not String.IsNullOrEmpty(StatusInput) AndAlso cboStatus.Items.Contains(StatusInput) Then
                cboStatus.SelectedItem = StatusInput
            End If

            ' On edit mode, hide password and security fields or make them optional
            lblPassword.Visible = False
            txtPassword.Visible = False
            lblConfirmPassword.Visible = False
            txtConfirmPassword.Visible = False
            lblSecurityQuestion.Visible = False
            cboSecurityQuestion.Visible = False
            lblNewSecurityQuestion.Visible = False
            txtNewSecurityQuestion.Visible = False
            lblSecurityAnswer.Visible = False
            txtSecurityAnswer.Visible = False

            ' Resize window dynamically for clean layout
            Me.Height = 270
            btnSave.Location = New Point(245, 185)
            btnCancel.Location = New Point(355, 185)
        Else
            lblHeaderTitle.Text = "Add New User Account"
            Me.Text = "Add New User Account"
            txtUsername.Text = ""
            txtUsername.ReadOnly = False
            txtFullName.Text = ""
            txtPassword.Text = ""
            txtConfirmPassword.Text = ""
            txtNewSecurityQuestion.Text = ""
            txtSecurityAnswer.Text = ""
            Me.Height = 450
        End If
    End Sub

    Private Sub cboSecurityQuestion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSecurityQuestion.SelectedIndexChanged
        If IsEditMode Then Return

        Dim isOther As Boolean = (cboSecurityQuestion.SelectedItem IsNot Nothing AndAlso
                                  cboSecurityQuestion.SelectedItem.ToString() = "Other")

        lblNewSecurityQuestion.Visible = isOther
        txtNewSecurityQuestion.Visible = isOther

        If isOther Then
            lblSecurityAnswer.Location = New Point(25, 343)
            txtSecurityAnswer.Location = New Point(25, 363)
            btnSave.Location = New Point(245, 415)
            btnCancel.Location = New Point(355, 415)
            Me.Height = 505
        Else
            lblSecurityAnswer.Location = New Point(25, 288)
            txtSecurityAnswer.Location = New Point(25, 308)
            btnSave.Location = New Point(245, 360)
            btnCancel.Location = New Point(355, 360)
            Me.Height = 450
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim username As String = InputHelper.SanitizeInput(txtUsername.Text.Trim())
        Dim fullName As String = InputHelper.SanitizeInput(txtFullName.Text.Trim())
        Dim role As String = If(cboRole.SelectedItem IsNot Nothing, cboRole.SelectedItem.ToString(), Constants.USERTYPE_CASHIER)
        Dim status As String = If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString(), Constants.STATUS_ACTIVE)

        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Username is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(fullName) Then
            MessageBox.Show("Full Name is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        If Not IsEditMode Then
            Dim pass As String = txtPassword.Text
            Dim confirmPass As String = txtConfirmPassword.Text

            If String.IsNullOrWhiteSpace(pass) Then
                MessageBox.Show("Password is required for new users.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If

            If pass <> confirmPass Then
                MessageBox.Show("Passwords do not match.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtConfirmPassword.Focus()
                Return
            End If

            Dim secQuestion As String = ""
            If cboSecurityQuestion.SelectedItem IsNot Nothing AndAlso cboSecurityQuestion.SelectedItem.ToString() = "Other" Then
                secQuestion = InputHelper.SanitizeInput(txtNewSecurityQuestion.Text.Trim())
                If String.IsNullOrWhiteSpace(secQuestion) Then
                    MessageBox.Show("Please enter your new security question.", "Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNewSecurityQuestion.Focus()
                    Return
                End If
            ElseIf cboSecurityQuestion.SelectedItem IsNot Nothing Then
                secQuestion = cboSecurityQuestion.SelectedItem.ToString()
            Else
                MessageBox.Show("Security Question is required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSecurityQuestion.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtSecurityAnswer.Text.Trim()) Then
                MessageBox.Show("Security Answer is required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSecurityAnswer.Focus()
                Return
            End If

            PasswordInput = pass
            SecurityQuestionInput = secQuestion
            SecurityAnswerInput = txtSecurityAnswer.Text.Trim()
        End If

        UsernameInput = username
        FullNameInput = fullName
        RoleInput = role
        StatusInput = status

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
