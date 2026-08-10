Imports System.Data

Public Class SalesItemDialogForm

    Private Class ProductComboItem
        Public Property ProductID As Integer
        Public Property Barcode As String
        Public Property Name As String
        Public Property Price As Decimal
        Public Property Stock As Integer
        Public Overrides Function ToString() As String
            Return $"{Name} ({Barcode}) — ₱{Price:N2} [Stock: {Stock}]"
        End Function
    End Class

    Public Property SelectedBarcode As String = ""
    Public Property SelectedQuantity As Integer = 1
    Private _isLoading As Boolean = True

    Private Sub SalesItemDialogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        _isLoading = False
        UpdateCalculations()
    End Sub

    Private Sub LoadProducts()
        _isLoading = True
        cboProduct.Items.Clear()
        Try
            Dim dt As DataTable = ProductRepository.GetAll()
            For Each row As DataRow In dt.Rows
                If row("Status").ToString() = Constants.STATUS_ACTIVE Then
                    cboProduct.Items.Add(New ProductComboItem() With {
                        .ProductID = CInt(row("ProductID")),
                        .Barcode   = row("Barcode").ToString(),
                        .Name      = row("ProductName").ToString(),
                        .Price     = CDec(row("Price")),
                        .Stock     = CInt(row("Stock"))
                    })
                End If
            Next

            If cboProduct.Items.Count > 0 Then
                cboProduct.SelectedIndex = 0
                SyncFromCombo()
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to load products." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        _isLoading = False
    End Sub

    Private Sub cboProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProduct.SelectedIndexChanged
        If _isLoading Then Return
        SyncFromCombo()
    End Sub

    Private Sub SyncFromCombo()
        If cboProduct.SelectedItem IsNot Nothing Then
            Dim item As ProductComboItem = CType(cboProduct.SelectedItem, ProductComboItem)
            txtBarcode.Text = item.Barcode
            UpdateCalculations()
        End If
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        If _isLoading Then Return
        Dim code As String = txtBarcode.Text.Trim().ToUpper()
        For Each item As ProductComboItem In cboProduct.Items
            If item.Barcode.ToUpper() = code Then
                _isLoading = True
                cboProduct.SelectedItem = item
                _isLoading = False
                Exit For
            End If
        Next
        UpdateCalculations()
    End Sub

    Private Sub numQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numQuantity.ValueChanged
        UpdateCalculations()
    End Sub

    Private Sub UpdateCalculations()
        If cboProduct.SelectedItem IsNot Nothing Then
            Dim item As ProductComboItem = CType(cboProduct.SelectedItem, ProductComboItem)
            Dim qty As Integer = CInt(numQuantity.Value)
            Dim total As Decimal = item.Price * qty
            lblStock.Text = $"Available Stock: {item.Stock}"
            lblPriceInfo.Text = $"Unit Price: ₱{item.Price:N2}  |  Total: ₱{total:N2}"
        Else
            lblStock.Text = "Available: --"
            lblPriceInfo.Text = "Total Price: ₱0.00"
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim barcodeInput As String = InputHelper.SanitizeInput(txtBarcode.Text.Trim()).ToUpper()

        If String.IsNullOrWhiteSpace(barcodeInput) Then
            MessageBox.Show("Please select a product or enter a barcode.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If

        SelectedBarcode = barcodeInput
        SelectedQuantity = CInt(numQuantity.Value)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
