Public Class ProductsForm

    Private _allProducts As DataTable

    Private Sub ProductsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        Try
            _allProducts = ProductRepository.GetAll()
            dgvProducts.DataSource = Nothing
            dgvProducts.Rows.Clear()

            For Each row As DataRow In _allProducts.Rows
                Dim stockStatus As String = row("StockStatus").ToString()
                dgvProducts.Rows.Add(
                    row("Barcode").ToString(),
                    row("ProductName").ToString(),
                    row("CategoryName").ToString(),
                    FormatCurrency(CDec(row("Price"))),
                    row("Stock").ToString(),
                    stockStatus)
            Next

            UpdateRecordCount()

        Catch ex As Exception
            MessageBox.Show("Failed to load products." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateRecordCount()
        Dim visible = dgvProducts.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow AndAlso r.Visible)
        lblTotalRecords.Text = "Total Record: " & visible & " products"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterProducts()
    End Sub

    Private Sub FilterProducts()
        Dim searchText As String = txtSearch.Text.ToLower()

        For Each row As DataGridViewRow In dgvProducts.Rows
            If row.IsNewRow Then Continue For
            Dim visible As Boolean = False
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value IsNot Nothing AndAlso cell.Value.ToString().ToLower().Contains(searchText) Then
                    visible = True
                    Exit For
                End If
            Next
            row.Visible = visible
        Next

        UpdateRecordCount()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using dlg As New ProductDialogForm()
            dlg.IsEditMode = False

            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

            Try
                If ProductRepository.BarcodeExists(dlg.BarcodeInput) Then
                    MessageBox.Show("A product with that barcode already exists.", "Duplicate Barcode",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ProductRepository.Insert(dlg.BarcodeInput, dlg.ProductNameInput, dlg.CategoryIDInput,
                                         dlg.PriceInput, dlg.StockInput, dlg.LowStockQtyInput)
                ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                                   $"Added product: {dlg.ProductNameInput} (Barcode: {dlg.BarcodeInput})")

                MessageBox.Show("Product added successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProducts()

            Catch ex As Microsoft.Data.SqlClient.SqlException
                Dim msg As String = InputHelper.GetConstraintMessage(ex)
                MessageBox.Show(If(msg, "Failed to add product." & Environment.NewLine & ex.Message),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Failed to add product." & Environment.NewLine & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to edit.", "Edit Product",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedBarcode As String = dgvProducts.SelectedRows(0).Cells(0).Value.ToString()

        Try
            Dim dt As DataTable = ProductRepository.GetAll()
            Dim productRow As DataRow = Nothing
            For Each r As DataRow In dt.Rows
                If r("Barcode").ToString() = selectedBarcode Then
                    productRow = r
                    Exit For
                End If
            Next

            If productRow Is Nothing Then Return

            Dim productID As Integer = CInt(productRow("ProductID"))

            Using dlg As New ProductDialogForm()
                dlg.IsEditMode = True
                dlg.ProductID = productID
                dlg.BarcodeInput = productRow("Barcode").ToString()
                dlg.ProductNameInput = productRow("ProductName").ToString()
                dlg.CategoryIDInput = CInt(productRow("CategoryID"))
                dlg.PriceInput = CDec(productRow("Price"))
                dlg.StockInput = CInt(productRow("Stock"))
                dlg.LowStockQtyInput = CInt(productRow("LowStockQty"))
                dlg.StatusInput = productRow("Status").ToString()

                If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

                If ProductRepository.BarcodeExists(dlg.BarcodeInput, productID) Then
                    MessageBox.Show("A product with that barcode already exists.", "Duplicate Barcode",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ProductRepository.Update(productID, dlg.BarcodeInput, dlg.ProductNameInput,
                                         dlg.CategoryIDInput, dlg.PriceInput,
                                         dlg.LowStockQtyInput, dlg.StatusInput)

                ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                                   $"Updated product: {dlg.ProductNameInput} (ID: {productID})")

                MessageBox.Show("Product updated successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProducts()
            End Using

        Catch ex As Exception
            MessageBox.Show("Failed to update product." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to delete.", "Delete Product",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedName    As String = dgvProducts.SelectedRows(0).Cells(1).Value.ToString()
        Dim selectedBarcode As String = dgvProducts.SelectedRows(0).Cells(0).Value.ToString()

        Dim confirm = MessageBox.Show($"Delete ""{selectedName}""? This cannot be undone.",
                                      "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Dim dt As DataTable = ProductRepository.GetAll()
            Dim productID As Integer = 0
            For Each r As DataRow In dt.Rows
                If r("Barcode").ToString() = selectedBarcode Then
                    productID = CInt(r("ProductID"))
                    Exit For
                End If
            Next

            If productID = 0 Then Return

            ProductRepository.Delete(productID)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Deleted product: {selectedName} (ID: {productID})")

            MessageBox.Show("Product deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProducts()

        Catch ex As Microsoft.Data.SqlClient.SqlException
            Dim msg As String = InputHelper.GetConstraintMessage(ex)
            MessageBox.Show(If(msg, "Failed to delete product." & Environment.NewLine & ex.Message),
                            "Cannot Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Failed to delete product." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadProducts()
    End Sub

    Private Sub dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellContentClick
    End Sub

End Class
