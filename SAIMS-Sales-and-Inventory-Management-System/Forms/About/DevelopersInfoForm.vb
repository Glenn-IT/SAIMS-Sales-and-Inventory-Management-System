Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Reflection

Public Class DevelopersInfoForm

    Private Sub DevelopersInfoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picDev1.Image = LoadDeveloperAvatar("Aaron Jake.jpg", "AJ", Color.FromArgb(46, 204, 113), 100, 420, 950, 950)
        picDev2.Image = LoadDeveloperAvatar("Peejay.jpg", "PT", Color.FromArgb(52, 152, 219), 240, 400, 1050, 1050)
    End Sub

    ''' <summary>
    ''' Attempts to locate an image file from the img directory across runtime and solution paths,
    ''' crops it neatly to focus on the portrait face, and renders a circular anti-aliased avatar.
    ''' Falls back to a clean initial-based circular placeholder if the image file is not found.
    ''' </summary>
    Private Function LoadDeveloperAvatar(fileName As String, initials As String, accentColor As Color,
                                         Optional cropX As Integer = 0, Optional cropY As Integer = 0,
                                         Optional cropW As Integer = 0, Optional cropH As Integer = 0) As Image
        Const targetSize As Integer = 120

        Try
            Dim imgPath As String = FindImageFile(fileName)
            If Not String.IsNullOrEmpty(imgPath) AndAlso File.Exists(imgPath) Then
                Using rawImg As Image = Image.FromFile(imgPath)
                    Return RenderCircularAvatar(rawImg, targetSize, accentColor, cropX, cropY, cropW, cropH)
                End Using
            End If

            ' Check embedded resource in assembly
            Dim asm = Assembly.GetExecutingAssembly()
            Dim resNames = asm.GetManifestResourceNames()
            Dim match = resNames.FirstOrDefault(Function(n) n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase))
            If Not String.IsNullOrEmpty(match) Then
                Using s = asm.GetManifestResourceStream(match)
                    If s IsNot Nothing Then
                        Using rawImg = Image.FromStream(s)
                            Return RenderCircularAvatar(rawImg, targetSize, accentColor, cropX, cropY, cropW, cropH)
                        End Using
                    End If
                End Using
            End If
        Catch ex As Exception
            ' Fallback to initials avatar on error
        End Try

        Return CreateInitialsAvatar(initials, accentColor, targetSize)
    End Function

    Private Function FindImageFile(fileName As String) As String
        Dim candidatePaths As String() = {
            Path.Combine(Application.StartupPath, "img", fileName),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", fileName),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\img", fileName)),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\..\SAIMS-Sales-and-Inventory-Management-System\img", fileName)),
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\..\..\SAIMS-Sales-and-Inventory-Management-System\img", fileName)),
            Path.Combine(Application.StartupPath, fileName)
        }

        For Each p In candidatePaths
            Try
                If File.Exists(p) Then Return p
            Catch
            End Try
        Next

        ' Walk up parent directories to search for img\fileName
        Try
            Dim curr = New DirectoryInfo(Application.StartupPath)
            While curr IsNot Nothing
                Dim testPath = Path.Combine(curr.FullName, "img", fileName)
                If File.Exists(testPath) Then Return testPath
                Dim projSubPath = Path.Combine(curr.FullName, "SAIMS-Sales-and-Inventory-Management-System", "img", fileName)
                If File.Exists(projSubPath) Then Return projSubPath
                curr = curr.Parent
            End While
        Catch
        End Try

        Return Nothing
    End Function

    Private Function RenderCircularAvatar(src As Image, size As Integer, borderColor As Color,
                                          cropX As Integer, cropY As Integer, cropW As Integer, cropH As Integer) As Bitmap
        Dim bmp As New Bitmap(size, size)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = PixelOffsetMode.HighQuality
            g.Clear(Color.Transparent)

            ' If custom crop rect wasn't provided or exceeds image bounds, auto-crop square from top-center
            Dim srcRect As Rectangle
            If cropW > 0 AndAlso cropH > 0 AndAlso (cropX + cropW <= src.Width) AndAlso (cropY + cropH <= src.Height) Then
                srcRect = New Rectangle(cropX, cropY, cropW, cropH)
            Else
                Dim side = Math.Min(src.Width, src.Height)
                Dim autoX = Math.Max(0, (src.Width - side) \ 2)
                Dim autoY = If(src.Height > src.Width, Math.Min(CInt(src.Height * 0.15), src.Height - side), 0)
                srcRect = New Rectangle(autoX, autoY, side, side)
            End If

            Using path As New GraphicsPath()
                path.AddEllipse(2, 2, size - 4, size - 4)
                g.SetClip(path)
                g.DrawImage(src, New Rectangle(0, 0, size, size), srcRect, GraphicsUnit.Pixel)
            End Using

            Using pen As New Pen(borderColor, 3)
                g.DrawEllipse(pen, 2, 2, size - 4, size - 4)
            End Using
        End Using

        Return bmp
    End Function

    Private Function CreateInitialsAvatar(initials As String, bgCircleColor As Color, size As Integer) As Bitmap
        Dim bmp As New Bitmap(size, size)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)

            Using b As New SolidBrush(bgCircleColor)
                g.FillEllipse(b, 4, 4, size - 8, size - 8)
            End Using

            Using font As New Font("Segoe UI", 36, FontStyle.Bold)
                Using bText As New SolidBrush(Color.White)
                    Dim textSize As SizeF = g.MeasureString(initials, font)
                    Dim x As Single = (size - textSize.Width) / 2
                    Dim y As Single = (size - textSize.Height) / 2
                    g.DrawString(initials, font, bText, x, y)
                End Using
            End Using
        End Using
        Return bmp
    End Function

End Class
