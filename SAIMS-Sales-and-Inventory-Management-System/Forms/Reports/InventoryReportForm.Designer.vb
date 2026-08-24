<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryReportForm
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.btnExportPDF = New System.Windows.Forms.Button()
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.cmbReportType = New System.Windows.Forms.ComboBox()
        Me.lblReportType = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelSummary = New System.Windows.Forms.Panel()
        Me.panelStats = New System.Windows.Forms.Panel()
        Me.txtOutOfStock = New System.Windows.Forms.TextBox()
        Me.lblOutOfStock = New System.Windows.Forms.Label()
        Me.txtLowStock = New System.Windows.Forms.TextBox()
        Me.lblLowStock = New System.Windows.Forms.Label()
        Me.txtTotalStock = New System.Windows.Forms.TextBox()
        Me.lblTotalStock = New System.Windows.Forms.Label()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.lblTotalItems = New System.Windows.Forms.Label()
        Me.lblReportPeriod = New System.Windows.Forms.Label()
        Me.lblSummaryTitle = New System.Windows.Forms.Label()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelTop.SuspendLayout()
        Me.panelSummary.SuspendLayout()
        Me.panelStats.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.White
        Me.panelTop.Controls.Add(Me.btnRefresh)
        Me.panelTop.Controls.Add(Me.btnPrint)
        Me.panelTop.Controls.Add(Me.btnExportExcel)
        Me.panelTop.Controls.Add(Me.btnExportPDF)
        Me.panelTop.Controls.Add(Me.btnGenerateReport)
        Me.panelTop.Controls.Add(Me.cmbReportType)
        Me.panelTop.Controls.Add(Me.lblReportType)
        Me.panelTop.Controls.Add(Me.lblTitle)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Padding = New System.Windows.Forms.Padding(15)
        Me.panelTop.Size = New System.Drawing.Size(1200, 100)
        Me.panelTop.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(865, 50)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 35)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(755, 50)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 35)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnExportExcel
        '
        Me.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnExportExcel.ForeColor = System.Drawing.Color.White
        Me.btnExportExcel.Location = New System.Drawing.Point(615, 50)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(130, 35)
        Me.btnExportExcel.TabIndex = 5
        Me.btnExportExcel.Text = "Export Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'btnExportPDF
        '
        Me.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnExportPDF.ForeColor = System.Drawing.Color.White
        Me.btnExportPDF.Location = New System.Drawing.Point(485, 50)
        Me.btnExportPDF.Name = "btnExportPDF"
        Me.btnExportPDF.Size = New System.Drawing.Size(120, 35)
        Me.btnExportPDF.TabIndex = 4
        Me.btnExportPDF.Text = "Export PDF"
        Me.btnExportPDF.UseVisualStyleBackColor = False
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateReport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnGenerateReport.ForeColor = System.Drawing.Color.White
        Me.btnGenerateReport.Location = New System.Drawing.Point(335, 50)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(140, 35)
        Me.btnGenerateReport.TabIndex = 3
        Me.btnGenerateReport.Text = "Generate Report"
        Me.btnGenerateReport.UseVisualStyleBackColor = False
        '
        'cmbReportType
        '
        Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbReportType.FormattingEnabled = True
        Me.cmbReportType.Location = New System.Drawing.Point(195, 55)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(130, 25)
        Me.cmbReportType.TabIndex = 2
        '
        'lblReportType
        '
        Me.lblReportType.AutoSize = True
        Me.lblReportType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblReportType.Location = New System.Drawing.Point(195, 30)
        Me.lblReportType.Name = "lblReportType"
        Me.lblReportType.Size = New System.Drawing.Size(87, 19)
        Me.lblReportType.TabIndex = 1
        Me.lblReportType.Text = "Report Type:"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 40)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(134, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Reports"
        '
        'panelSummary
        '
        Me.panelSummary.BackColor = System.Drawing.Color.White
        Me.panelSummary.Controls.Add(Me.panelStats)
        Me.panelSummary.Controls.Add(Me.lblReportPeriod)
        Me.panelSummary.Controls.Add(Me.lblSummaryTitle)
        Me.panelSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelSummary.Location = New System.Drawing.Point(0, 100)
        Me.panelSummary.Name = "panelSummary"
        Me.panelSummary.Padding = New System.Windows.Forms.Padding(15)
        Me.panelSummary.Size = New System.Drawing.Size(1200, 200)
        Me.panelSummary.TabIndex = 1
        '
        'panelStats
        '
        Me.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelStats.Controls.Add(Me.txtOutOfStock)
        Me.panelStats.Controls.Add(Me.lblOutOfStock)
        Me.panelStats.Controls.Add(Me.txtLowStock)
        Me.panelStats.Controls.Add(Me.lblLowStock)
        Me.panelStats.Controls.Add(Me.txtTotalStock)
        Me.panelStats.Controls.Add(Me.lblTotalStock)
        Me.panelStats.Controls.Add(Me.txtTotalItems)
        Me.panelStats.Controls.Add(Me.lblTotalItems)
        Me.panelStats.Location = New System.Drawing.Point(15, 65)
        Me.panelStats.Name = "panelStats"
        Me.panelStats.Size = New System.Drawing.Size(1170, 120)
        Me.panelStats.TabIndex = 2
        '
        'txtOutOfStock
        '
        Me.txtOutOfStock.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtOutOfStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.txtOutOfStock.Location = New System.Drawing.Point(940, 60)
        Me.txtOutOfStock.Name = "txtOutOfStock"
        Me.txtOutOfStock.ReadOnly = True
        Me.txtOutOfStock.Size = New System.Drawing.Size(200, 32)
        Me.txtOutOfStock.TabIndex = 7
        Me.txtOutOfStock.Text = "0"
        Me.txtOutOfStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOutOfStock
        '
        Me.lblOutOfStock.AutoSize = True
        Me.lblOutOfStock.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblOutOfStock.Location = New System.Drawing.Point(940, 30)
        Me.lblOutOfStock.Name = "lblOutOfStock"
        Me.lblOutOfStock.Size = New System.Drawing.Size(94, 19)
        Me.lblOutOfStock.TabIndex = 6
        Me.lblOutOfStock.Text = "Out of Stock"
        '
        'txtLowStock
        '
        Me.txtLowStock.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtLowStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.txtLowStock.Location = New System.Drawing.Point(640, 60)
        Me.txtLowStock.Name = "txtLowStock"
        Me.txtLowStock.ReadOnly = True
        Me.txtLowStock.Size = New System.Drawing.Size(200, 32)
        Me.txtLowStock.TabIndex = 5
        Me.txtLowStock.Text = "0"
        Me.txtLowStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLowStock
        '
        Me.lblLowStock.AutoSize = True
        Me.lblLowStock.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblLowStock.Location = New System.Drawing.Point(640, 30)
        Me.lblLowStock.Name = "lblLowStock"
        Me.lblLowStock.Size = New System.Drawing.Size(79, 19)
        Me.lblLowStock.TabIndex = 4
        Me.lblLowStock.Text = "Low Stock"
        '
        'txtTotalStock
        '
        Me.txtTotalStock.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtTotalStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtTotalStock.Location = New System.Drawing.Point(340, 60)
        Me.txtTotalStock.Name = "txtTotalStock"
        Me.txtTotalStock.ReadOnly = True
        Me.txtTotalStock.Size = New System.Drawing.Size(200, 32)
        Me.txtTotalStock.TabIndex = 3
        Me.txtTotalStock.Text = "0"
        Me.txtTotalStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalStock
        '
        Me.lblTotalStock.AutoSize = True
        Me.lblTotalStock.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTotalStock.Location = New System.Drawing.Point(340, 30)
        Me.lblTotalStock.Name = "lblTotalStock"
        Me.lblTotalStock.Size = New System.Drawing.Size(85, 19)
        Me.lblTotalStock.TabIndex = 2
        Me.lblTotalStock.Text = "Total Stock"
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtTotalItems.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.txtTotalItems.Location = New System.Drawing.Point(40, 60)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(200, 32)
        Me.txtTotalItems.TabIndex = 1
        Me.txtTotalItems.Text = "0"
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalItems
        '
        Me.lblTotalItems.AutoSize = True
        Me.lblTotalItems.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTotalItems.Location = New System.Drawing.Point(40, 30)
        Me.lblTotalItems.Name = "lblTotalItems"
        Me.lblTotalItems.Size = New System.Drawing.Size(85, 19)
        Me.lblTotalItems.TabIndex = 0
        Me.lblTotalItems.Text = "Total Items"
        '
        'lblReportPeriod
        '
        Me.lblReportPeriod.AutoSize = True
        Me.lblReportPeriod.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblReportPeriod.Location = New System.Drawing.Point(15, 40)
        Me.lblReportPeriod.Name = "lblReportPeriod"
        Me.lblReportPeriod.Size = New System.Drawing.Size(140, 19)
        Me.lblReportPeriod.TabIndex = 1
        Me.lblReportPeriod.Text = "Report Period: Monthly"
        '
        'lblSummaryTitle
        '
        Me.lblSummaryTitle.AutoSize = True
        Me.lblSummaryTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblSummaryTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblSummaryTitle.Name = "lblSummaryTitle"
        Me.lblSummaryTitle.Size = New System.Drawing.Size(174, 21)
        Me.lblSummaryTitle.TabIndex = 0
        Me.lblSummaryTitle.Text = "Inventory Summary"
        '
        'dgvInventory
        '
        Me.dgvInventory.AllowUserToAddRows = False
        Me.dgvInventory.AllowUserToDeleteRows = False
        Me.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInventory.BackgroundColor = System.Drawing.Color.White
        Me.dgvInventory.ColumnHeadersHeight = 40
        Me.dgvInventory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProductName, Me.colCategory, Me.colPrice, Me.colStock, Me.colStatus})
        Me.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInventory.Location = New System.Drawing.Point(0, 300)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.ReadOnly = True
        Me.dgvInventory.RowHeadersWidth = 51
        Me.dgvInventory.RowTemplate.Height = 35
        Me.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInventory.Size = New System.Drawing.Size(1200, 300)
        Me.dgvInventory.TabIndex = 2
        '
        'colProductName
        '
        Me.colProductName.HeaderText = "Product Name"
        Me.colProductName.MinimumWidth = 6
        Me.colProductName.Name = "colProductName"
        Me.colProductName.ReadOnly = True
        '
        'colCategory
        '
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.MinimumWidth = 6
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        '
        'colPrice
        '
        Me.colPrice.HeaderText = "Price"
        Me.colPrice.MinimumWidth = 6
        Me.colPrice.Name = "colPrice"
        Me.colPrice.ReadOnly = True
        '
        'colStock
        '
        Me.colStock.HeaderText = "Stock"
        Me.colStock.MinimumWidth = 6
        Me.colStock.Name = "colStock"
        Me.colStock.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.MinimumWidth = 6
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'InventoryReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 600)
        Me.Controls.Add(Me.dgvInventory)
        Me.Controls.Add(Me.panelSummary)
        Me.Controls.Add(Me.panelTop)
        Me.Name = "InventoryReportForm"
        Me.Text = "Inventory Report"
        Me.panelTop.ResumeLayout(False)
        Me.panelTop.PerformLayout()
        Me.panelSummary.ResumeLayout(False)
        Me.panelSummary.PerformLayout()
        Me.panelStats.ResumeLayout(False)
        Me.panelStats.PerformLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents cmbReportType As ComboBox
    Friend WithEvents lblReportType As Label
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents btnExportPDF As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents panelSummary As Panel
    Friend WithEvents lblSummaryTitle As Label
    Friend WithEvents lblReportPeriod As Label
    Friend WithEvents panelStats As Panel
    Friend WithEvents txtTotalItems As TextBox
    Friend WithEvents lblTotalItems As Label
    Friend WithEvents txtTotalStock As TextBox
    Friend WithEvents lblTotalStock As Label
    Friend WithEvents txtLowStock As TextBox
    Friend WithEvents lblLowStock As Label
    Friend WithEvents txtOutOfStock As TextBox
    Friend WithEvents lblOutOfStock As Label
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents colProductName As DataGridViewTextBoxColumn
    Friend WithEvents colCategory As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colStock As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
End Class
