<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UnderConstructionForm
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
        Me.pnlCenter = New System.Windows.Forms.Panel()
        Me.lblEmoji = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.pnlCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCenter
        '
        Me.pnlCenter.Controls.Add(Me.lblEmoji)
        Me.pnlCenter.Controls.Add(Me.lblVersion)
        Me.pnlCenter.Controls.Add(Me.lblTitle)
        Me.pnlCenter.Controls.Add(Me.lblDescription)
        Me.pnlCenter.Location = New System.Drawing.Point(0, 0)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(500, 320)
        Me.pnlCenter.TabIndex = 0
        '
        'lblEmoji
        '
        Me.lblEmoji.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEmoji.Font = New System.Drawing.Font("Segoe UI Emoji", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblEmoji.ForeColor = System.Drawing.Color.White
        Me.lblEmoji.Location = New System.Drawing.Point(0, 0)
        Me.lblEmoji.Name = "lblEmoji"
        Me.lblEmoji.Size = New System.Drawing.Size(500, 100)
        Me.lblEmoji.TabIndex = 0
        Me.lblEmoji.Text = "🚧"
        Me.lblEmoji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVersion
        '
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblVersion.ForeColor = System.Drawing.Color.Orange
        Me.lblVersion.Location = New System.Drawing.Point(0, 100)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(500, 30)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Current Version: v1.00"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 130)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(500, 60)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Under Construction"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDescription
        '
        Me.lblDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDescription.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblDescription.Location = New System.Drawing.Point(0, 190)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(500, 60)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "This feature is not yet available in the current presentation version."
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UnderConstructionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(900, 600)
        Me.Controls.Add(Me.pnlCenter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UnderConstructionForm"
        Me.Text = "Under Construction"
        Me.pnlCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCenter As Panel
    Friend WithEvents lblEmoji As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblDescription As Label
End Class
