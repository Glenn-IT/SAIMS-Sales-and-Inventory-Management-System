Public Class StockInForm

    Private _products As DataTable

    Private Sub StockInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.04
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE

        LoadProducts()
        dtpDate.Value = DateTime.Now
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
            Dim dt As DataTable = StockMovementRepository.GetAll()
            dgvStockIn.Rows.Clear()

            For Each row As DataRow In dt.Rows
                If row("MovementType").ToString() = Constants.MOVEMENT_STOCKIN Then
                    dgvStockIn.Rows.Add(
                        row("MovementID").ToString(),
                        row("ProductName").ToString(),
                        row("Quantity").ToString(),
                        CDate(row("MovementDate")).ToString("yyyy-MM-dd HH:mm"),
                        row("Reason").ToString())
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Failed to load stock in history." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
