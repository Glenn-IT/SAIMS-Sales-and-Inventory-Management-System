<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesForm
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
        Me.txtBarcodeScanner = New System.Windows.Forms.TextBox()
        Me.lblBarcodeScanner = New System.Windows.Forms.Label()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelCart = New System.Windows.Forms.Panel()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.colBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelCartButtons = New System.Windows.Forms.Panel()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.panelRight = New System.Windows.Forms.Panel()
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSavePrint = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.panelSummary = New System.Windows.Forms.Panel()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.txtAmountTendered = New System.Windows.Forms.TextBox()
        Me.lblAmountTendered = New System.Windows.Forms.Label()
        Me.cmbPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.lblPaymentMethod = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.lblTotalItems = New System.Windows.Forms.Label()
        Me.lblSummaryTitle = New System.Windows.Forms.Label()
        Me.panelTop.SuspendLayout()
        Me.panelCart.SuspendLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelCartButtons.SuspendLayout()
        Me.panelRight.SuspendLayout()
        Me.panelButtons.SuspendLayout()
        Me.panelSummary.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.White
        Me.panelTop.Controls.Add(Me.txtBarcodeScanner)
        Me.panelTop.Controls.Add(Me.lblBarcodeScanner)
        Me.panelTop.Controls.Add(Me.btnAddItem)
        Me.panelTop.Controls.Add(Me.lblTitle)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Padding = New System.Windows.Forms.Padding(15)
        Me.panelTop.Size = New System.Drawing.Size(1200, 100)
        Me.panelTop.TabIndex = 0
        '
        'txtBarcodeScanner
        '
        Me.txtBarcodeScanner.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtBarcodeScanner.Location = New System.Drawing.Point(220, 52)
        Me.txtBarcodeScanner.Name = "txtBarcodeScanner"
        Me.txtBarcodeScanner.PlaceholderText = "Scan barcode or enter product code..."
        Me.txtBarcodeScanner.Size = New System.Drawing.Size(400, 29)
        Me.txtBarcodeScanner.TabIndex = 3
        '
        'lblBarcodeScanner
        '
        Me.lblBarcodeScanner.AutoSize = True
        Me.lblBarcodeScanner.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblBarcodeScanner.Location = New System.Drawing.Point(35, 57)
        Me.lblBarcodeScanner.Name = "lblBarcodeScanner"
        Me.lblBarcodeScanner.Size = New System.Drawing.Size(179, 19)
        Me.lblBarcodeScanner.TabIndex = 2
        Me.lblBarcodeScanner.Text = "Barcode Scanner Input:"
        '
        'btnAddItem
        '
        Me.btnAddItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnAddItem.ForeColor = System.Drawing.Color.White
        Me.btnAddItem.Location = New System.Drawing.Point(635, 50)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(120, 35)
        Me.btnAddItem.TabIndex = 1
        Me.btnAddItem.Text = "Add Manual"
        Me.btnAddItem.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(249, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Sales Transaction"
        '
        'panelCart
        '
        Me.panelCart.Controls.Add(Me.dgvCart)
        Me.panelCart.Controls.Add(Me.panelCartButtons)
        Me.panelCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCart.Location = New System.Drawing.Point(0, 100)
        Me.panelCart.Name = "panelCart"
        Me.panelCart.Padding = New System.Windows.Forms.Padding(10)
        Me.panelCart.Size = New System.Drawing.Size(800, 500)
        Me.panelCart.TabIndex = 1
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCart.BackgroundColor = System.Drawing.Color.White
        Me.dgvCart.ColumnHeadersHeight = 40
        Me.dgvCart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBarcode, Me.colProductName, Me.colPrice, Me.colQuantity, Me.colTotal})
        Me.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCart.Location = New System.Drawing.Point(10, 10)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersWidth = 51
        Me.dgvCart.RowTemplate.Height = 35
        Me.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCart.Size = New System.Drawing.Size(780, 430)
        Me.dgvCart.TabIndex = 0
        '
        'colBarcode
        '
        Me.colBarcode.HeaderText = "Barcode"
        Me.colBarcode.MinimumWidth = 6
        Me.colBarcode.Name = "colBarcode"
        Me.colBarcode.ReadOnly = True
        '
        'colProductName
        '
        Me.colProductName.HeaderText = "Product Name"
        Me.colProductName.MinimumWidth = 6
        Me.colProductName.Name = "colProductName"
        Me.colProductName.ReadOnly = True
        '
        'colPrice
        '
        Me.colPrice.HeaderText = "Price"
        Me.colPrice.MinimumWidth = 6
        Me.colPrice.Name = "colPrice"
        Me.colPrice.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.MinimumWidth = 6
        Me.colQuantity.Name = "colQuantity"
        '
        'colTotal
        '
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MinimumWidth = 6
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'panelCartButtons
        '
        Me.panelCartButtons.BackColor = System.Drawing.Color.White
        Me.panelCartButtons.Controls.Add(Me.btnRemoveItem)
        Me.panelCartButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelCartButtons.Location = New System.Drawing.Point(10, 440)
        Me.panelCartButtons.Name = "panelCartButtons"
        Me.panelCartButtons.Size = New System.Drawing.Size(780, 50)
        Me.panelCartButtons.TabIndex = 1
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnRemoveItem.ForeColor = System.Drawing.Color.White
        Me.btnRemoveItem.Location = New System.Drawing.Point(10, 8)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(130, 35)
        Me.btnRemoveItem.TabIndex = 0
        Me.btnRemoveItem.Text = "Remove Item"
        Me.btnRemoveItem.UseVisualStyleBackColor = False
        '
        'panelRight
        '
        Me.panelRight.BackColor = System.Drawing.Color.White
        Me.panelRight.Controls.Add(Me.panelButtons)
        Me.panelRight.Controls.Add(Me.panelSummary)
        Me.panelRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRight.Location = New System.Drawing.Point(800, 100)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Padding = New System.Windows.Forms.Padding(10)
        Me.panelRight.Size = New System.Drawing.Size(400, 500)
        Me.panelRight.TabIndex = 2
        '
        'panelButtons
        '
        Me.panelButtons.Controls.Add(Me.btnCancel)
        Me.panelButtons.Controls.Add(Me.btnSavePrint)
        Me.panelButtons.Controls.Add(Me.btnClearAll)
        Me.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelButtons.Location = New System.Drawing.Point(10, 400)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(380, 90)
        Me.panelButtons.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(250, 45)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSavePrint
        '
        Me.btnSavePrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnSavePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePrint.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSavePrint.ForeColor = System.Drawing.Color.White
        Me.btnSavePrint.Location = New System.Drawing.Point(10, 45)
        Me.btnSavePrint.Name = "btnSavePrint"
        Me.btnSavePrint.Size = New System.Drawing.Size(230, 40)
        Me.btnSavePrint.TabIndex = 1
        Me.btnSavePrint.Text = "Save && Print"
        Me.btnSavePrint.UseVisualStyleBackColor = False
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnClearAll.ForeColor = System.Drawing.Color.White
        Me.btnClearAll.Location = New System.Drawing.Point(10, 5)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(360, 35)
        Me.btnClearAll.TabIndex = 0
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = False
        '
        'panelSummary
        '
        Me.panelSummary.Controls.Add(Me.txtChange)
        Me.panelSummary.Controls.Add(Me.lblChange)
        Me.panelSummary.Controls.Add(Me.txtAmountTendered)
        Me.panelSummary.Controls.Add(Me.lblAmountTendered)
        Me.panelSummary.Controls.Add(Me.cmbPaymentMethod)
        Me.panelSummary.Controls.Add(Me.lblPaymentMethod)
        Me.panelSummary.Controls.Add(Me.txtTotalAmount)
        Me.panelSummary.Controls.Add(Me.lblTotalAmount)
        Me.panelSummary.Controls.Add(Me.txtDiscount)
        Me.panelSummary.Controls.Add(Me.lblDiscount)
        Me.panelSummary.Controls.Add(Me.txtSubtotal)
        Me.panelSummary.Controls.Add(Me.lblSubtotal)
        Me.panelSummary.Controls.Add(Me.txtTotalItems)
        Me.panelSummary.Controls.Add(Me.lblTotalItems)
        Me.panelSummary.Controls.Add(Me.lblSummaryTitle)
        Me.panelSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelSummary.Location = New System.Drawing.Point(10, 10)
        Me.panelSummary.Name = "panelSummary"
        Me.panelSummary.Size = New System.Drawing.Size(380, 380)
        Me.panelSummary.TabIndex = 0
        '
        'txtChange
        '
        Me.txtChange.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtChange.Location = New System.Drawing.Point(180, 335)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.ReadOnly = True
        Me.txtChange.Size = New System.Drawing.Size(190, 29)
        Me.txtChange.TabIndex = 14
        Me.txtChange.Text = "?0.00"
        Me.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblChange.Location = New System.Drawing.Point(10, 340)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(66, 19)
        Me.lblChange.TabIndex = 13
        Me.lblChange.Text = "Change:"
        '
        'txtAmountTendered
        '
        Me.txtAmountTendered.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtAmountTendered.Location = New System.Drawing.Point(180, 295)
        Me.txtAmountTendered.Name = "txtAmountTendered"
        Me.txtAmountTendered.Size = New System.Drawing.Size(190, 25)
        Me.txtAmountTendered.TabIndex = 12
        Me.txtAmountTendered.Text = "0"
        Me.txtAmountTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAmountTendered
        '
        Me.lblAmountTendered.AutoSize = True
        Me.lblAmountTendered.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblAmountTendered.Location = New System.Drawing.Point(10, 298)
        Me.lblAmountTendered.Name = "lblAmountTendered"
        Me.lblAmountTendered.Size = New System.Drawing.Size(132, 19)
        Me.lblAmountTendered.TabIndex = 11
        Me.lblAmountTendered.Text = "Amount Tendered:"
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMethod.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.Items.AddRange(New Object() {"Cash", "GCash", "Credit Card", "Debit Card"})
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(180, 255)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(190, 25)
        Me.cmbPaymentMethod.TabIndex = 10
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.AutoSize = True
        Me.lblPaymentMethod.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblPaymentMethod.Location = New System.Drawing.Point(10, 258)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(123, 19)
        Me.lblPaymentMethod.TabIndex = 9
        Me.lblPaymentMethod.Text = "Payment Method:"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtTotalAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtTotalAmount.Location = New System.Drawing.Point(180, 210)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(190, 32)
        Me.txtTotalAmount.TabIndex = 8
        Me.txtTotalAmount.Text = "?0.00"
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblTotalAmount.Location = New System.Drawing.Point(10, 216)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(120, 21)
        Me.lblTotalAmount.TabIndex = 7
        Me.lblTotalAmount.Text = "Total Amount:"
        '
        'txtDiscount
        '
        Me.txtDiscount.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtDiscount.Location = New System.Drawing.Point(180, 170)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(190, 25)
        Me.txtDiscount.TabIndex = 6
        Me.txtDiscount.Text = "0"
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDiscount.Location = New System.Drawing.Point(10, 173)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(69, 19)
        Me.lblDiscount.TabIndex = 5
        Me.lblDiscount.Text = "Discount:"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtSubtotal.Location = New System.Drawing.Point(180, 130)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(190, 25)
        Me.txtSubtotal.TabIndex = 4
        Me.txtSubtotal.Text = "?0.00"
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblSubtotal.Location = New System.Drawing.Point(10, 133)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(67, 19)
        Me.lblSubtotal.TabIndex = 3
        Me.lblSubtotal.Text = "Subtotal:"
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtTotalItems.Location = New System.Drawing.Point(180, 90)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(190, 25)
        Me.txtTotalItems.TabIndex = 2
        Me.txtTotalItems.Text = "0"
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalItems
        '
        Me.lblTotalItems.AutoSize = True
        Me.lblTotalItems.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblTotalItems.Location = New System.Drawing.Point(10, 93)
        Me.lblTotalItems.Name = "lblTotalItems"
        Me.lblTotalItems.Size = New System.Drawing.Size(83, 19)
        Me.lblTotalItems.TabIndex = 1
        Me.lblTotalItems.Text = "Total Items:"
        '
        'lblSummaryTitle
        '
        Me.lblSummaryTitle.AutoSize = True
        Me.lblSummaryTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblSummaryTitle.Location = New System.Drawing.Point(10, 10)
        Me.lblSummaryTitle.Name = "lblSummaryTitle"
        Me.lblSummaryTitle.Size = New System.Drawing.Size(224, 25)
        Me.lblSummaryTitle.TabIndex = 0
        Me.lblSummaryTitle.Text = "Transaction Summary"
        '
        'SalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 600)
        Me.Controls.Add(Me.panelCart)
        Me.Controls.Add(Me.panelRight)
        Me.Controls.Add(Me.panelTop)
        Me.Name = "SalesForm"
        Me.Text = "Sales Transaction"
        Me.panelTop.ResumeLayout(False)
        Me.panelTop.PerformLayout()
        Me.panelCart.ResumeLayout(False)
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelCartButtons.ResumeLayout(False)
        Me.panelRight.ResumeLayout(False)
        Me.panelButtons.ResumeLayout(False)
        Me.panelSummary.ResumeLayout(False)
        Me.panelSummary.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnAddItem As Button
    Friend WithEvents panelCart As Panel
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents panelRight As Panel
    Friend WithEvents panelSummary As Panel
    Friend WithEvents lblSummaryTitle As Label
    Friend WithEvents lblTotalItems As Label
    Friend WithEvents txtTotalItems As TextBox
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents txtDiscount As TextBox
    Friend WithEvents lblDiscount As Label
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents cmbPaymentMethod As ComboBox
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents txtAmountTendered As TextBox
    Friend WithEvents lblAmountTendered As Label
    Friend WithEvents txtChange As TextBox
    Friend WithEvents lblChange As Label
    Friend WithEvents panelButtons As Panel
    Friend WithEvents btnClearAll As Button
    Friend WithEvents btnSavePrint As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents panelCartButtons As Panel
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents colBarcode As DataGridViewTextBoxColumn
    Friend WithEvents colProductName As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colTotal As DataGridViewTextBoxColumn
    Friend WithEvents txtBarcodeScanner As TextBox
    Friend WithEvents lblBarcodeScanner As Label
End Class
