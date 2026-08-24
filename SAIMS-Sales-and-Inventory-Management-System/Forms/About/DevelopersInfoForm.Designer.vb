<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DevelopersInfoForm
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
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.panelDev2 = New System.Windows.Forms.Panel()
        Me.lblDev2Notes = New System.Windows.Forms.Label()
        Me.lblDev2Github = New System.Windows.Forms.Label()
        Me.lblDev2Phone = New System.Windows.Forms.Label()
        Me.lblDev2Email = New System.Windows.Forms.Label()
        Me.lblDev2Role = New System.Windows.Forms.Label()
        Me.lblDev2Name = New System.Windows.Forms.Label()
        Me.picDev2 = New System.Windows.Forms.PictureBox()
        Me.panelDev1 = New System.Windows.Forms.Panel()
        Me.lblDev1Notes = New System.Windows.Forms.Label()
        Me.lblDev1Github = New System.Windows.Forms.Label()
        Me.lblDev1Phone = New System.Windows.Forms.Label()
        Me.lblDev1Email = New System.Windows.Forms.Label()
        Me.lblDev1Role = New System.Windows.Forms.Label()
        Me.lblDev1Name = New System.Windows.Forms.Label()
        Me.picDev1 = New System.Windows.Forms.PictureBox()
        Me.panelTop.SuspendLayout()
        Me.panelMain.SuspendLayout()
        Me.panelDev2.SuspendLayout()
        CType(Me.picDev2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDev1.SuspendLayout()
        CType(Me.picDev1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.White
        Me.panelTop.Controls.Add(Me.lblSubtitle)
        Me.panelTop.Controls.Add(Me.lblTitle)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Padding = New System.Windows.Forms.Padding(15)
        Me.panelTop.Size = New System.Drawing.Size(1000, 70)
        Me.panelTop.TabIndex = 0
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(18, 43)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(264, 15)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Meet the Software Development & Engineering Team"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(256, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Developers Information"
        '
        'panelMain
        '
        Me.panelMain.AutoScroll = True
        Me.panelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.panelMain.Controls.Add(Me.panelDev2)
        Me.panelMain.Controls.Add(Me.panelDev1)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 70)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Padding = New System.Windows.Forms.Padding(20)
        Me.panelMain.Size = New System.Drawing.Size(1000, 530)
        Me.panelMain.TabIndex = 1
        '
        'panelDev2
        '
        Me.panelDev2.BackColor = System.Drawing.Color.White
        Me.panelDev2.Controls.Add(Me.lblDev2Notes)
        Me.panelDev2.Controls.Add(Me.lblDev2Github)
        Me.panelDev2.Controls.Add(Me.lblDev2Phone)
        Me.panelDev2.Controls.Add(Me.lblDev2Email)
        Me.panelDev2.Controls.Add(Me.lblDev2Role)
        Me.panelDev2.Controls.Add(Me.lblDev2Name)
        Me.panelDev2.Controls.Add(Me.picDev2)
        Me.panelDev2.Location = New System.Drawing.Point(480, 25)
        Me.panelDev2.Name = "panelDev2"
        Me.panelDev2.Size = New System.Drawing.Size(430, 430)
        Me.panelDev2.TabIndex = 1
        '
        'lblDev2Notes
        '
        Me.lblDev2Notes.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev2Notes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblDev2Notes.Location = New System.Drawing.Point(20, 360)
        Me.lblDev2Notes.Name = "lblDev2Notes"
        Me.lblDev2Notes.Size = New System.Drawing.Size(390, 45)
        Me.lblDev2Notes.TabIndex = 6
        Me.lblDev2Notes.Text = "📝 Note: Frontend UI Layout, Custom Styling & Workflow Modules"
        '
        'lblDev2Github
        '
        Me.lblDev2Github.AutoSize = True
        Me.lblDev2Github.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev2Github.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev2Github.Location = New System.Drawing.Point(20, 320)
        Me.lblDev2Github.Name = "lblDev2Github"
        Me.lblDev2Github.Size = New System.Drawing.Size(184, 19)
        Me.lblDev2Github.TabIndex = 5
        Me.lblDev2Github.Text = "🌐 GitHub: github.com/dev2"
        '
        'lblDev2Phone
        '
        Me.lblDev2Phone.AutoSize = True
        Me.lblDev2Phone.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev2Phone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev2Phone.Location = New System.Drawing.Point(20, 285)
        Me.lblDev2Phone.Name = "lblDev2Phone"
        Me.lblDev2Phone.Size = New System.Drawing.Size(193, 19)
        Me.lblDev2Phone.TabIndex = 4
        Me.lblDev2Phone.Text = "📱 Contact: +63 998 765 4321"
        '
        'lblDev2Email
        '
        Me.lblDev2Email.AutoSize = True
        Me.lblDev2Email.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev2Email.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev2Email.Location = New System.Drawing.Point(20, 250)
        Me.lblDev2Email.Name = "lblDev2Email"
        Me.lblDev2Email.Size = New System.Drawing.Size(191, 19)
        Me.lblDev2Email.TabIndex = 3
        Me.lblDev2Email.Text = "📧 Email: dev2@example.com"
        '
        'lblDev2Role
        '
        Me.lblDev2Role.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblDev2Role.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblDev2Role.Location = New System.Drawing.Point(20, 195)
        Me.lblDev2Role.Name = "lblDev2Role"
        Me.lblDev2Role.Size = New System.Drawing.Size(390, 25)
        Me.lblDev2Role.TabIndex = 2
        Me.lblDev2Role.Text = "UI/UX Specialist & Full Stack Developer"
        Me.lblDev2Role.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDev2Name
        '
        Me.lblDev2Name.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblDev2Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev2Name.Location = New System.Drawing.Point(20, 160)
        Me.lblDev2Name.Name = "lblDev2Name"
        Me.lblDev2Name.Size = New System.Drawing.Size(390, 30)
        Me.lblDev2Name.TabIndex = 1
        Me.lblDev2Name.Text = "Developer 2 Name"
        Me.lblDev2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picDev2
        '
        Me.picDev2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.picDev2.Location = New System.Drawing.Point(155, 25)
        Me.picDev2.Name = "picDev2"
        Me.picDev2.Size = New System.Drawing.Size(120, 120)
        Me.picDev2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picDev2.TabIndex = 0
        Me.picDev2.TabStop = False
        '
        'panelDev1
        '
        Me.panelDev1.BackColor = System.Drawing.Color.White
        Me.panelDev1.Controls.Add(Me.lblDev1Notes)
        Me.panelDev1.Controls.Add(Me.lblDev1Github)
        Me.panelDev1.Controls.Add(Me.lblDev1Phone)
        Me.panelDev1.Controls.Add(Me.lblDev1Email)
        Me.panelDev1.Controls.Add(Me.lblDev1Role)
        Me.panelDev1.Controls.Add(Me.lblDev1Name)
        Me.panelDev1.Controls.Add(Me.picDev1)
        Me.panelDev1.Location = New System.Drawing.Point(25, 25)
        Me.panelDev1.Name = "panelDev1"
        Me.panelDev1.Size = New System.Drawing.Size(430, 430)
        Me.panelDev1.TabIndex = 0
        '
        'lblDev1Notes
        '
        Me.lblDev1Notes.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev1Notes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblDev1Notes.Location = New System.Drawing.Point(20, 360)
        Me.lblDev1Notes.Name = "lblDev1Notes"
        Me.lblDev1Notes.Size = New System.Drawing.Size(390, 45)
        Me.lblDev1Notes.TabIndex = 6
        Me.lblDev1Notes.Text = "📝 Note: Core Database Design, POS Engine & Print Integration"
        '
        'lblDev1Github
        '
        Me.lblDev1Github.AutoSize = True
        Me.lblDev1Github.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev1Github.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev1Github.Location = New System.Drawing.Point(20, 320)
        Me.lblDev1Github.Name = "lblDev1Github"
        Me.lblDev1Github.Size = New System.Drawing.Size(184, 19)
        Me.lblDev1Github.TabIndex = 5
        Me.lblDev1Github.Text = "🌐 GitHub: github.com/dev1"
        '
        'lblDev1Phone
        '
        Me.lblDev1Phone.AutoSize = True
        Me.lblDev1Phone.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev1Phone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev1Phone.Location = New System.Drawing.Point(20, 285)
        Me.lblDev1Phone.Name = "lblDev1Phone"
        Me.lblDev1Phone.Size = New System.Drawing.Size(193, 19)
        Me.lblDev1Phone.TabIndex = 4
        Me.lblDev1Phone.Text = "📱 Contact: +63 912 345 6789"
        '
        'lblDev1Email
        '
        Me.lblDev1Email.AutoSize = True
        Me.lblDev1Email.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDev1Email.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev1Email.Location = New System.Drawing.Point(20, 250)
        Me.lblDev1Email.Name = "lblDev1Email"
        Me.lblDev1Email.Size = New System.Drawing.Size(191, 19)
        Me.lblDev1Email.TabIndex = 3
        Me.lblDev1Email.Text = "📧 Email: dev1@example.com"
        '
        'lblDev1Role
        '
        Me.lblDev1Role.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblDev1Role.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblDev1Role.Location = New System.Drawing.Point(20, 195)
        Me.lblDev1Role.Name = "lblDev1Role"
        Me.lblDev1Role.Size = New System.Drawing.Size(390, 25)
        Me.lblDev1Role.TabIndex = 2
        Me.lblDev1Role.Text = "Lead Developer & System Architect"
        Me.lblDev1Role.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDev1Name
        '
        Me.lblDev1Name.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblDev1Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDev1Name.Location = New System.Drawing.Point(20, 160)
        Me.lblDev1Name.Name = "lblDev1Name"
        Me.lblDev1Name.Size = New System.Drawing.Size(390, 30)
        Me.lblDev1Name.TabIndex = 1
        Me.lblDev1Name.Text = "Developer 1 Name"
        Me.lblDev1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picDev1
        '
        Me.picDev1.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.picDev1.Location = New System.Drawing.Point(155, 25)
        Me.picDev1.Name = "picDev1"
        Me.picDev1.Size = New System.Drawing.Size(120, 120)
        Me.picDev1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picDev1.TabIndex = 0
        Me.picDev1.TabStop = False
        '
        'DevelopersInfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.panelTop)
        Me.Name = "DevelopersInfoForm"
        Me.Text = "Developers Information"
        Me.panelTop.ResumeLayout(False)
        Me.panelTop.PerformLayout()
        Me.panelMain.ResumeLayout(False)
        Me.panelDev2.ResumeLayout(False)
        Me.panelDev2.PerformLayout()
        CType(Me.picDev2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDev1.ResumeLayout(False)
        Me.panelDev1.PerformLayout()
        CType(Me.picDev1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents panelMain As Panel
    Friend WithEvents panelDev1 As Panel
    Friend WithEvents picDev1 As PictureBox
    Friend WithEvents lblDev1Name As Label
    Friend WithEvents lblDev1Role As Label
    Friend WithEvents lblDev1Email As Label
    Friend WithEvents lblDev1Phone As Label
    Friend WithEvents lblDev1Github As Label
    Friend WithEvents lblDev1Notes As Label
    Friend WithEvents panelDev2 As Panel
    Friend WithEvents picDev2 As PictureBox
    Friend WithEvents lblDev2Name As Label
    Friend WithEvents lblDev2Role As Label
    Friend WithEvents lblDev2Email As Label
    Friend WithEvents lblDev2Phone As Label
    Friend WithEvents lblDev2Github As Label
    Friend WithEvents lblDev2Notes As Label
End Class
