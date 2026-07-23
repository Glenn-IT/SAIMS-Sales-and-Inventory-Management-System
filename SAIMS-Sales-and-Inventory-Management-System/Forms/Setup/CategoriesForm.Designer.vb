<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CategoriesForm
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
        btnToggleStatus = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        lblTitle = New Label()
        dgvCategories = New DataGridView()
        colCategoryID = New DataGridViewTextBoxColumn()
        colCategoryName = New DataGridViewTextBoxColumn()
        colDescription = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        panelTop.SuspendLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelTop
        ' 
        panelTop.BackColor = Color.White
        panelTop.Controls.Add(btnRefresh)
        panelTop.Controls.Add(btnToggleStatus)
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
        btnRefresh.Location = New Point(680, 79)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 40)
        btnRefresh.TabIndex = 5
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnToggleStatus
        ' 
        btnToggleStatus.BackColor = Color.FromArgb(CByte(155), CByte(89), CByte(182))
        btnToggleStatus.FlatStyle = FlatStyle.Flat
        btnToggleStatus.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnToggleStatus.ForeColor = Color.White
        btnToggleStatus.Location = New Point(520, 79)
        btnToggleStatus.Name = "btnToggleStatus"
        btnToggleStatus.Size = New Size(154, 40)
        btnToggleStatus.TabIndex = 4
        btnToggleStatus.Text = "Activate/Deactivate"
        btnToggleStatus.UseVisualStyleBackColor = False
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
        btnDelete.TabIndex = 3
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
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
        btnEdit.TabIndex = 2
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
        btnAdd.TabIndex = 1
        btnAdd.Text = "Add New"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(295, 34)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Search by category name..."
        txtSearch.Size = New Size(400, 27)
        txtSearch.TabIndex = 6
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 10F)
        lblSearch.Location = New Point(190, 37)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(82, 20)
        lblSearch.TabIndex = 7
        lblSearch.Text = "Search Bar:"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTitle.Location = New Point(15, 28)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(135, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Categories"
        ' 
        ' dgvCategories
        ' 
        dgvCategories.AllowUserToAddRows = False
        dgvCategories.AllowUserToDeleteRows = False
        dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCategories.BackgroundColor = Color.White
        dgvCategories.ColumnHeadersHeight = 40
        dgvCategories.Columns.AddRange(New DataGridViewColumn() {colCategoryID, colCategoryName, colDescription, colStatus})
        dgvCategories.Dock = DockStyle.Fill
        dgvCategories.Location = New Point(0, 136)
        dgvCategories.Name = "dgvCategories"
        dgvCategories.ReadOnly = True
        dgvCategories.RowHeadersWidth = 51
        dgvCategories.RowTemplate.Height = 35
        dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCategories.Size = New Size(1000, 544)
        dgvCategories.TabIndex = 1
        ' 
        ' colCategoryID
        ' 
        colCategoryID.HeaderText = "Category ID"
        colCategoryID.MinimumWidth = 6
        colCategoryID.Name = "colCategoryID"
        colCategoryID.ReadOnly = True
        ' 
        ' colCategoryName
        ' 
        colCategoryName.HeaderText = "Category Name"
        colCategoryName.MinimumWidth = 6
        colCategoryName.Name = "colCategoryName"
        colCategoryName.ReadOnly = True
        ' 
        ' colDescription
        ' 
        colDescription.HeaderText = "Description"
        colDescription.MinimumWidth = 6
        colDescription.Name = "colDescription"
        colDescription.ReadOnly = True
        ' 
        ' colStatus
        ' 
        colStatus.HeaderText = "Status"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        ' 
        ' CategoriesForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        ClientSize = New Size(1000, 680)
        Controls.Add(dgvCategories)
        Controls.Add(panelTop)
        Name = "CategoriesForm"
        Text = "Categories Management"
        panelTop.ResumeLayout(False)
        panelTop.PerformLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnToggleStatus As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents dgvCategories As DataGridView
    Friend WithEvents colCategoryID As DataGridViewTextBoxColumn
    Friend WithEvents colCategoryName As DataGridViewTextBoxColumn
    Friend WithEvents colDescription As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
End Class
