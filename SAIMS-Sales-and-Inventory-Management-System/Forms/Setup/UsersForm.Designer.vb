<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UsersForm
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
        btnSetSecurityQuestion = New Button()
        btnResetPassword = New Button()
        btnRefresh = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        lblTitle = New Label()
        dgvUsers = New DataGridView()
        colUserID = New DataGridViewTextBoxColumn()
        colUsername = New DataGridViewTextBoxColumn()
        colRole = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        panelBottom = New Panel()
        lblTotalRecords = New Label()
        panelTop.SuspendLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        panelBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelTop
        ' 
        panelTop.BackColor = Color.White
        panelTop.Controls.Add(btnSetSecurityQuestion)
        panelTop.Controls.Add(btnResetPassword)
        panelTop.Controls.Add(btnRefresh)
        panelTop.Controls.Add(btnDelete)
        panelTop.Controls.Add(btnEdit)
        panelTop.Controls.Add(btnAdd)
        panelTop.Controls.Add(lblTitle)
        panelTop.Dock = DockStyle.Top
        panelTop.Location = New Point(0, 0)
        panelTop.Name = "panelTop"
        panelTop.Padding = New Padding(15, 17, 15, 17)
        panelTop.Size = New Size(1044, 113)
        panelTop.TabIndex = 0
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(460, 57)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 40)
        btnRefresh.TabIndex = 4
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(350, 57)
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
        btnEdit.Location = New Point(240, 57)
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
        btnAdd.Location = New Point(130, 57)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(100, 40)
        btnAdd.TabIndex = 1
        btnAdd.Text = "Add New"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnResetPassword
        ' 
        btnResetPassword.BackColor = Color.FromArgb(CByte(142), CByte(68), CByte(173))
        btnResetPassword.FlatStyle = FlatStyle.Flat
        btnResetPassword.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnResetPassword.ForeColor = Color.White
        btnResetPassword.Location = New Point(570, 57)
        btnResetPassword.Name = "btnResetPassword"
        btnResetPassword.Size = New Size(140, 40)
        btnResetPassword.TabIndex = 5
        btnResetPassword.Text = "Reset Password"
        btnResetPassword.UseVisualStyleBackColor = False
        ' 
        ' btnSetSecurityQuestion
        ' 
        btnSetSecurityQuestion.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnSetSecurityQuestion.FlatStyle = FlatStyle.Flat
        btnSetSecurityQuestion.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnSetSecurityQuestion.ForeColor = Color.White
        btnSetSecurityQuestion.Location = New Point(720, 57)
        btnSetSecurityQuestion.Name = "btnSetSecurityQuestion"
        btnSetSecurityQuestion.Size = New Size(170, 40)
        btnSetSecurityQuestion.TabIndex = 6
        btnSetSecurityQuestion.Text = "Set Security Question"
        btnSetSecurityQuestion.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTitle.Location = New Point(15, 17)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(76, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Users"
        ' 
        ' dgvUsers
        ' 
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.ColumnHeadersHeight = 40
        dgvUsers.Columns.AddRange(New DataGridViewColumn() {colUserID, colUsername, colRole, colStatus})
        dgvUsers.Dock = DockStyle.Fill
        dgvUsers.Location = New Point(0, 113)
        dgvUsers.Name = "dgvUsers"
        dgvUsers.ReadOnly = True
        dgvUsers.RowHeadersWidth = 51
        dgvUsers.RowTemplate.Height = 35
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.Size = New Size(1044, 567)
        dgvUsers.TabIndex = 1
        ' 
        ' colUserID
        ' 
        colUserID.HeaderText = "User ID"
        colUserID.MinimumWidth = 6
        colUserID.Name = "colUserID"
        colUserID.ReadOnly = True
        ' 
        ' colUsername
        ' 
        colUsername.HeaderText = "Username"
        colUsername.MinimumWidth = 6
        colUsername.Name = "colUsername"
        colUsername.ReadOnly = True
        ' 
        ' colRole
        ' 
        colRole.HeaderText = "Role"
        colRole.MinimumWidth = 6
        colRole.Name = "colRole"
        colRole.ReadOnly = True
        ' 
        ' colStatus
        ' 
        colStatus.HeaderText = "Status"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        ' 
        ' panelBottom
        ' 
        panelBottom.BackColor = Color.White
        panelBottom.Controls.Add(lblTotalRecords)
        panelBottom.Dock = DockStyle.Bottom
        panelBottom.Location = New Point(0, 630)
        panelBottom.Name = "panelBottom"
        panelBottom.Size = New Size(1044, 50)
        panelBottom.TabIndex = 2
        ' 
        ' lblTotalRecords
        ' 
        lblTotalRecords.AutoSize = True
        lblTotalRecords.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
        lblTotalRecords.Location = New Point(15, 15)
        lblTotalRecords.Name = "lblTotalRecords"
        lblTotalRecords.Size = New Size(136, 20)
        lblTotalRecords.TabIndex = 0
        lblTotalRecords.Text = "Total Record: 0 users"
        ' 
        ' UsersForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        ClientSize = New Size(1044, 680)
        Controls.Add(dgvUsers)
        Controls.Add(panelBottom)
        Controls.Add(panelTop)
        Name = "UsersForm"
        Text = "Users Management"
        panelTop.ResumeLayout(False)
        panelTop.PerformLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        panelBottom.ResumeLayout(False)
        panelBottom.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents panelTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnResetPassword As Button
    Friend WithEvents btnSetSecurityQuestion As Button
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents colUserID As DataGridViewTextBoxColumn
    Friend WithEvents colUsername As DataGridViewTextBoxColumn
    Friend WithEvents colRole As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents panelBottom As Panel
    Friend WithEvents lblTotalRecords As Label
End Class
