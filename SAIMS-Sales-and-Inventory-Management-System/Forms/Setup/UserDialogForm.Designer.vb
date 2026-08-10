<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserDialogForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        panelHeader = New Panel()
        lblHeaderTitle = New Label()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblFullName = New Label()
        txtFullName = New TextBox()
        lblRole = New Label()
        cboRole = New ComboBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        lblConfirmPassword = New Label()
        txtConfirmPassword = New TextBox()
        lblSecurityQuestion = New Label()
        cboSecurityQuestion = New ComboBox()
        lblSecurityAnswer = New Label()
        txtSecurityAnswer = New TextBox()
        lblStatus = New Label()
        cboStatus = New ComboBox()
        btnSave = New Button()
        btnCancel = New Button()
        panelHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        panelHeader.Controls.Add(lblHeaderTitle)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(480, 50)
        panelHeader.TabIndex = 0
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.Location = New Point(20, 14)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(100, 21)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "User Account"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblUsername.Location = New Point(25, 68)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(73, 17)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 10F)
        txtUsername.Location = New Point(25, 88)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(200, 25)
        txtUsername.TabIndex = 2
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblFullName.Location = New Point(255, 68)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(75, 17)
        lblFullName.TabIndex = 3
        lblFullName.Text = "Full Name:"
        ' 
        ' txtFullName
        ' 
        txtFullName.Font = New Font("Segoe UI", 10F)
        txtFullName.Location = New Point(255, 88)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(200, 25)
        txtFullName.TabIndex = 4
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblRole.Location = New Point(25, 123)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(39, 17)
        lblRole.TabIndex = 5
        lblRole.Text = "Role:"
        ' 
        ' cboRole
        ' 
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.Font = New Font("Segoe UI", 10F)
        cboRole.FormattingEnabled = True
        cboRole.Items.AddRange(New Object() {"Admin", "Cashier", "Manager", "Staff"})
        cboRole.Location = New Point(25, 143)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(200, 25)
        cboRole.TabIndex = 6
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblStatus.Location = New Point(255, 123)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(50, 17)
        lblStatus.TabIndex = 7
        lblStatus.Text = "Status:"
        ' 
        ' cboStatus
        ' 
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.Font = New Font("Segoe UI", 10F)
        cboStatus.FormattingEnabled = True
        cboStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        cboStatus.Location = New Point(255, 143)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(200, 25)
        cboStatus.TabIndex = 8
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblPassword.Location = New Point(25, 178)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(70, 17)
        lblPassword.TabIndex = 9
        lblPassword.Text = "Password:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 10F)
        txtPassword.Location = New Point(25, 198)
        txtPassword.Name = "txtPassword"
        txtPassword.UseSystemPasswordChar = True
        txtPassword.Size = New Size(200, 25)
        txtPassword.TabIndex = 10
        ' 
        ' lblConfirmPassword
        ' 
        lblConfirmPassword.AutoSize = True
        lblConfirmPassword.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblConfirmPassword.Location = New Point(255, 178)
        lblConfirmPassword.Name = "lblConfirmPassword"
        lblConfirmPassword.Size = New Size(124, 17)
        lblConfirmPassword.TabIndex = 11
        lblConfirmPassword.Text = "Confirm Password:"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Font = New Font("Segoe UI", 10F)
        txtConfirmPassword.Location = New Point(255, 198)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.UseSystemPasswordChar = True
        txtConfirmPassword.Size = New Size(200, 25)
        txtConfirmPassword.TabIndex = 12
        ' 
        ' lblSecurityQuestion
        ' 
        lblSecurityQuestion.AutoSize = True
        lblSecurityQuestion.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblSecurityQuestion.Location = New Point(25, 233)
        lblSecurityQuestion.Name = "lblSecurityQuestion"
        lblSecurityQuestion.Size = New Size(122, 17)
        lblSecurityQuestion.TabIndex = 13
        lblSecurityQuestion.Text = "Security Question:"
        ' 
        ' cboSecurityQuestion
        ' 
        cboSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList
        cboSecurityQuestion.Font = New Font("Segoe UI", 10F)
        cboSecurityQuestion.FormattingEnabled = True
        cboSecurityQuestion.Location = New Point(25, 253)
        cboSecurityQuestion.Name = "cboSecurityQuestion"
        cboSecurityQuestion.Size = New Size(430, 25)
        cboSecurityQuestion.TabIndex = 14
        ' 
        ' lblSecurityAnswer
        ' 
        lblSecurityAnswer.AutoSize = True
        lblSecurityAnswer.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblSecurityAnswer.Location = New Point(25, 288)
        lblSecurityAnswer.Name = "lblSecurityAnswer"
        lblSecurityAnswer.Size = New Size(109, 17)
        lblSecurityAnswer.TabIndex = 15
        lblSecurityAnswer.Text = "Security Answer:"
        ' 
        ' txtSecurityAnswer
        ' 
        txtSecurityAnswer.Font = New Font("Segoe UI", 10F)
        txtSecurityAnswer.Location = New Point(25, 308)
        txtSecurityAnswer.Name = "txtSecurityAnswer"
        txtSecurityAnswer.Size = New Size(430, 25)
        txtSecurityAnswer.TabIndex = 16
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(245, 360)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(100, 35)
        btnSave.TabIndex = 17
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(355, 360)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 35)
        btnCancel.TabIndex = 18
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' UserDialogForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(480, 415)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtSecurityAnswer)
        Controls.Add(lblSecurityAnswer)
        Controls.Add(cboSecurityQuestion)
        Controls.Add(lblSecurityQuestion)
        Controls.Add(txtConfirmPassword)
        Controls.Add(lblConfirmPassword)
        Controls.Add(txtPassword)
        Controls.Add(lblPassword)
        Controls.Add(cboStatus)
        Controls.Add(lblStatus)
        Controls.Add(cboRole)
        Controls.Add(lblRole)
        Controls.Add(txtFullName)
        Controls.Add(lblFullName)
        Controls.Add(txtUsername)
        Controls.Add(lblUsername)
        Controls.Add(panelHeader)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "UserDialogForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "User Account"
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents lblRole As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents lblSecurityQuestion As Label
    Friend WithEvents cboSecurityQuestion As ComboBox
    Friend WithEvents lblSecurityAnswer As Label
    Friend WithEvents txtSecurityAnswer As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
