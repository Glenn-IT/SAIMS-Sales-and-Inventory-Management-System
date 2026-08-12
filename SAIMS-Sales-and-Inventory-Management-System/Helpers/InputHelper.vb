Imports Microsoft.Data.SqlClient

Public Module InputHelper

    Public Function SanitizeInput(text As String) As String
        If String.IsNullOrWhiteSpace(text) Then Return String.Empty
        Return text.Trim().Replace("<", "").Replace(">", "").Replace(Chr(0), "")
    End Function

    ''' <summary>
    ''' Returns a user-friendly message for SQL Server constraint/duplicate errors,
    ''' or Nothing if the exception is not a known constraint violation.
    ''' </summary>
    Public Function GetConstraintMessage(ex As SqlException) As String
        ' 2627 = unique constraint, 2601 = duplicate index
        If ex.Number = 2627 OrElse ex.Number = 2601 Then
            If ex.Message.Contains("tbl_Products") OrElse ex.Message.Contains("Barcode") Then
                Return "A product with that barcode already exists."
            ElseIf ex.Message.Contains("tbl_Users") OrElse ex.Message.Contains("Username") Then
                Return "That username is already taken."
            ElseIf ex.Message.Contains("tbl_Categories") Then
                Return "A category with that name already exists."
            ElseIf ex.Message.Contains("ReceiptNo") Then
                Return "A receipt with that number already exists. Please try again."
            Else
                Return "A duplicate record already exists."
            End If
        ElseIf ex.Number = 547 Then
            If ex.Message.Contains("tbl_SaleItems") OrElse ex.Message.Contains("FK_tbl_Salel_Produ") Then
                Return "Cannot delete this product because it has associated sales records." & Environment.NewLine &
                       "To disable this product, edit it and set its Status to 'Inactive'."
            ElseIf ex.Message.Contains("tbl_Products") Then
                Return "Cannot delete this item because it is referenced by existing products."
            Else
                Return "Cannot delete this record because it is referenced elsewhere in the system."
            End If
        End If
        Return Nothing
    End Function

End Module
