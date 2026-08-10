Imports System.Data

Public Class ProductDialogForm

    Private Class CategoryComboItem
        Public Property ID As Integer
        Public Property Name As String
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Public Property IsEditMode As Boolean = False
    Public Property ProductID As Integer = 0
    Public Property BarcodeInput As String = ""
    Public Property ProductNameInput As String = ""
    Public Property CategoryIDInput As Integer = 0
    Public Property PriceInput As Decimal = 0
    Public Property StockInput As Integer = 0
    Public Property LowStockQtyInput As Integer = Constants.DEFAULT_LOW_STOCK_QTY
    Public Property StatusInput As String = Constants.STATUS_ACTIVE

    Private Sub ProductDialogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        cboStatus.SelectedItem = Constants.STATUS_ACTIVE

        If IsEditMode Then
            lblHeaderTitle.Text = "Edit Product"
            Me.Text = "Edit Product Details"
            txtBarcode.Text = BarcodeInput
            txtProductName.Text = ProductNameInput
            txtPrice.Text = PriceInput.ToString("F2")
            numStock.Value = Math.Max(0, StockInput)
            numStock.Enabled = False ' Stock modified via Stock In / Out
            numLowStock.Value = Math.Max(0, LowStockQtyInput)

            If Not String.IsNullOrEmpty(StatusInput) AndAlso cboStatus.Items.Contains(StatusInput) Then
                cboStatus.SelectedItem = StatusInput
            End If

            ' Select Category
            For Each item As CategoryComboItem In cboCategory.Items
                If item.ID = CategoryIDInput Then
                    cboCategory.SelectedItem = item
                    Exit For
                End If
            Next
        Else
            lblHeaderTitle.Text = "Add New Product"
            Me.Text = "Add New Product"
            txtBarcode.Text = ""
            txtProductName.Text = ""
            txtPrice.Text = ""
            numStock.Value = 0
            numStock.Enabled = True
            numLowStock.Value = Constants.DEFAULT_LOW_STOCK_QTY
            cboStatus.SelectedItem = Constants.STATUS_ACTIVE
            If cboCategory.Items.Count > 0 Then cboCategory.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadCategories()
        cboCategory.Items.Clear()
        Try
            Dim dt As DataTable = CategoryRepository.GetActive()
            For Each row As DataRow In dt.Rows
                cboCategory.Items.Add(New CategoryComboItem() With {
                    .ID = CInt(row("CategoryID")),
                    .Name = row("CategoryName").ToString()
                })
            Next
        Catch ex As Exception
            MessageBox.Show("Failed to load active categories." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim barcode As String = InputHelper.SanitizeInput(txtBarcode.Text.Trim())
        Dim name As String = InputHelper.SanitizeInput(txtProductName.Text.Trim())

        If String.IsNullOrWhiteSpace(barcode) Then
            MessageBox.Show("Barcode is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Product Name is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
            Return
        End If

        If cboCategory.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a category.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text.Trim(), price) OrElse price <= 0 Then
            MessageBox.Show("Please enter a valid price greater than 0.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return
        End If

        Dim selectedCat As CategoryComboItem = CType(cboCategory.SelectedItem, CategoryComboItem)

        BarcodeInput = barcode
        ProductNameInput = name
        CategoryIDInput = selectedCat.ID
        PriceInput = price
        StockInput = CInt(numStock.Value)
        LowStockQtyInput = CInt(numLowStock.Value)
        StatusInput = If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString(), Constants.STATUS_ACTIVE)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
