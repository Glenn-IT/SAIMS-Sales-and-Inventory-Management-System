Public Class ProductsForm
    Private Sub ProductsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSampleData()
        lblTotalRecords.Text = "Total: " & dgvProducts.Rows.Count & " products"
    End Sub

    Private Sub LoadSampleData()
        dgvProducts.Rows.Clear()

        dgvProducts.Rows.Add("P001", "Coca Cola 1.5L", "Beverages", "?55.00", "150", "Available")
        dgvProducts.Rows.Add("P002", "Lucky Me Pancit Canton", "Noodles", "?12.50", "200", "Available")
        dgvProducts.Rows.Add("P003", "Argentina Corned Beef", "Canned Goods", "?45.00", "80", "Available")
        dgvProducts.Rows.Add("P004", "Red Horse Beer", "Beverages", "?50.00", "100", "Available")
        dgvProducts.Rows.Add("P005", "Payless White Sugar 1kg", "Groceries", "?65.00", "60", "Available")
        dgvProducts.Rows.Add("P006", "Champion Detergent", "Household", "?8.50", "120", "Available")
        dgvProducts.Rows.Add("P007", "San Miguel Pale Pilsen", "Beverages", "?45.00", "5", "Low Stock")
        dgvProducts.Rows.Add("P008", "Del Monte Tomato Sauce", "Canned Goods", "?18.00", "90", "Available")
        dgvProducts.Rows.Add("P009", "Alaska Condensed Milk", "Dairy", "?35.00", "0", "Out of Stock")
        dgvProducts.Rows.Add("P010", "Jack n Jill Piattos", "Snacks", "?25.00", "110", "Available")
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

        Dim visibleCount = dgvProducts.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow AndAlso r.Visible)
        lblTotalRecords.Text = "Total: " & visibleCount & " products"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MessageBox.Show("Add Product functionality - UI Only", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvProducts.SelectedRows.Count > 0 Then
            MessageBox.Show("Edit Product functionality - UI Only", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select a product to edit", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim result = MessageBox.Show("Delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                MessageBox.Show("Delete functionality - UI Only", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Please select a product to delete", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadSampleData()
        lblTotalRecords.Text = "Total: " & dgvProducts.Rows.Count & " products"
    End Sub

    Private Sub dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellContentClick
        If e.RowIndex >= 0 Then
            MessageBox.Show("Row action - UI Only", "Action", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
