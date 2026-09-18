Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SAIMS_Sales_and_Inventory_Management_System

Namespace SAIMS.Tests

    <TestClass>
    Public Class ScreenshotGenerator

        <DllImport("user32.dll")>
        Private Shared Function PrintWindow(hwnd As IntPtr, hdcBlt As IntPtr, nFlags As UInteger) As Boolean
        End Function

        Private Const PW_RENDERFULLCONTENT As UInteger = 2

        Private Function CaptureFormWithWindow(form As Form, width As Integer, height As Integer) As Bitmap
            form.StartPosition = FormStartPosition.Manual
            form.Location = New Point(0, 0)
            form.Size = New Size(width, height)
            form.Show()
            Application.DoEvents()
            Thread.Sleep(400)
            Application.DoEvents()

            Dim bmp As New Bitmap(form.Width, form.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                Dim hdc As IntPtr = g.GetHdc()
                Try
                    PrintWindow(form.Handle, hdc, PW_RENDERFULLCONTENT)
                Finally
                    g.ReleaseHdc(hdc)
                End Try
            End Using
            form.Hide()
            Return bmp
        End Function

        <TestMethod>
        Public Sub CaptureDevelopersInfo()
            Dim th As New Thread(Sub()
                Try
                    SessionManager.Username = "admin"
                    SessionManager.FullName = "Glenn (Admin)"
                    SessionManager.UserType = Constants.USERTYPE_ADMIN

                    Dim outDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots")
                    If Not Directory.Exists(outDir) Then Directory.CreateDirectory(outDir)

                    Using f As New DevelopersInfoForm()
                        Using bmp = CaptureFormWithWindow(f, 1000, 600)
                            bmp.Save(Path.Combine(outDir, "DevelopersInfoForm.png"), ImageFormat.Png)
                        End Using
                    End Using

                Catch ex As Exception
                    Assert.Fail(ex.ToString())
                End Try
            End Sub)
            th.SetApartmentState(ApartmentState.STA)
            th.Start()
            th.Join()
        End Sub

    End Class

End Namespace
