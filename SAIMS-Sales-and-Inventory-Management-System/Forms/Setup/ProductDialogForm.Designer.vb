<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductDialogForm
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
        panelHeader = New Panel()
        lblHeaderTitle = New Label()
        lblBarcode = New Label()
        txtBarcode = New TextBox()
        lblProductName = New Label()
        txtProductName = New TextBox()
        lblCategory = New Label()
        cboCategory = New ComboBox()
        lblUnit = New Label()
        cboUnit = New ComboBox()
        lblPrice = New Label()
        txtPrice = New TextBox()
        lblStock = New Label()
        numStock = New NumericUpDown()
        lblLowStock = New Label()
        numLowStock = New NumericUpDown()
        lblStatus = New Label()
        cboStatus = New ComboBox()
        btnSave = New Button()
        btnCancel = New Button()
        panelHeader.SuspendLayout()
        CType(numStock, ComponentModel.ISupportInitialize).BeginInit()
        CType(numLowStock, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        panelHeader.Controls.Add(lblHeaderTitle)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(480, 50)
        panelHeader.TabIndex = 0
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.Location = New Point(20, 14)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(126, 21)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "Product Details"
        ' 
        ' lblBarcode
        ' 
        lblBarcode.AutoSize = True
        lblBarcode.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblBarcode.Location = New Point(25, 68)
        lblBarcode.Name = "lblBarcode"
        lblBarcode.Size = New Size(62, 17)
        lblBarcode.TabIndex = 1
        lblBarcode.Text = "Barcode:"
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Font = New Font("Segoe UI", 10F)
        txtBarcode.Location = New Point(25, 88)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(430, 25)
        txtBarcode.TabIndex = 2
        ' 
        ' lblProductName
        ' 
        lblProductName.AutoSize = True
        lblProductName.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblProductName.Location = New Point(25, 123)
        lblProductName.Name = "lblProductName"
        lblProductName.Size = New Size(100, 17)
        lblProductName.TabIndex = 3
        lblProductName.Text = "Product Name:"
        ' 
        ' txtProductName
        ' 
        txtProductName.Font = New Font("Segoe UI", 10F)
        txtProductName.Location = New Point(25, 143)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(430, 25)
        txtProductName.TabIndex = 4
        ' 
        ' lblCategory
        ' 
        lblCategory.AutoSize = True
        lblCategory.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblCategory.Location = New Point(25, 178)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(69, 17)
        lblCategory.TabIndex = 5
        lblCategory.Text = "Category:"
        ' 
        ' cboCategory
        ' 
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.Font = New Font("Segoe UI", 10F)
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(25, 198)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(200, 25)
        cboCategory.TabIndex = 6
        ' 
        ' lblUnit
        ' 
        lblUnit.AutoSize = True
        lblUnit.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblUnit.Location = New Point(255, 178)
        lblUnit.Name = "lblUnit"
        lblUnit.Size = New Size(40, 17)
        lblUnit.TabIndex = 17
        lblUnit.Text = "Unit:"
        ' 
        ' cboUnit
        ' 
        cboUnit.DropDownStyle = ComboBoxStyle.DropDownList
        cboUnit.Font = New Font("Segoe UI", 10F)
        cboUnit.FormattingEnabled = True
        cboUnit.Items.AddRange(New Object() {"bottle", "box", "case", "pcs", "pack", "can", "kg", "g"})
        cboUnit.Location = New Point(255, 198)
        cboUnit.Name = "cboUnit"
        cboUnit.Size = New Size(200, 25)
        cboUnit.TabIndex = 18
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblPrice.Location = New Point(25, 233)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(67, 17)
        lblPrice.TabIndex = 7
        lblPrice.Text = "Price (₱):"
        ' 
        ' txtPrice
        ' 
        txtPrice.Font = New Font("Segoe UI", 10F)
        txtPrice.Location = New Point(25, 253)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(200, 25)
        txtPrice.TabIndex = 8
        ' 
        ' lblStock
        ' 
        lblStock.AutoSize = True
        lblStock.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblStock.Location = New Point(255, 233)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(102, 17)
        lblStock.TabIndex = 9
        lblStock.Text = "Initial Stock Qty:"
        ' 
        ' numStock
        ' 
        numStock.Font = New Font("Segoe UI", 10F)
        numStock.Location = New Point(255, 253)
        numStock.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        numStock.Name = "numStock"
        numStock.Size = New Size(200, 25)
        numStock.TabIndex = 10
        ' 
        ' lblLowStock
        ' 
        lblLowStock.AutoSize = True
        lblLowStock.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblLowStock.Location = New Point(25, 288)
        lblLowStock.Name = "lblLowStock"
        lblLowStock.Size = New Size(130, 17)
        lblLowStock.TabIndex = 11
        lblLowStock.Text = "Low Stock Alert Qty:"
        ' 
        ' numLowStock
        ' 
        numLowStock.Font = New Font("Segoe UI", 10F)
        numLowStock.Location = New Point(25, 308)
        numLowStock.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        numLowStock.Name = "numLowStock"
        numLowStock.Size = New Size(200, 25)
        numLowStock.TabIndex = 12
        numLowStock.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblStatus.Location = New Point(255, 288)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(50, 17)
        lblStatus.TabIndex = 13
        lblStatus.Text = "Status:"
        ' 
        ' cboStatus
        ' 
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.Font = New Font("Segoe UI", 10F)
        cboStatus.FormattingEnabled = True
        cboStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        cboStatus.Location = New Point(255, 308)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(200, 25)
        cboStatus.TabIndex = 14
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(245, 360)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(100, 35)
        btnSave.TabIndex = 15
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(355, 360)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 35)
        btnCancel.TabIndex = 16
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' ProductDialogForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(480, 415)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(cboStatus)
        Controls.Add(lblStatus)
        Controls.Add(numLowStock)
        Controls.Add(lblLowStock)
        Controls.Add(numStock)
        Controls.Add(lblStock)
        Controls.Add(txtPrice)
        Controls.Add(lblPrice)
        Controls.Add(cboUnit)
        Controls.Add(lblUnit)
        Controls.Add(cboCategory)
        Controls.Add(lblCategory)
        Controls.Add(txtProductName)
        Controls.Add(lblProductName)
        Controls.Add(txtBarcode)
        Controls.Add(lblBarcode)
        Controls.Add(panelHeader)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "ProductDialogForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Product"
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        CType(numStock, ComponentModel.ISupportInitialize).EndInit()
        CType(numLowStock, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblBarcode As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblProductName As Label
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblUnit As Label
    Friend WithEvents cboUnit As ComboBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblStock As Label
    Friend WithEvents numStock As NumericUpDown
    Friend WithEvents lblLowStock As Label
    Friend WithEvents numLowStock As NumericUpDown
    Friend WithEvents lblStatus As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
