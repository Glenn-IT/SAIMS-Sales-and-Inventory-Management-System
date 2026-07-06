Public Class UnderConstructionForm

    Public Const CURRENT_VERSION As String = "v1.08"
    ' Numeric twin of CURRENT_VERSION for "is this feature unlocked yet?" comparisons.
    ' Bump both constants together when moving to the next presentation version.
    Public Const CURRENT_VERSION_NUMBER As Integer = 8

    Private Sub UnderConstructionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = "Current Version: " & CURRENT_VERSION
        CenterContent()
    End Sub

    Private Sub UnderConstructionForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CenterContent()
    End Sub

    ''' Keeps pnlCenter centered as the form is stretched to fill panelContent.
    Private Sub CenterContent()
        pnlCenter.Left = Math.Max(0, (Me.ClientSize.Width - pnlCenter.Width) \ 2)
        pnlCenter.Top = Math.Max(0, (Me.ClientSize.Height - pnlCenter.Height) \ 2)
    End Sub

End Class
