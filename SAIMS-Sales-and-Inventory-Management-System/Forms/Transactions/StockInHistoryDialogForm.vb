Imports System.Data

Public Class StockInHistoryDialogForm

    Public Property ProductID As Integer = 0
    Public Property ProductNameText As String = ""
    Public Property BarcodeText As String = ""
    Public Property CurrentStockQty As Integer = 0

    Private Sub StockInHistoryDialogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblHeaderTitle.Text = $"Stock In History - {ProductNameText}"
        lblProductInfo.Text = $"Product: {ProductNameText}  |  Barcode: {BarcodeText}  |  Current Stock: {CurrentStockQty}"
        LoadHistory()
    End Sub

    Private Sub LoadHistory()
        Try
            Dim dt As DataTable = StockMovementRepository.GetStockInHistoryByProduct(ProductID)
            dgvHistory.Rows.Clear()

            Dim totalQtyAdded As Integer = 0

            For Each row As DataRow In dt.Rows
                Dim mID As String = row("MovementID").ToString()
                Dim qty As Integer = CInt(row("Quantity"))
                totalQtyAdded += qty
                Dim mDate As DateTime = CDate(row("MovementDate"))
                Dim reason As String = If(IsDBNull(row("Reason")) OrElse String.IsNullOrWhiteSpace(row("Reason").ToString()), "--", row("Reason").ToString())
                Dim createdBy As String = If(IsDBNull(row("CreatedBy")) OrElse String.IsNullOrWhiteSpace(row("CreatedBy").ToString()), "--", row("CreatedBy").ToString())

                dgvHistory.Rows.Add(
                    mID,
                    mDate.ToString("yyyy-MM-dd hh:mm tt"),
                    "+" & qty.ToString(),
                    reason,
                    createdBy
                )
            Next

            lblSummary.Text = $"Total Entries: {dt.Rows.Count}  |  Total Units Added: +{totalQtyAdded}"

        Catch ex As Exception
            MessageBox.Show("Failed to load stock in history." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
