Public Class StockInForm

    Private _products As DataTable

    Private Sub StockInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        dtpDate.Value = DateTime.Now
        dtpFilterDate.Value = DateTime.Now
        LoadStockInHistory()
    End Sub

    Private Sub LoadProducts()
        Try
            _products = ProductRepository.GetAll()
            cmbProduct.DataSource    = _products
            cmbProduct.DisplayMember = "ProductName"
            cmbProduct.ValueMember   = "ProductID"
        Catch ex As Exception
            MessageBox.Show("Failed to load products." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStockInHistory()
        Try
            Dim filterDate As Nullable(Of DateTime) = Nothing
            If chkUseDateFilter.Checked Then
                filterDate = dtpFilterDate.Value.Date
            End If

            Dim dt As DataTable = StockMovementRepository.GetStockInSummary(filterDate)
            dgvStockIn.Rows.Clear()

            Dim searchKey As String = txtSearch.Text.Trim().ToLower()

            For Each row As DataRow In dt.Rows
                Dim barcode As String = If(IsDBNull(row("Barcode")), "", row("Barcode").ToString())
                Dim productName As String = row("ProductName").ToString()
                Dim categoryName As String = If(IsDBNull(row("CategoryName")), "", row("CategoryName").ToString())
                Dim currentStock As Integer = CInt(row("CurrentStock"))
                Dim totalStockIn As Integer = CInt(row("TotalStockInQty"))
                Dim lastDate As DateTime = CDate(row("LastStockInDate"))

                If Not String.IsNullOrEmpty(searchKey) Then
                    If Not barcode.ToLower().Contains(searchKey) AndAlso
                       Not productName.ToLower().Contains(searchKey) AndAlso
                       Not categoryName.ToLower().Contains(searchKey) Then
                        Continue For
                    End If
                End If

                dgvStockIn.Rows.Add(
                    row("ProductID"),
                    barcode,
                    productName,
                    categoryName,
                    currentStock,
                    "+" & totalStockIn.ToString(),
                    lastDate.ToString("yyyy-MM-dd HH:mm"),
                    "View Dates")
            Next

        Catch ex As Exception
            MessageBox.Show("Failed to load stock in summary." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvStockIn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStockIn.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = colAction.Index Then
            OpenStockInHistory(e.RowIndex)
        End If
    End Sub

    Private Sub dgvStockIn_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStockIn.CellDoubleClick
        If e.RowIndex >= 0 Then
            OpenStockInHistory(e.RowIndex)
        End If
    End Sub

    Private Sub OpenStockInHistory(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvStockIn.Rows.Count Then Return

        Dim row = dgvStockIn.Rows(rowIndex)
        Dim productID As Integer = CInt(row.Cells("colProductID").Value)
        Dim barcode As String = row.Cells("colBarcode").Value.ToString()
        Dim productName As String = row.Cells("colProduct").Value.ToString()
        Dim currentStock As Integer = CInt(row.Cells("colCurrentStock").Value)

        Using dlg As New StockInHistoryDialogForm()
            dlg.ProductID = productID
            dlg.BarcodeText = barcode
            dlg.ProductNameText = productName
            dlg.CurrentStockQty = currentStock
            dlg.ShowDialog(Me)
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadStockInHistory()
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Dim barcode As String = InputHelper.SanitizeInput(txtSearch.Text).ToUpper()
            If String.IsNullOrWhiteSpace(barcode) Then Return

            Try
                Dim dt As DataTable = ProductRepository.GetByBarcode(barcode)
                If dt.Rows.Count > 0 Then
                    Dim productID As Integer = CInt(dt.Rows(0)("ProductID"))
                    cmbProduct.SelectedValue = productID
                    System.Media.SystemSounds.Asterisk.Play()
                    txtQuantity.Focus()
                    txtQuantity.SelectAll()
                Else
                    System.Media.SystemSounds.Hand.Play()
                End If
            Catch ex As Exception
                ' Keep filtering table on error
            End Try
        End If
    End Sub

    Private Sub chkUseDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDateFilter.CheckedChanged
        dtpFilterDate.Enabled = chkUseDateFilter.Checked
        LoadStockInHistory()
    End Sub

    Private Sub dtpFilterDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFilterDate.ValueChanged
        If chkUseDateFilter.Checked Then
            LoadStockInHistory()
        End If
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtSearch.Clear()
        chkUseDateFilter.Checked = False
        dtpFilterDate.Value = DateTime.Now
        LoadStockInHistory()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbProduct.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a product.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim qty As Integer
        If Not Integer.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Please enter a valid quantity (must be greater than 0).", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productID   As Integer = CInt(cmbProduct.SelectedValue)
        Dim productName As String  = cmbProduct.Text
        Dim remarks     As String  = InputHelper.SanitizeInput(txtRemarks.Text)

        Try
            ProductRepository.AddStock(productID, qty)
            StockMovementRepository.Insert(productID, Constants.MOVEMENT_STOCKIN, qty,
                                           remarks, SessionManager.UserID)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Stock In: {productName} +{qty} units")

            MessageBox.Show($"Stock added successfully!" &
                            Environment.NewLine & Environment.NewLine &
                            $"Product:  {productName}" &
                            Environment.NewLine &
                            $"Quantity: +{qty}",
                            "Stock In Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearFields()
            LoadProducts()
            LoadStockInHistory()

        Catch ex As Exception
            MessageBox.Show("Failed to record stock in." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        If cmbProduct.Items.Count > 0 Then cmbProduct.SelectedIndex = 0
        txtQuantity.Clear()
        txtRemarks.Clear()
        dtpDate.Value = DateTime.Now
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStockInHistory()
    End Sub

End Class
