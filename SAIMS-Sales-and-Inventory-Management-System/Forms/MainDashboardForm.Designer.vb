<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainDashboardForm
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
        lblUserInfo = New Label()
        lblHeader = New Label()
        panelSidebar = New Panel()
        btnLogout = New Button()
        btnAbout = New Button()
        btnReports = New Button()
        panelTransactionsSubmenu = New Panel()
        btnReceipts = New Button()
        btnStockIn = New Button()
        btnSales = New Button()
        btnTransactions = New Button()
        panelSetupSubmenu = New Panel()
        btnUsers = New Button()
        btnCategories = New Button()
        btnProducts = New Button()
        btnSetup = New Button()
        panelLogo = New Panel()
        lblLogo = New Label()
        panelContent = New Panel()
        panelHeader.SuspendLayout()
        panelSidebar.SuspendLayout()
        panelTransactionsSubmenu.SuspendLayout()
        panelSetupSubmenu.SuspendLayout()
        panelLogo.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        panelHeader.Controls.Add(lblUserInfo)
        panelHeader.Controls.Add(lblHeader)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(250, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(1050, 68)
        panelHeader.TabIndex = 0
        ' 
        ' lblUserInfo
        ' 
        lblUserInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblUserInfo.AutoSize = True
        lblUserInfo.Font = New Font("Segoe UI", 10.0F)
        lblUserInfo.ForeColor = Color.White
        lblUserInfo.Location = New Point(950, 23)
        lblUserInfo.Name = "lblUserInfo"
        lblUserInfo.Size = New Size(53, 20)
        lblUserInfo.TabIndex = 1
        lblUserInfo.Text = "Admin"
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblHeader.ForeColor = Color.White
        lblHeader.Location = New Point(20, 19)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(308, 30)
        lblHeader.TabIndex = 0
        lblHeader.Text = "Main Dashboard - SAIMS v1.0"
        ' 
        ' panelSidebar
        ' 
        panelSidebar.AutoScroll = True
        panelSidebar.BackColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        panelSidebar.Controls.Add(btnLogout)
        panelSidebar.Controls.Add(btnAbout)
        panelSidebar.Controls.Add(btnReports)
        panelSidebar.Controls.Add(panelTransactionsSubmenu)
        panelSidebar.Controls.Add(btnTransactions)
        panelSidebar.Controls.Add(panelSetupSubmenu)
        panelSidebar.Controls.Add(btnSetup)
        panelSidebar.Controls.Add(panelLogo)
        panelSidebar.Dock = DockStyle.Left
        panelSidebar.Location = New Point(0, 0)
        panelSidebar.Name = "panelSidebar"
        panelSidebar.Size = New Size(250, 793)
        panelSidebar.TabIndex = 1
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnLogout.Dock = DockStyle.Bottom
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(0, 742)
        btnLogout.Name = "btnLogout"
        btnLogout.Padding = New Padding(10, 0, 0, 0)
        btnLogout.Size = New Size(250, 51)
        btnLogout.TabIndex = 7
        btnLogout.Text = "Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnAbout
        ' 
        btnAbout.Dock = DockStyle.Top
        btnAbout.FlatAppearance.BorderSize = 0
        btnAbout.FlatStyle = FlatStyle.Flat
        btnAbout.Font = New Font("Segoe UI", 10.0F)
        btnAbout.ForeColor = Color.White
        btnAbout.Location = New Point(0, 561)
        btnAbout.Name = "btnAbout"
        btnAbout.Padding = New Padding(10, 0, 0, 0)
        btnAbout.Size = New Size(250, 51)
        btnAbout.TabIndex = 6
        btnAbout.Text = "About Us"
        btnAbout.TextAlign = ContentAlignment.MiddleLeft
        btnAbout.UseVisualStyleBackColor = True
        ' 
        ' btnReports
        ' 
        btnReports.Dock = DockStyle.Top
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Segoe UI", 10.0F)
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(0, 510)
        btnReports.Name = "btnReports"
        btnReports.Padding = New Padding(10, 0, 0, 0)
        btnReports.Size = New Size(250, 51)
        btnReports.TabIndex = 3
        btnReports.Text = "Reports"
        btnReports.TextAlign = ContentAlignment.MiddleLeft
        btnReports.UseVisualStyleBackColor = True
        ' 
        ' panelTransactionsSubmenu
        ' 
        panelTransactionsSubmenu.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        panelTransactionsSubmenu.Controls.Add(btnReceipts)
        panelTransactionsSubmenu.Controls.Add(btnStockIn)
        panelTransactionsSubmenu.Controls.Add(btnSales)
        panelTransactionsSubmenu.Dock = DockStyle.Top
        panelTransactionsSubmenu.Location = New Point(0, 329)
        panelTransactionsSubmenu.Name = "panelTransactionsSubmenu"
        panelTransactionsSubmenu.Size = New Size(250, 136)
        panelTransactionsSubmenu.TabIndex = 5
        panelTransactionsSubmenu.Visible = False
        ' 
        ' btnReceipts
        ' 
        btnReceipts.Dock = DockStyle.Top
        btnReceipts.FlatAppearance.BorderSize = 0
        btnReceipts.FlatStyle = FlatStyle.Flat
        btnReceipts.Font = New Font("Segoe UI", 9.0F)
        btnReceipts.ForeColor = Color.White
        btnReceipts.Location = New Point(0, 90)
        btnReceipts.Name = "btnReceipts"
        btnReceipts.Padding = New Padding(35, 0, 0, 0)
        btnReceipts.Size = New Size(250, 45)
        btnReceipts.TabIndex = 3
        btnReceipts.Text = "Receipts"
        btnReceipts.TextAlign = ContentAlignment.MiddleLeft
        btnReceipts.UseVisualStyleBackColor = True
        ' 
        ' btnStockIn
        ' 
        btnStockIn.Dock = DockStyle.Top
        btnStockIn.FlatAppearance.BorderSize = 0
        btnStockIn.FlatStyle = FlatStyle.Flat
        btnStockIn.Font = New Font("Segoe UI", 9.0F)
        btnStockIn.ForeColor = Color.White
        btnStockIn.Location = New Point(0, 45)
        btnStockIn.Name = "btnStockIn"
        btnStockIn.Padding = New Padding(35, 0, 0, 0)
        btnStockIn.Size = New Size(250, 45)
        btnStockIn.TabIndex = 1
        btnStockIn.Text = "Stock In"
        btnStockIn.TextAlign = ContentAlignment.MiddleLeft
        btnStockIn.UseVisualStyleBackColor = True
        ' 
        ' btnSales
        ' 
        btnSales.Dock = DockStyle.Top
        btnSales.FlatAppearance.BorderSize = 0
        btnSales.FlatStyle = FlatStyle.Flat
        btnSales.Font = New Font("Segoe UI", 9.0F)
        btnSales.ForeColor = Color.White
        btnSales.Location = New Point(0, 0)
        btnSales.Name = "btnSales"
        btnSales.Padding = New Padding(35, 0, 0, 0)
        btnSales.Size = New Size(250, 45)
        btnSales.TabIndex = 0
        btnSales.Text = "Sales"
        btnSales.TextAlign = ContentAlignment.MiddleLeft
        btnSales.UseVisualStyleBackColor = True
        ' 
        ' btnTransactions
        ' 
        btnTransactions.Dock = DockStyle.Top
        btnTransactions.FlatAppearance.BorderSize = 0
        btnTransactions.FlatStyle = FlatStyle.Flat
        btnTransactions.Font = New Font("Segoe UI", 10.0F)
        btnTransactions.ForeColor = Color.White
        btnTransactions.Location = New Point(0, 278)
        btnTransactions.Name = "btnTransactions"
        btnTransactions.Padding = New Padding(10, 0, 0, 0)
        btnTransactions.Size = New Size(250, 51)
        btnTransactions.TabIndex = 4
        btnTransactions.Text = "Transactions"
        btnTransactions.TextAlign = ContentAlignment.MiddleLeft
        btnTransactions.UseVisualStyleBackColor = True
        ' 
        ' panelSetupSubmenu
        ' 
        panelSetupSubmenu.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        panelSetupSubmenu.Controls.Add(btnUsers)
        panelSetupSubmenu.Controls.Add(btnCategories)
        panelSetupSubmenu.Controls.Add(btnProducts)
        panelSetupSubmenu.Dock = DockStyle.Top
        panelSetupSubmenu.Location = New Point(0, 142)
        panelSetupSubmenu.Name = "panelSetupSubmenu"
        panelSetupSubmenu.Size = New Size(250, 136)
        panelSetupSubmenu.TabIndex = 2
        panelSetupSubmenu.Visible = False
        ' 
        ' btnUsers
        ' 
        btnUsers.Dock = DockStyle.Top
        btnUsers.FlatAppearance.BorderSize = 0
        btnUsers.FlatStyle = FlatStyle.Flat
        btnUsers.Font = New Font("Segoe UI", 9.0F)
        btnUsers.ForeColor = Color.White
        btnUsers.Location = New Point(0, 90)
        btnUsers.Name = "btnUsers"
        btnUsers.Padding = New Padding(35, 0, 0, 0)
        btnUsers.Size = New Size(250, 45)
        btnUsers.TabIndex = 2
        btnUsers.Text = "Users"
        btnUsers.TextAlign = ContentAlignment.MiddleLeft
        btnUsers.UseVisualStyleBackColor = True
        ' 
        ' btnCategories
        ' 
        btnCategories.Dock = DockStyle.Top
        btnCategories.FlatAppearance.BorderSize = 0
        btnCategories.FlatStyle = FlatStyle.Flat
        btnCategories.Font = New Font("Segoe UI", 9.0F)
        btnCategories.ForeColor = Color.White
        btnCategories.Location = New Point(0, 45)
        btnCategories.Name = "btnCategories"
        btnCategories.Padding = New Padding(35, 0, 0, 0)
        btnCategories.Size = New Size(250, 45)
        btnCategories.TabIndex = 1
        btnCategories.Text = "Categories"
        btnCategories.TextAlign = ContentAlignment.MiddleLeft
        btnCategories.UseVisualStyleBackColor = True
        ' 
        ' btnProducts
        ' 
        btnProducts.Dock = DockStyle.Top
        btnProducts.FlatAppearance.BorderSize = 0
        btnProducts.FlatStyle = FlatStyle.Flat
        btnProducts.Font = New Font("Segoe UI", 9.0F)
        btnProducts.ForeColor = Color.White
        btnProducts.Location = New Point(0, 0)
        btnProducts.Name = "btnProducts"
        btnProducts.Padding = New Padding(35, 0, 0, 0)
        btnProducts.Size = New Size(250, 45)
        btnProducts.TabIndex = 0
        btnProducts.Text = "Products"
        btnProducts.TextAlign = ContentAlignment.MiddleLeft
        btnProducts.UseVisualStyleBackColor = True
        ' 
        ' btnSetup
        ' 
        btnSetup.Dock = DockStyle.Top
        btnSetup.FlatAppearance.BorderSize = 0
        btnSetup.FlatStyle = FlatStyle.Flat
        btnSetup.Font = New Font("Segoe UI", 10.0F)
        btnSetup.ForeColor = Color.White
        btnSetup.Location = New Point(0, 91)
        btnSetup.Name = "btnSetup"
        btnSetup.Padding = New Padding(10, 0, 0, 0)
        btnSetup.Size = New Size(250, 51)
        btnSetup.TabIndex = 1
        btnSetup.Text = "Setup"
        btnSetup.TextAlign = ContentAlignment.MiddleLeft
        btnSetup.UseVisualStyleBackColor = True
        ' 
        ' panelLogo
        ' 
        panelLogo.Controls.Add(lblLogo)
        panelLogo.Dock = DockStyle.Top
        panelLogo.Location = New Point(0, 0)
        panelLogo.Name = "panelLogo"
        panelLogo.Size = New Size(250, 91)
        panelLogo.TabIndex = 0
        ' 
        ' lblLogo
        ' 
        lblLogo.AutoSize = True
        lblLogo.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblLogo.ForeColor = Color.White
        lblLogo.Location = New Point(60, 32)
        lblLogo.Name = "lblLogo"
        lblLogo.Size = New Size(126, 30)
        lblLogo.TabIndex = 0
        lblLogo.Text = "SAIMS v1.0"
        ' 
        ' panelContent
        ' 
        panelContent.BackColor = Color.White
        panelContent.Dock = DockStyle.Fill
        panelContent.Location = New Point(250, 68)
        panelContent.Name = "panelContent"
        panelContent.Size = New Size(1050, 725)
        panelContent.TabIndex = 2
        ' 
        ' MainDashboardForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1300, 793)
        Controls.Add(panelContent)
        Controls.Add(panelHeader)
        Controls.Add(panelSidebar)
        Name = "MainDashboardForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAIMS - Main Dashboard"
        WindowState = FormWindowState.Maximized
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        panelSidebar.ResumeLayout(False)
        panelTransactionsSubmenu.ResumeLayout(False)
        panelSetupSubmenu.ResumeLayout(False)
        panelLogo.ResumeLayout(False)
        panelLogo.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents lblHeader As Label
    Friend WithEvents panelSidebar As Panel
    Friend WithEvents panelLogo As Panel
    Friend WithEvents lblLogo As Label
    Friend WithEvents btnSetup As Button
    Friend WithEvents panelSetupSubmenu As Panel
    Friend WithEvents btnProducts As Button
    Friend WithEvents btnCategories As Button
    Friend WithEvents btnUsers As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnTransactions As Button
    Friend WithEvents panelTransactionsSubmenu As Panel
    Friend WithEvents btnSales As Button
    Friend WithEvents btnStockIn As Button
    Friend WithEvents btnReceipts As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents panelContent As Panel
End Class
