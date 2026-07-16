<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        panelBrand = New Panel()
        lblBrandFooter = New Label()
        lblBrandSubtitle = New Label()
        pnlAccentLine = New Panel()
        lblBrandTitle = New Label()
        panelMain = New Panel()
        btnCancel = New Button()
        btnLogin = New Button()
        lblStatus = New Label()
        lnkForgotPassword = New LinkLabel()
        chkShowPassword = New CheckBox()
        txtPassword = New TextBox()
        lblPassword = New Label()
        txtUsername = New TextBox()
        lblUsername = New Label()
        lblWelcomeSub = New Label()
        lblWelcome = New Label()
        panelBrand.SuspendLayout()
        panelMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelBrand
        ' 
        panelBrand.BackColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        panelBrand.Controls.Add(lblBrandFooter)
        panelBrand.Controls.Add(lblBrandSubtitle)
        panelBrand.Controls.Add(pnlAccentLine)
        panelBrand.Controls.Add(lblBrandTitle)
        panelBrand.Dock = DockStyle.Left
        panelBrand.Location = New Point(0, 0)
        panelBrand.Name = "panelBrand"
        panelBrand.Size = New Size(220, 453)
        panelBrand.TabIndex = 0
        ' 
        ' lblBrandFooter
        ' 
        lblBrandFooter.Font = New Font("Segoe UI", 8.0F)
        lblBrandFooter.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblBrandFooter.Location = New Point(10, 414)
        lblBrandFooter.Name = "lblBrandFooter"
        lblBrandFooter.Size = New Size(200, 23)
        lblBrandFooter.TabIndex = 3
        lblBrandFooter.Text = "SAIMS"
        lblBrandFooter.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblBrandSubtitle
        ' 
        lblBrandSubtitle.Font = New Font("Segoe UI", 10.5F)
        lblBrandSubtitle.ForeColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        lblBrandSubtitle.Location = New Point(10, 249)
        lblBrandSubtitle.Name = "lblBrandSubtitle"
        lblBrandSubtitle.Size = New Size(200, 57)
        lblBrandSubtitle.TabIndex = 2
        lblBrandSubtitle.Text = "Sales & Inventory" & vbCrLf & "Management System"
        lblBrandSubtitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlAccentLine
        ' 
        pnlAccentLine.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        pnlAccentLine.Location = New Point(90, 232)
        pnlAccentLine.Name = "pnlAccentLine"
        pnlAccentLine.Size = New Size(40, 3)
        pnlAccentLine.TabIndex = 1
        ' 
        ' lblBrandTitle
        ' 
        lblBrandTitle.Font = New Font("Segoe UI", 26.0F, FontStyle.Bold)
        lblBrandTitle.ForeColor = Color.White
        lblBrandTitle.Location = New Point(10, 170)
        lblBrandTitle.Name = "lblBrandTitle"
        lblBrandTitle.Size = New Size(200, 51)
        lblBrandTitle.TabIndex = 0
        lblBrandTitle.Text = "SAIMS"
        lblBrandTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' panelMain
        ' 
        panelMain.BackColor = Color.White
        panelMain.Controls.Add(btnCancel)
        panelMain.Controls.Add(btnLogin)
        panelMain.Controls.Add(lblStatus)
        panelMain.Controls.Add(lnkForgotPassword)
        panelMain.Controls.Add(chkShowPassword)
        panelMain.Controls.Add(txtPassword)
        panelMain.Controls.Add(lblPassword)
        panelMain.Controls.Add(txtUsername)
        panelMain.Controls.Add(lblUsername)
        panelMain.Controls.Add(lblWelcomeSub)
        panelMain.Controls.Add(lblWelcome)
        panelMain.Dock = DockStyle.Fill
        panelMain.Location = New Point(220, 0)
        panelMain.Name = "panelMain"
        panelMain.Size = New Size(483, 453)
        panelMain.TabIndex = 1
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.White
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9.0F)
        btnCancel.ForeColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnCancel.Location = New Point(50, 400)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(405, 32)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Exit Application"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(50, 350)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(405, 48)
        btnLogin.TabIndex = 6
        btnLogin.Text = "Log In"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblStatus.Location = New Point(50, 318)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(0, 19)
        lblStatus.TabIndex = 5
        ' 
        ' lnkForgotPassword
        ' 
        lnkForgotPassword.AutoSize = True
        lnkForgotPassword.Font = New Font("Segoe UI", 9.0F)
        lnkForgotPassword.LinkColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lnkForgotPassword.Location = New Point(353, 287)
        lnkForgotPassword.Name = "lnkForgotPassword"
        lnkForgotPassword.Size = New Size(118, 19)
        lnkForgotPassword.TabIndex = 4
        lnkForgotPassword.TabStop = True
        lnkForgotPassword.Text = "Forgot password?"
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Segoe UI", 9.0F)
        chkShowPassword.Location = New Point(50, 287)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(123, 23)
        chkShowPassword.TabIndex = 3
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 10.5F)
        txtPassword.Location = New Point(50, 250)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(405, 28)
        txtPassword.TabIndex = 2
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 9.5F)
        lblPassword.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblPassword.Location = New Point(50, 224)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(67, 19)
        lblPassword.TabIndex = 8
        lblPassword.Text = "Password"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 10.5F)
        txtUsername.Location = New Point(50, 179)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(405, 28)
        txtUsername.TabIndex = 1
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 9.5F)
        lblUsername.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblUsername.Location = New Point(50, 153)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(71, 19)
        lblUsername.TabIndex = 9
        lblUsername.Text = "Username"
        ' 
        ' lblWelcomeSub
        ' 
        lblWelcomeSub.AutoSize = True
        lblWelcomeSub.Font = New Font("Segoe UI", 10.0F)
        lblWelcomeSub.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblWelcomeSub.Location = New Point(50, 102)
        lblWelcomeSub.Name = "lblWelcomeSub"
        lblWelcomeSub.Size = New Size(205, 20)
        lblWelcomeSub.TabIndex = 11
        lblWelcomeSub.Text = "Please sign in to your account"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblWelcome.Location = New Point(50, 57)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(221, 41)
        lblWelcome.TabIndex = 10
        lblWelcome.Text = "Welcome Back"
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(703, 453)
        Controls.Add(panelMain)
        Controls.Add(panelBrand)
        FormBorderStyle = FormBorderStyle.None
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAIMS - Login"
        panelBrand.ResumeLayout(False)
        panelMain.ResumeLayout(False)
        panelMain.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents panelBrand As Panel
    Friend WithEvents lblBrandTitle As Label
    Friend WithEvents pnlAccentLine As Panel
    Friend WithEvents lblBrandSubtitle As Label
    Friend WithEvents lblBrandFooter As Label
    Friend WithEvents panelMain As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblWelcomeSub As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents lnkForgotPassword As LinkLabel
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnCancel As Button
End Class
