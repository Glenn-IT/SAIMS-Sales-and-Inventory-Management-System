Public Class CategoriesForm
    Private Sub CategoriesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSampleData()
    End Sub

    Private Sub LoadSampleData()
        dgvCategories.Rows.Clear()

        dgvCategories.Rows.Add("C001", "Beverages", "Drinks and beverages", "Active")
        dgvCategories.Rows.Add("C002", "Noodles", "Instant and dry noodles", "Active")
        dgvCategories.Rows.Add("C003", "Canned Goods", "Canned food products", "Active")
        dgvCategories.Rows.Add("C004", "Groceries", "General groceries", "Active")
        dgvCategories.Rows.Add("C005", "Household", "Household items", "Active")
        dgvCategories.Rows.Add("C006", "Dairy", "Milk and dairy products", "Active")
        dgvCategories.Rows.Add("C007", "Snacks", "Chips and snacks", "Active")
        dgvCategories.Rows.Add("C008", "Personal Care", "Hygiene products", "Active")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MessageBox.Show("Add Category functionality - UI Only", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvCategories.SelectedRows.Count > 0 Then
            MessageBox.Show("Edit Category functionality - UI Only", "Edit Category", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select a category to edit", "Edit Category", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvCategories.SelectedRows.Count > 0 Then
            Dim result = MessageBox.Show("Delete this category?", "Delete Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                MessageBox.Show("Delete functionality - UI Only", "Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Please select a category to delete", "Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadSampleData()
    End Sub
End Class
