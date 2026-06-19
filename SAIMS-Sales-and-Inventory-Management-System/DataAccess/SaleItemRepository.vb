Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module SaleItemRepository

    Public Function GetBySaleID(saleID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT si.SaleItemID, p.Barcode, p.ProductName,
                        si.Quantity, si.UnitPrice, si.LineTotal
                 FROM tbl_SaleItems si
                 INNER JOIN tbl_Products p ON si.ProductID = p.ProductID
                 WHERE si.SaleID = @saleID", con)
            cmd.Parameters.AddWithValue("@saleID", saleID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub Insert(saleID As Integer, productID As Integer,
                      quantity As Integer, unitPrice As Decimal, lineTotal As Decimal)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_SaleItems (SaleID, ProductID, Quantity, UnitPrice, LineTotal)
                 VALUES (@saleID, @productID, @qty, @unitPrice, @lineTotal)", con)
                cmd.Parameters.AddWithValue("@saleID",    saleID)
                cmd.Parameters.AddWithValue("@productID", productID)
                cmd.Parameters.AddWithValue("@qty",       quantity)
                cmd.Parameters.AddWithValue("@unitPrice", unitPrice)
                cmd.Parameters.AddWithValue("@lineTotal", lineTotal)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
