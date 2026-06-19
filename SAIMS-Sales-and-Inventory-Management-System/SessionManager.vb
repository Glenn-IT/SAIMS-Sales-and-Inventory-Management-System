Public Module SessionManager

    Public UserID   As Integer = 0
    Public Username As String  = ""
    Public FullName As String  = ""
    Public UserType As String  = ""

    Public Sub Clear()
        UserID   = 0
        Username = ""
        FullName = ""
        UserType = ""
    End Sub

End Module
