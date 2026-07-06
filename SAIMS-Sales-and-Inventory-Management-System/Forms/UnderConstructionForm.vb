Public Class UnderConstructionForm

    Public Const CURRENT_VERSION As String = "v1.02"

    Private Sub UnderConstructionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = "Current Version: " & CURRENT_VERSION
    End Sub

    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Me.Close()
    End Sub

End Class
