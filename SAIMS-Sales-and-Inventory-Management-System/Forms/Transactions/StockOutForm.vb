Public Class StockOutForm

    Private _products As DataTable

    Private Sub StockOutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()

        cmbReason.Items.Clear()
        cmbReason.Items.AddRange(New String() {"Damaged", "Expired", "Returns", "Wastage", "Other"})
        cmbReason.SelectedIndex = 0

        dtpDate.Value = DateTime.Now
        dtpFilterDate.Value = DateTime.Now
        LoadStockOutHistory()
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

    Private Sub LoadStockOutHistory()
        Try
            Dim dt As DataTable = StockMovementRepository.GetAll()
            dgvStockOut.Rows.Clear()

            Dim searchKey As String = txtSearch.Text.Trim().ToLower()
            Dim useDateFilter As Boolean = chkUseDateFilter.Checked
            Dim filterDate As Date = dtpFilterDate.Value.Date

            For Each row As DataRow In dt.Rows
                If row("MovementType").ToString() = Constants.MOVEMENT_STOCKOUT Then
                    Dim barcode As String = If(IsDBNull(row("Barcode")), "", row("Barcode").ToString())
                    Dim productName As String = row("ProductName").ToString()
                    Dim mDate As DateTime = CDate(row("MovementDate"))

                    If Not String.IsNullOrEmpty(searchKey) Then
                        If Not barcode.ToLower().Contains(searchKey) AndAlso Not productName.ToLower().Contains(searchKey) Then
                            Continue For
                        End If
                    End If

                    If useDateFilter Then
                        If mDate.Date <> filterDate Then
                            Continue For
                        End If
                    End If

                    Dim reasonFull As String = row("Reason").ToString()
                    Dim reason     As String = reasonFull
                    Dim remarks    As String = ""

                    Dim sepIdx As Integer = reasonFull.IndexOf(": ")
                    If sepIdx >= 0 Then
                        reason  = reasonFull.Substring(0, sepIdx)
                        remarks = reasonFull.Substring(sepIdx + 2)
                    End If

                    dgvStockOut.Rows.Add(
                        row("MovementID").ToString(),
                        barcode,
                        productName,
                        row("Quantity").ToString(),
                        reason,
                        mDate.ToString("yyyy-MM-dd HH:mm"),
                        remarks)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Failed to load stock out history." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadStockOutHistory()
    End Sub

    Private Sub chkUseDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDateFilter.CheckedChanged
        dtpFilterDate.Enabled = chkUseDateFilter.Checked
        LoadStockOutHistory()
    End Sub

    Private Sub dtpFilterDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFilterDate.ValueChanged
        If chkUseDateFilter.Checked Then
            LoadStockOutHistory()
        End If
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtSearch.Clear()
        chkUseDateFilter.Checked = False
        dtpFilterDate.Value = DateTime.Now
        LoadStockOutHistory()
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
        Dim reason      As String  = cmbReason.SelectedItem.ToString()
        Dim remarks     As String  = InputHelper.SanitizeInput(txtRemarks.Text)

        ' Validate against current stock
        Dim currentStock As Integer = 0
        If _products IsNot Nothing Then
            For Each r As DataRow In _products.Rows
                If CInt(r("ProductID")) = productID Then
                    currentStock = CInt(r("Stock"))
                    Exit For
                End If
            Next
        End If

        If qty > currentStock Then
            MessageBox.Show($"Cannot remove {qty} units — only {currentStock} currently in stock.",
                            "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fullReason As String = reason & If(String.IsNullOrWhiteSpace(remarks), "", ": " & remarks)

        Try
            ProductRepository.DeductStock(productID, qty)
            StockMovementRepository.Insert(productID, Constants.MOVEMENT_STOCKOUT, qty,
                                           fullReason, SessionManager.UserID)
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS,
                               $"Stock Out: {productName} -{qty} units ({reason})")

            MessageBox.Show($"Stock out recorded successfully!" &
                            Environment.NewLine & Environment.NewLine &
                            $"Product:  {productName}" &
                            Environment.NewLine &
                            $"Quantity: -{qty}" &
                            Environment.NewLine &
                            $"Reason:   {reason}",
                            "Stock Out Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearFields()
            LoadStockOutHistory()

        Catch ex As Exception
            MessageBox.Show("Failed to record stock out." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        If cmbProduct.Items.Count > 0 Then cmbProduct.SelectedIndex = 0
        If cmbReason.Items.Count > 0 Then cmbReason.SelectedIndex = 0
        txtQuantity.Clear()
        txtRemarks.Clear()
        dtpDate.Value = DateTime.Now
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStockOutHistory()
    End Sub

End Class
