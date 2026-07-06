Public Class CategoriesForm

    Private Sub CategoriesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.03
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE

        LoadCategories()
    End Sub

    Private Sub LoadCategories()
        Try
            Dim dt As DataTable = CategoryRepository.GetAll()
            dgvCategories.Rows.Clear()

            For Each row As DataRow In dt.Rows
                dgvCategories.Rows.Add(
                    row("CategoryID").ToString(),
                    row("CategoryName").ToString(),
                    row("Description").ToString(),
                    row("Status").ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Failed to load categories." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim name As String = InputHelper.SanitizeInput(InputBox("Enter Category Name:", "Add Category"))
        Dim desc As String = InputHelper.SanitizeInput(InputBox("Enter Description:", "Add Category"))

        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Category name is required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If CategoryRepository.Exists(name) Then
                MessageBox.Show("A category with that name already exists.", "Duplicate",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            CategoryRepository.Insert(name, desc)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Added category: {name}")

            MessageBox.Show("Category added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCategories()

        Catch ex As Microsoft.Data.SqlClient.SqlException
            Dim msg As String = InputHelper.GetConstraintMessage(ex)
            MessageBox.Show(If(msg, "Failed to add category." & Environment.NewLine & ex.Message),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Failed to add category." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvCategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to edit.", "Edit Category",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvCategories.SelectedRows(0)
        Dim categoryID  As Integer = CInt(selectedRow.Cells(0).Value)
        Dim currentName As String  = selectedRow.Cells(1).Value.ToString()
        Dim currentDesc As String  = selectedRow.Cells(2).Value.ToString()
        Dim currentStatus As String = selectedRow.Cells(3).Value.ToString()

        Dim newName As String = InputHelper.SanitizeInput(
                                 InputBox("Category Name:", "Edit Category", currentName))
        Dim newDesc As String = InputHelper.SanitizeInput(
                                 InputBox("Description:", "Edit Category", currentDesc))

        If String.IsNullOrWhiteSpace(newName) Then Return

        Try
            If CategoryRepository.Exists(newName, categoryID) Then
                MessageBox.Show("A category with that name already exists.", "Duplicate",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            CategoryRepository.Update(categoryID, newName, newDesc, currentStatus)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Updated category: {newName} (ID: {categoryID})")

            MessageBox.Show("Category updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCategories()

        Catch ex As Exception
            MessageBox.Show("Failed to update category." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvCategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to delete.", "Delete Category",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow  As DataGridViewRow = dgvCategories.SelectedRows(0)
        Dim categoryID   As Integer = CInt(selectedRow.Cells(0).Value)
        Dim categoryName As String  = selectedRow.Cells(1).Value.ToString()

        Dim confirm = MessageBox.Show($"Delete ""{categoryName}""? This cannot be undone.",
                                      "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            CategoryRepository.Delete(categoryID)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Deleted category: {categoryName} (ID: {categoryID})")

            MessageBox.Show("Category deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCategories()

        Catch ex As Exception
            MessageBox.Show("Failed to delete category." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadCategories()
    End Sub

End Class
