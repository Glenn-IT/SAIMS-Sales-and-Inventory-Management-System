<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ForgotPasswordForm
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelMain = New System.Windows.Forms.Panel()

        Me.lblStep1Info = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancelStep1 = New System.Windows.Forms.Button()

        Me.lblQuestionPrompt = New System.Windows.Forms.Label()
        Me.cmbQuestion = New System.Windows.Forms.ComboBox()
        Me.lblAnswer = New System.Windows.Forms.Label()
        Me.txtAnswer = New System.Windows.Forms.TextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()

        Me.panelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(140, 25)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(230, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Forgot Password"
        '
        'lblStep1Info
        '
        Me.lblStep1Info.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblStep1Info.Location = New System.Drawing.Point(20, 15)
        Me.lblStep1Info.Name = "lblStep1Info"
        Me.lblStep1Info.Size = New System.Drawing.Size(320, 40)
        Me.lblStep1Info.TabIndex = 0
        Me.lblStep1Info.Text = "Enter your username to begin password recovery."
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblUsername.Location = New System.Drawing.Point(20, 60)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(75, 19)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtUsername.Location = New System.Drawing.Point(20, 85)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(320, 25)
        Me.txtUsername.TabIndex = 2
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.Location = New System.Drawing.Point(20, 130)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(155, 40)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnCancelStep1
        '
        Me.btnCancelStep1.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnCancelStep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelStep1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCancelStep1.ForeColor = System.Drawing.Color.White
        Me.btnCancelStep1.Location = New System.Drawing.Point(185, 130)
        Me.btnCancelStep1.Name = "btnCancelStep1"
        Me.btnCancelStep1.Size = New System.Drawing.Size(155, 40)
        Me.btnCancelStep1.TabIndex = 4
        Me.btnCancelStep1.Text = "Cancel"
        Me.btnCancelStep1.UseVisualStyleBackColor = False
        '
        'lblQuestionPrompt
        '
        Me.lblQuestionPrompt.AutoSize = True
        Me.lblQuestionPrompt.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblQuestionPrompt.Location = New System.Drawing.Point(20, 15)
        Me.lblQuestionPrompt.Name = "lblQuestionPrompt"
        Me.lblQuestionPrompt.Size = New System.Drawing.Size(210, 19)
        Me.lblQuestionPrompt.TabIndex = 5
        Me.lblQuestionPrompt.Text = "Select your security question:"
        Me.lblQuestionPrompt.Visible = False
        '
        'cmbQuestion
        '
        Me.cmbQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQuestion.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbQuestion.FormattingEnabled = True
        Me.cmbQuestion.Location = New System.Drawing.Point(20, 38)
        Me.cmbQuestion.Name = "cmbQuestion"
        Me.cmbQuestion.Size = New System.Drawing.Size(320, 26)
        Me.cmbQuestion.TabIndex = 14
        Me.cmbQuestion.Visible = False
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblAnswer.Location = New System.Drawing.Point(20, 70)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(90, 19)
        Me.lblAnswer.TabIndex = 6
        Me.lblAnswer.Text = "Your Answer:"
        Me.lblAnswer.Visible = False
        '
        'txtAnswer
        '
        Me.txtAnswer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtAnswer.Location = New System.Drawing.Point(20, 95)
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.Size = New System.Drawing.Size(320, 25)
        Me.txtAnswer.TabIndex = 7
        Me.txtAnswer.Visible = False
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblNewPassword.Location = New System.Drawing.Point(20, 130)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(110, 19)
        Me.lblNewPassword.TabIndex = 8
        Me.lblNewPassword.Text = "New Password:"
        Me.lblNewPassword.Visible = False
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtNewPassword.Location = New System.Drawing.Point(20, 155)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(320, 25)
        Me.txtNewPassword.TabIndex = 9
        Me.txtNewPassword.Visible = False
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblConfirmPassword.Location = New System.Drawing.Point(20, 190)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(140, 19)
        Me.lblConfirmPassword.TabIndex = 10
        Me.lblConfirmPassword.Text = "Confirm Password:"
        Me.lblConfirmPassword.Visible = False
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtConfirmPassword.Location = New System.Drawing.Point(20, 215)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(320, 25)
        Me.txtConfirmPassword.TabIndex = 11
        Me.txtConfirmPassword.Visible = False
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(20, 255)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(155, 40)
        Me.btnReset.TabIndex = 12
        Me.btnReset.Text = "Reset Password"
        Me.btnReset.UseVisualStyleBackColor = False
        Me.btnReset.Visible = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Location = New System.Drawing.Point(185, 255)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(155, 40)
        Me.btnBack.TabIndex = 13
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        Me.btnBack.Visible = False
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.White
        Me.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelMain.Controls.Add(Me.lblStep1Info)
        Me.panelMain.Controls.Add(Me.lblUsername)
        Me.panelMain.Controls.Add(Me.txtUsername)
        Me.panelMain.Controls.Add(Me.btnNext)
        Me.panelMain.Controls.Add(Me.btnCancelStep1)
        Me.panelMain.Controls.Add(Me.lblQuestionPrompt)
        Me.panelMain.Controls.Add(Me.cmbQuestion)
        Me.panelMain.Controls.Add(Me.lblAnswer)
        Me.panelMain.Controls.Add(Me.txtAnswer)
        Me.panelMain.Controls.Add(Me.lblNewPassword)
        Me.panelMain.Controls.Add(Me.txtNewPassword)
        Me.panelMain.Controls.Add(Me.lblConfirmPassword)
        Me.panelMain.Controls.Add(Me.txtConfirmPassword)
        Me.panelMain.Controls.Add(Me.btnReset)
        Me.panelMain.Controls.Add(Me.btnBack)
        Me.panelMain.Location = New System.Drawing.Point(120, 75)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(360, 305)
        Me.panelMain.TabIndex = 1
        '
        'ForgotPasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 420)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ForgotPasswordForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Forgot Password"
        Me.panelMain.ResumeLayout(False)
        Me.panelMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents panelMain As Panel

    Friend WithEvents lblStep1Info As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents btnCancelStep1 As Button

    Friend WithEvents lblQuestionPrompt As Label
    Friend WithEvents cmbQuestion As ComboBox
    Friend WithEvents lblAnswer As Label
    Friend WithEvents txtAnswer As TextBox
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents btnReset As Button
    Friend WithEvents btnBack As Button
End Class
