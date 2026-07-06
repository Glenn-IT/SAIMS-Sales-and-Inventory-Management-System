Public Module PasswordHelper

    Public Function HashPassword(plainText As String) As String
        Return BCrypt.Net.BCrypt.HashPassword(plainText)
    End Function

    Public Function VerifyPassword(plainText As String, hash As String) As Boolean
        Return BCrypt.Net.BCrypt.Verify(plainText, hash)
    End Function

    ' Security answers are normalized (trimmed + lowercased) before hashing/verifying
    ' so users aren't tripped up by casing or stray whitespace.
    Public Function HashAnswer(plainAnswer As String) As String
        Return BCrypt.Net.BCrypt.HashPassword(NormalizeAnswer(plainAnswer))
    End Function

    Public Function VerifyAnswer(plainAnswer As String, hash As String) As Boolean
        Return BCrypt.Net.BCrypt.Verify(NormalizeAnswer(plainAnswer), hash)
    End Function

    Private Function NormalizeAnswer(answer As String) As String
        Return If(answer, "").Trim().ToLowerInvariant()
    End Function

End Module
