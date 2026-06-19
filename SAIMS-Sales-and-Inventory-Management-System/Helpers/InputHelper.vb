Public Module InputHelper

    Public Function SanitizeInput(text As String) As String
        If String.IsNullOrWhiteSpace(text) Then Return String.Empty
        Return text.Trim().Replace("<", "").Replace(">", "").Replace(Chr(0), "")
    End Function

End Module
