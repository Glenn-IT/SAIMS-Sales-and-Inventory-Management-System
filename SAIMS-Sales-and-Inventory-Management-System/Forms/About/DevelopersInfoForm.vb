Imports System.Drawing

Public Class DevelopersInfoForm

    Private Sub DevelopersInfoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDefaultAvatar(picDev1, "D1", Color.FromArgb(46, 204, 113))
        SetDefaultAvatar(picDev2, "D2", Color.FromArgb(52, 152, 219))
    End Sub

    ''' <summary>
    ''' Draws a clean circular avatar image placeholder with initials.
    ''' Replace picDev1.Image or picDev2.Image with Image.FromFile("path/to/image.jpg") if desired.
    ''' </summary>
    Private Sub SetDefaultAvatar(pic As PictureBox, initials As String, bgCircleColor As Color)
        Dim bmp As New Bitmap(120, 120)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            ' Background fill
            g.Clear(Color.FromArgb(236, 240, 241))

            ' Circular avatar background
            Using b As New SolidBrush(bgCircleColor)
                g.FillEllipse(b, 5, 5, 110, 110)
            End Using

            ' Draw Initials text
            Using font As New Font("Segoe UI", 36, FontStyle.Bold)
                Using bText As New SolidBrush(Color.White)
                    Dim textSize As SizeF = g.MeasureString(initials, font)
                    Dim x As Single = (120 - textSize.Width) / 2
                    Dim y As Single = (120 - textSize.Height) / 2
                    g.DrawString(initials, font, bText, x, y)
                End Using
            End Using
        End Using
        pic.Image = bmp
    End Sub

End Class
