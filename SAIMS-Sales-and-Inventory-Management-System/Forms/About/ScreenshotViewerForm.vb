Imports System.Drawing
Imports System.Windows.Forms

Public Class ScreenshotViewerForm
    Inherits Form

    Private picBox As PictureBox
    Private panelScroll As Panel
    Private lblTitle As Label
    Private btnActualSize As Button
    Private btnFit As Button
    Private btnClose As Button
    Private originalImage As Image
    Private isActualSize As Boolean = False

    Public Sub New(imageTitle As String, img As Image)
        Me.originalImage = img
        InitializeUI(imageTitle)
    End Sub

    Private Sub InitializeUI(imageTitle As String)
        Me.Text = "Screenshot Viewer - " & imageTitle
        Me.Size = New Size(1150, 750)
        Me.MinimumSize = New Size(700, 500)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.BackColor = Color.FromArgb(30, 32, 35)

        ' Top control bar
        Dim panelTop As New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 50,
            .BackColor = Color.FromArgb(44, 62, 80),
            .Padding = New Padding(15, 8, 15, 8)
        }

        lblTitle = New Label() With {
            .Text = "Preview: " & imageTitle,
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = True,
            .Location = New Point(15, 13)
        }

        Dim panelButtons As New FlowLayoutPanel() With {
            .Dock = DockStyle.Right,
            .FlowDirection = FlowDirection.RightToLeft,
            .AutoSize = True,
            .Padding = New Padding(0, 4, 0, 0)
        }

        btnClose = New Button() With {
            .Text = "Close",
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(231, 76, 60),
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(85, 32),
            .Cursor = Cursors.Hand
        }
        btnClose.FlatAppearance.BorderSize = 0
        AddHandler btnClose.Click, Sub() Me.Close()

        btnActualSize = New Button() With {
            .Text = "Actual Size (100%)",
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Regular),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(52, 152, 219),
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(130, 32),
            .Cursor = Cursors.Hand
        }
        btnActualSize.FlatAppearance.BorderSize = 0
        AddHandler btnActualSize.Click, Sub() ToggleSize(True)

        btnFit = New Button() With {
            .Text = "Fit to Window",
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Regular),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(41, 128, 185),
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(110, 32),
            .Cursor = Cursors.Hand
        }
        btnFit.FlatAppearance.BorderSize = 0
        AddHandler btnFit.Click, Sub() ToggleSize(False)

        panelButtons.Controls.Add(btnClose)
        panelButtons.Controls.Add(btnActualSize)
        panelButtons.Controls.Add(btnFit)

        panelTop.Controls.Add(panelButtons)
        panelTop.Controls.Add(lblTitle)

        ' Main Image View Container
        panelScroll = New Panel() With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.FromArgb(25, 27, 29)
        }

        picBox = New PictureBox() With {
            .Image = originalImage,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .Dock = DockStyle.Fill,
            .BackColor = Color.Transparent
        }

        panelScroll.Controls.Add(picBox)

        Me.Controls.Add(panelScroll)
        Me.Controls.Add(panelTop)
    End Sub

    Private Sub ToggleSize(actualSize As Boolean)
        isActualSize = actualSize
        If isActualSize Then
            picBox.Dock = DockStyle.None
            picBox.SizeMode = PictureBoxSizeMode.AutoSize
            picBox.Location = New Point(10, 10)
            btnActualSize.BackColor = Color.FromArgb(39, 174, 96)
            btnFit.BackColor = Color.FromArgb(52, 152, 219)
        Else
            picBox.Dock = DockStyle.Fill
            picBox.SizeMode = PictureBoxSizeMode.Zoom
            btnFit.BackColor = Color.FromArgb(39, 174, 96)
            btnActualSize.BackColor = Color.FromArgb(52, 152, 219)
        End If
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
    End Sub

End Class
