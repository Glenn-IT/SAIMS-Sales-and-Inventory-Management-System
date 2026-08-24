<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceiptsForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnPrintReceipt = New System.Windows.Forms.Button()
        Me.btnViewReceipt = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelFilter = New System.Windows.Forms.Panel()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnShowAll = New System.Windows.Forms.Button()
        Me.dgvReceipts = New System.Windows.Forms.DataGridView()
        Me.colReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentMethod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelTop.SuspendLayout()
        Me.panelFilter.SuspendLayout()
        CType(Me.dgvReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.White
        Me.panelTop.Controls.Add(Me.btnRefresh)
        Me.panelTop.Controls.Add(Me.btnPrintReceipt)
        Me.panelTop.Controls.Add(Me.btnViewReceipt)
        Me.panelTop.Controls.Add(Me.lblTitle)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Padding = New System.Windows.Forms.Padding(15)
        Me.panelTop.Size = New System.Drawing.Size(1000, 70)
        Me.panelTop.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(580, 18)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 35)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnPrintReceipt
        '
        Me.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintReceipt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnPrintReceipt.ForeColor = System.Drawing.Color.White
        Me.btnPrintReceipt.Location = New System.Drawing.Point(430, 18)
        Me.btnPrintReceipt.Name = "btnPrintReceipt"
        Me.btnPrintReceipt.Size = New System.Drawing.Size(140, 35)
        Me.btnPrintReceipt.TabIndex = 2
        Me.btnPrintReceipt.Text = "Print Receipt"
        Me.btnPrintReceipt.UseVisualStyleBackColor = False
        '
        'btnViewReceipt
        '
        Me.btnViewReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnViewReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewReceipt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnViewReceipt.ForeColor = System.Drawing.Color.White
        Me.btnViewReceipt.Location = New System.Drawing.Point(280, 18)
        Me.btnViewReceipt.Name = "btnViewReceipt"
        Me.btnViewReceipt.Size = New System.Drawing.Size(140, 35)
        Me.btnViewReceipt.TabIndex = 1
        Me.btnViewReceipt.Text = "View Receipt"
        Me.btnViewReceipt.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 18)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(135, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Receipts"
        '
        'panelFilter
        '
        Me.panelFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.panelFilter.Controls.Add(Me.lblFrom)
        Me.panelFilter.Controls.Add(Me.dtpFrom)
        Me.panelFilter.Controls.Add(Me.lblTo)
        Me.panelFilter.Controls.Add(Me.dtpTo)
        Me.panelFilter.Controls.Add(Me.btnFilter)
        Me.panelFilter.Controls.Add(Me.btnShowAll)
        Me.panelFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelFilter.Location = New System.Drawing.Point(0, 70)
        Me.panelFilter.Name = "panelFilter"
        Me.panelFilter.Size = New System.Drawing.Size(1000, 55)
        Me.panelFilter.TabIndex = 1
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblFrom.Location = New System.Drawing.Point(20, 18)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(44, 17)
        Me.lblFrom.TabIndex = 0
        Me.lblFrom.Text = "From:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFrom.Location = New System.Drawing.Point(70, 14)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(130, 25)
        Me.dtpFrom.TabIndex = 1
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTo.Location = New System.Drawing.Point(220, 18)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(28, 17)
        Me.lblTo.TabIndex = 2
        Me.lblTo.Text = "To:"
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpTo.Location = New System.Drawing.Point(255, 14)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(130, 25)
        Me.dtpTo.TabIndex = 3
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnFilter.ForeColor = System.Drawing.Color.White
        Me.btnFilter.Location = New System.Drawing.Point(400, 12)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(100, 30)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter Date"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'btnShowAll
        '
        Me.btnShowAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnShowAll.ForeColor = System.Drawing.Color.White
        Me.btnShowAll.Location = New System.Drawing.Point(510, 12)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.Size = New System.Drawing.Size(90, 30)
        Me.btnShowAll.TabIndex = 5
        Me.btnShowAll.Text = "Show All"
        Me.btnShowAll.UseVisualStyleBackColor = False
        '
        'dgvReceipts
        '
        Me.dgvReceipts.AllowUserToAddRows = False
        Me.dgvReceipts.AllowUserToDeleteRows = False
        Me.dgvReceipts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReceipts.BackgroundColor = System.Drawing.Color.White
        Me.dgvReceipts.ColumnHeadersHeight = 40
        Me.dgvReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReceiptNo, Me.colDateTime, Me.colAmount, Me.colPaymentMethod, Me.colStatus})
        Me.dgvReceipts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReceipts.Location = New System.Drawing.Point(0, 125)
        Me.dgvReceipts.Name = "dgvReceipts"
        Me.dgvReceipts.ReadOnly = True
        Me.dgvReceipts.RowHeadersWidth = 51
        Me.dgvReceipts.RowTemplate.Height = 35
        Me.dgvReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReceipts.Size = New System.Drawing.Size(1000, 475)
        Me.dgvReceipts.TabIndex = 2
        '
        'colReceiptNo
        '
        Me.colReceiptNo.HeaderText = "Receipt No."
        Me.colReceiptNo.MinimumWidth = 6
        Me.colReceiptNo.Name = "colReceiptNo"
        Me.colReceiptNo.ReadOnly = True
        '
        'colDateTime
        '
        Me.colDateTime.HeaderText = "Date & Time"
        Me.colDateTime.MinimumWidth = 6
        Me.colDateTime.Name = "colDateTime"
        Me.colDateTime.ReadOnly = True
        '
        'colAmount
        '
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.MinimumWidth = 6
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'colPaymentMethod
        '
        Me.colPaymentMethod.HeaderText = "Payment Method"
        Me.colPaymentMethod.MinimumWidth = 6
        Me.colPaymentMethod.Name = "colPaymentMethod"
        Me.colPaymentMethod.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.MinimumWidth = 6
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'ReceiptsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.dgvReceipts)
        Me.Controls.Add(Me.panelFilter)
        Me.Controls.Add(Me.panelTop)
        Me.Name = "ReceiptsForm"
        Me.Text = "Receipts"
        Me.panelTop.ResumeLayout(False)
        Me.panelTop.PerformLayout()
        Me.panelFilter.ResumeLayout(False)
        Me.panelFilter.PerformLayout()
        CType(Me.dgvReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnViewReceipt As Button
    Friend WithEvents btnPrintReceipt As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents panelFilter As Panel
    Friend WithEvents lblFrom As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents lblTo As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents dgvReceipts As DataGridView
    Friend WithEvents colReceiptNo As DataGridViewTextBoxColumn
    Friend WithEvents colDateTime As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
    Friend WithEvents colPaymentMethod As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
End Class
