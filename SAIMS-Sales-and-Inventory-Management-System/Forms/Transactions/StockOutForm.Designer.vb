<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockOutForm
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelForm = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.cmbReason = New System.Windows.Forms.ComboBox()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.cmbProduct = New System.Windows.Forms.ComboBox()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.dgvStockOut = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelTop.SuspendLayout()
        Me.panelForm.SuspendLayout()
        CType(Me.dgvStockOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.White
        Me.panelTop.Controls.Add(Me.lblTitle)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Padding = New System.Windows.Forms.Padding(15)
        Me.panelTop.Size = New System.Drawing.Size(1000, 70)
        Me.panelTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 18)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(165, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Stock Out"
        '
        'panelForm
        '
        Me.panelForm.BackColor = System.Drawing.Color.White
        Me.panelForm.Controls.Add(Me.btnRefresh)
        Me.panelForm.Controls.Add(Me.btnClear)
        Me.panelForm.Controls.Add(Me.btnAdd)
        Me.panelForm.Controls.Add(Me.txtRemarks)
        Me.panelForm.Controls.Add(Me.lblRemarks)
        Me.panelForm.Controls.Add(Me.dtpDate)
        Me.panelForm.Controls.Add(Me.lblDate)
        Me.panelForm.Controls.Add(Me.cmbReason)
        Me.panelForm.Controls.Add(Me.lblReason)
        Me.panelForm.Controls.Add(Me.txtQuantity)
        Me.panelForm.Controls.Add(Me.lblQuantity)
        Me.panelForm.Controls.Add(Me.cmbProduct)
        Me.panelForm.Controls.Add(Me.lblProduct)
        Me.panelForm.Controls.Add(Me.lblFormTitle)
        Me.panelForm.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelForm.Location = New System.Drawing.Point(0, 70)
        Me.panelForm.Name = "panelForm"
        Me.panelForm.Padding = New System.Windows.Forms.Padding(20)
        Me.panelForm.Size = New System.Drawing.Size(1000, 230)
        Me.panelForm.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(580, 175)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 35)
        Me.btnRefresh.TabIndex = 13
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(470, 175)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 35)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(360, 175)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 35)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "Add Stock Out"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRemarks.Location = New System.Drawing.Point(360, 130)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.PlaceholderText = "Optional remarks..."
        Me.txtRemarks.Size = New System.Drawing.Size(320, 25)
        Me.txtRemarks.TabIndex = 10
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblRemarks.Location = New System.Drawing.Point(360, 105)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(68, 19)
        Me.lblRemarks.TabIndex = 9
        Me.lblRemarks.Text = "Remarks:"
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDate.Location = New System.Drawing.Point(25, 180)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(320, 25)
        Me.dtpDate.TabIndex = 8
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDate.Location = New System.Drawing.Point(25, 155)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(42, 19)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Date:"
        '
        'cmbReason
        '
        Me.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReason.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbReason.FormattingEnabled = True
        Me.cmbReason.Location = New System.Drawing.Point(25, 130)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(320, 25)
        Me.cmbReason.TabIndex = 6
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblReason.Location = New System.Drawing.Point(25, 105)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(58, 19)
        Me.lblReason.TabIndex = 5
        Me.lblReason.Text = "Reason:"
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtQuantity.Location = New System.Drawing.Point(360, 48)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.PlaceholderText = "Enter quantity..."
        Me.txtQuantity.Size = New System.Drawing.Size(320, 25)
        Me.txtQuantity.TabIndex = 4
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblQuantity.Location = New System.Drawing.Point(360, 23)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(68, 19)
        Me.lblQuantity.TabIndex = 3
        Me.lblQuantity.Text = "Quantity:"
        '
        'cmbProduct
        '
        Me.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProduct.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Location = New System.Drawing.Point(25, 48)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(320, 25)
        Me.cmbProduct.TabIndex = 2
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblProduct.Location = New System.Drawing.Point(25, 23)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(104, 19)
        Me.lblProduct.TabIndex = 1
        Me.lblProduct.Text = "Select Product:"
        '
        'lblFormTitle
        '
        Me.lblFormTitle.AutoSize = True
        Me.lblFormTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblFormTitle.Location = New System.Drawing.Point(710, 23)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New System.Drawing.Size(185, 21)
        Me.lblFormTitle.TabIndex = 0
        Me.lblFormTitle.Text = "Record Stock Out Entry"
        '
        'dgvStockOut
        '
        Me.dgvStockOut.AllowUserToAddRows = False
        Me.dgvStockOut.AllowUserToDeleteRows = False
        Me.dgvStockOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStockOut.BackgroundColor = System.Drawing.Color.White
        Me.dgvStockOut.ColumnHeadersHeight = 40
        Me.dgvStockOut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colProduct, Me.colQuantity, Me.colReason, Me.colDate, Me.colRemarks})
        Me.dgvStockOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockOut.Location = New System.Drawing.Point(0, 300)
        Me.dgvStockOut.Name = "dgvStockOut"
        Me.dgvStockOut.ReadOnly = True
        Me.dgvStockOut.RowHeadersWidth = 51
        Me.dgvStockOut.RowTemplate.Height = 35
        Me.dgvStockOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStockOut.Size = New System.Drawing.Size(1000, 300)
        Me.dgvStockOut.TabIndex = 2
        '
        'colID
        '
        Me.colID.HeaderText = "Stock Out ID"
        Me.colID.MinimumWidth = 6
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        '
        'colProduct
        '
        Me.colProduct.HeaderText = "Product Name"
        Me.colProduct.MinimumWidth = 6
        Me.colProduct.Name = "colProduct"
        Me.colProduct.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.MinimumWidth = 6
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        '
        'colReason
        '
        Me.colReason.HeaderText = "Reason"
        Me.colReason.MinimumWidth = 6
        Me.colReason.Name = "colReason"
        Me.colReason.ReadOnly = True
        '
        'colDate
        '
        Me.colDate.HeaderText = "Date"
        Me.colDate.MinimumWidth = 6
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.MinimumWidth = 6
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        '
        'StockOutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.dgvStockOut)
        Me.Controls.Add(Me.panelForm)
        Me.Controls.Add(Me.panelTop)
        Me.Name = "StockOutForm"
        Me.Text = "Stock Out"
        Me.panelTop.ResumeLayout(False)
        Me.panelTop.PerformLayout()
        Me.panelForm.ResumeLayout(False)
        Me.panelForm.PerformLayout()
        CType(Me.dgvStockOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents panelForm As Panel
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents cmbProduct As ComboBox
    Friend WithEvents lblProduct As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents cmbReason As ComboBox
    Friend WithEvents lblReason As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents lblRemarks As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvStockOut As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colProduct As DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colReason As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As DataGridViewTextBoxColumn
End Class
