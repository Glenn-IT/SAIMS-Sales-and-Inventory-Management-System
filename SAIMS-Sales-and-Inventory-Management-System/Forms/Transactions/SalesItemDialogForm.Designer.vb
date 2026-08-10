<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesItemDialogForm
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
        lblProduct = New Label()
        cboProduct = New ComboBox()
        lblBarcode = New Label()
        txtBarcode = New TextBox()
        lblQuantity = New Label()
        numQuantity = New NumericUpDown()
        lblStock = New Label()
        lblPriceInfo = New Label()
        btnSave = New Button()
        btnCancel = New Button()
        panelHeader.SuspendLayout()
        CType(numQuantity, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        panelHeader.Controls.Add(lblHeaderTitle)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(460, 50)
        panelHeader.TabIndex = 0
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.Location = New Point(20, 14)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(140, 21)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "Add Item to Cart"
        ' 
        ' lblProduct
        ' 
        lblProduct.AutoSize = True
        lblProduct.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblProduct.Location = New Point(25, 68)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(101, 17)
        lblProduct.TabIndex = 1
        lblProduct.Text = "Select Product:"
        ' 
        ' cboProduct
        ' 
        cboProduct.DropDownStyle = ComboBoxStyle.DropDownList
        cboProduct.Font = New Font("Segoe UI", 10F)
        cboProduct.FormattingEnabled = True
        cboProduct.Location = New Point(25, 88)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(410, 25)
        cboProduct.TabIndex = 2
        ' 
        ' lblBarcode
        ' 
        lblBarcode.AutoSize = True
        lblBarcode.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblBarcode.Location = New Point(25, 125)
        lblBarcode.Name = "lblBarcode"
        lblBarcode.Size = New Size(137, 17)
        lblBarcode.TabIndex = 3
        lblBarcode.Text = "Barcode / Item Code:"
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Font = New Font("Segoe UI", 10F)
        txtBarcode.Location = New Point(25, 145)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(410, 25)
        txtBarcode.TabIndex = 4
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblQuantity.Location = New Point(25, 185)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(66, 17)
        lblQuantity.TabIndex = 5
        lblQuantity.Text = "Quantity:"
        ' 
        ' numQuantity
        ' 
        numQuantity.Font = New Font("Segoe UI", 10F)
        numQuantity.Location = New Point(25, 205)
        numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numQuantity.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        numQuantity.Name = "numQuantity"
        numQuantity.Size = New Size(180, 25)
        numQuantity.TabIndex = 6
        numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblStock
        ' 
        lblStock.AutoSize = True
        lblStock.Font = New Font("Segoe UI", 9.5F, FontStyle.Italic)
        lblStock.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblStock.Location = New Point(220, 209)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(100, 17)
        lblStock.TabIndex = 7
        lblStock.Text = "Available: --"
        ' 
        ' lblPriceInfo
        ' 
        lblPriceInfo.AutoSize = True
        lblPriceInfo.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblPriceInfo.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblPriceInfo.Location = New Point(25, 245)
        lblPriceInfo.Name = "lblPriceInfo"
        lblPriceInfo.Size = New Size(125, 19)
        lblPriceInfo.TabIndex = 8
        lblPriceInfo.Text = "Total Price: ₱0.00"
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(215, 285)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(110, 35)
        btnSave.TabIndex = 9
        btnSave.Text = "Add to Cart"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(335, 285)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 35)
        btnCancel.TabIndex = 10
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' SalesItemDialogForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(460, 340)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(lblPriceInfo)
        Controls.Add(lblStock)
        Controls.Add(numQuantity)
        Controls.Add(lblQuantity)
        Controls.Add(txtBarcode)
        Controls.Add(lblBarcode)
        Controls.Add(cboProduct)
        Controls.Add(lblProduct)
        Controls.Add(panelHeader)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "SalesItemDialogForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add Item to Cart"
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        CType(numQuantity, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblProduct As Label
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents lblBarcode As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents lblStock As Label
    Friend WithEvents lblPriceInfo As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
