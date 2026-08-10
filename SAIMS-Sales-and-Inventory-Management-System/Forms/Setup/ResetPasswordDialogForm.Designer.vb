<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ResetPasswordDialogForm
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
        lblTargetUser = New Label()
        lblNewPassword = New Label()
        txtNewPassword = New TextBox()
        lblConfirmPassword = New Label()
        txtConfirmPassword = New TextBox()
        btnSave = New Button()
        btnCancel = New Button()
        panelHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(142), CByte(68), CByte(173))
        panelHeader.Controls.Add(lblHeaderTitle)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(420, 50)
        panelHeader.TabIndex = 0
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.Location = New Point(20, 14)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(128, 21)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "Reset Password"
        ' 
        ' lblTargetUser
        ' 
        lblTargetUser.AutoSize = True
        lblTargetUser.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblTargetUser.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTargetUser.Location = New Point(25, 68)
        lblTargetUser.Name = "lblTargetUser"
        lblTargetUser.Size = New Size(79, 19)
        lblTargetUser.TabIndex = 1
        lblTargetUser.Text = "User: --"
        ' 
        ' lblNewPassword
        ' 
        lblNewPassword.AutoSize = True
        lblNewPassword.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblNewPassword.Location = New Point(25, 105)
        lblNewPassword.Name = "lblNewPassword"
        lblNewPassword.Size = New Size(102, 17)
        lblNewPassword.TabIndex = 2
        lblNewPassword.Text = "New Password:"
        ' 
        ' txtNewPassword
        ' 
        txtNewPassword.Font = New Font("Segoe UI", 10F)
        txtNewPassword.Location = New Point(25, 125)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.UseSystemPasswordChar = True
        txtNewPassword.Size = New Size(370, 25)
        txtNewPassword.TabIndex = 3
        ' 
        ' lblConfirmPassword
        ' 
        lblConfirmPassword.AutoSize = True
        lblConfirmPassword.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblConfirmPassword.Location = New Point(25, 165)
        lblConfirmPassword.Name = "lblConfirmPassword"
        lblConfirmPassword.Size = New Size(156, 17)
        lblConfirmPassword.TabIndex = 4
        lblConfirmPassword.Text = "Confirm New Password:"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Font = New Font("Segoe UI", 10F)
        txtConfirmPassword.Location = New Point(25, 185)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.UseSystemPasswordChar = True
        txtConfirmPassword.Size = New Size(370, 25)
        txtConfirmPassword.TabIndex = 5
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(142), CByte(68), CByte(173))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(185, 235)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(105, 35)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(295, 235)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 35)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' ResetPasswordDialogForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(420, 290)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtConfirmPassword)
        Controls.Add(lblConfirmPassword)
        Controls.Add(txtNewPassword)
        Controls.Add(lblNewPassword)
        Controls.Add(lblTargetUser)
        Controls.Add(panelHeader)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "ResetPasswordDialogForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Reset Password"
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblTargetUser As Label
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
