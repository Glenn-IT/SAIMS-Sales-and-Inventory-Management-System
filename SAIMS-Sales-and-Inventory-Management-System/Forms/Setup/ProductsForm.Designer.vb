<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductsForm
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
        panelTop = New Panel()
        btnRefresh = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        lblTitle = New Label()
        dgvProducts = New DataGridView()
        colBarcode = New DataGridViewTextBoxColumn()
        colProductName = New DataGridViewTextBoxColumn()
        colCategory = New DataGridViewTextBoxColumn()
        colUnit = New DataGridViewTextBoxColumn()
        colPrice = New DataGridViewTextBoxColumn()
        colStockQty = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        colDateAdded = New DataGridViewTextBoxColumn()
        panelBottom = New Panel()
        lblTotalRecords = New Label()
        panelTop.SuspendLayout()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        panelBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelTop
        ' 
        panelTop.BackColor = Color.White
        panelTop.Controls.Add(btnRefresh)
        panelTop.Controls.Add(btnDelete)
        panelTop.Controls.Add(btnEdit)
        panelTop.Controls.Add(btnAdd)
        panelTop.Controls.Add(txtSearch)
        panelTop.Controls.Add(lblSearch)
        panelTop.Controls.Add(lblTitle)
        panelTop.Dock = DockStyle.Top
        panelTop.Location = New Point(0, 0)
        panelTop.Name = "panelTop"
        panelTop.Padding = New Padding(15, 17, 15, 17)
        panelTop.Size = New Size(1000, 136)
        panelTop.TabIndex = 0
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(410, 79)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 40)
        btnRefresh.TabIndex = 6
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(410, 79)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(100, 40)
        btnDelete.TabIndex = 5
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        btnDelete.Visible = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnEdit.ForeColor = Color.White
        btnEdit.Location = New Point(300, 79)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(100, 40)
        btnEdit.TabIndex = 4
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(190, 79)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(100, 40)
        btnAdd.TabIndex = 3
        btnAdd.Text = "Add New"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(295, 34)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Search by barcode, name, category..."
        txtSearch.Size = New Size(400, 27)
        txtSearch.TabIndex = 2
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 10F)
        lblSearch.Location = New Point(190, 37)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(82, 20)
        lblSearch.TabIndex = 1
        lblSearch.Text = "Search Bar:"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTitle.Location = New Point(15, 28)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(116, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Products"
        ' 
        ' dgvProducts
        ' 
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.AllowUserToDeleteRows = False
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.BackgroundColor = Color.White
        dgvProducts.ColumnHeadersHeight = 40
        dgvProducts.Columns.AddRange(New DataGridViewColumn() {colBarcode, colProductName, colCategory, colUnit, colPrice, colStockQty, colStatus, colDateAdded})
        dgvProducts.Dock = DockStyle.Fill
        dgvProducts.Location = New Point(0, 136)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.ReadOnly = True
        dgvProducts.RowHeadersWidth = 51
        dgvProducts.RowTemplate.Height = 35
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.Size = New Size(1000, 487)
        dgvProducts.TabIndex = 1
        ' 
        ' colBarcode
        ' 
        colBarcode.HeaderText = "Barcode"
        colBarcode.MinimumWidth = 6
        colBarcode.Name = "colBarcode"
        colBarcode.ReadOnly = True
        ' 
        ' colProductName
        ' 
        colProductName.HeaderText = "Product Name"
        colProductName.MinimumWidth = 6
        colProductName.Name = "colProductName"
        colProductName.ReadOnly = True
        ' 
        ' colCategory
        ' 
        colCategory.HeaderText = "Category"
        colCategory.MinimumWidth = 6
        colCategory.Name = "colCategory"
        colCategory.ReadOnly = True
        ' 
        ' colUnit
        ' 
        colUnit.HeaderText = "Unit"
        colUnit.MinimumWidth = 6
        colUnit.Name = "colUnit"
        colUnit.ReadOnly = True
        ' 
        ' colPrice
        ' 
        colPrice.HeaderText = "Price"
        colPrice.MinimumWidth = 6
        colPrice.Name = "colPrice"
        colPrice.ReadOnly = True
        ' 
        ' colStockQty
        ' 
        colStockQty.HeaderText = "Stock Qty"
        colStockQty.MinimumWidth = 6
        colStockQty.Name = "colStockQty"
        colStockQty.ReadOnly = True
        ' 
        ' colStatus
        ' 
        colStatus.HeaderText = "Status"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        ' 
        ' colDateAdded
        ' 
        colDateAdded.HeaderText = "Date Added"
        colDateAdded.MinimumWidth = 6
        colDateAdded.Name = "colDateAdded"
        colDateAdded.ReadOnly = True
        ' 
        ' panelBottom
        ' 
        panelBottom.BackColor = Color.White
        panelBottom.Controls.Add(lblTotalRecords)
        panelBottom.Dock = DockStyle.Bottom
        panelBottom.Location = New Point(0, 623)
        panelBottom.Name = "panelBottom"
        panelBottom.Size = New Size(1000, 57)
        panelBottom.TabIndex = 2
        ' 
        ' lblTotalRecords
        ' 
        lblTotalRecords.AutoSize = True
        lblTotalRecords.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblTotalRecords.Location = New Point(15, 17)
        lblTotalRecords.Name = "lblTotalRecords"
        lblTotalRecords.Size = New Size(180, 20)
        lblTotalRecords.TabIndex = 0
        lblTotalRecords.Text = "Total Record: 0 products"
        ' 
        ' ProductsForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        ClientSize = New Size(1000, 680)
        Controls.Add(dgvProducts)
        Controls.Add(panelBottom)
        Controls.Add(panelTop)
        Name = "ProductsForm"
        Text = "Products Management"
        panelTop.ResumeLayout(False)
        panelTop.PerformLayout()
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        panelBottom.ResumeLayout(False)
        panelBottom.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents panelBottom As Panel
    Friend WithEvents lblTotalRecords As Label
    Friend WithEvents colBarcode As DataGridViewTextBoxColumn
    Friend WithEvents colProductName As DataGridViewTextBoxColumn
    Friend WithEvents colCategory As DataGridViewTextBoxColumn
    Friend WithEvents colUnit As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colStockQty As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colDateAdded As DataGridViewTextBoxColumn
End Class
