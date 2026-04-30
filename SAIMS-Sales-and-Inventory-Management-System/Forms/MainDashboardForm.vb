Public Class MainDashboardForm
    Private currentForm As Form = Nothing

    Private Sub MainDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserInfo.Text = "Admin"
    End Sub

    Private Sub LoadFormInPanel(formToLoad As Form)
        If currentForm IsNot Nothing Then
            currentForm.Close()
        End If

        currentForm = formToLoad
        formToLoad.TopLevel = False
        formToLoad.FormBorderStyle = FormBorderStyle.None
        formToLoad.Dock = DockStyle.Fill
        panelContent.Controls.Clear()
        panelContent.Controls.Add(formToLoad)
        formToLoad.Show()
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        ShowSetupSubmenu()
    End Sub

    Private Sub ShowSetupSubmenu()
        panelSetupSubmenu.Visible = Not panelSetupSubmenu.Visible
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        LoadFormInPanel(New ProductsForm())
    End Sub

    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        LoadFormInPanel(New CategoriesForm())
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        LoadFormInPanel(New UsersForm())
    End Sub

    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        ShowTransactionsSubmenu()
    End Sub

    Private Sub ShowTransactionsSubmenu()
        panelTransactionsSubmenu.Visible = Not panelTransactionsSubmenu.Visible
    End Sub

    Private Sub btnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        LoadFormInPanel(New SalesForm())
    End Sub

    Private Sub btnStockIn_Click(sender As Object, e As EventArgs) Handles btnStockIn.Click
        LoadFormInPanel(New StockInForm())
    End Sub

    Private Sub btnStockOut_Click(sender As Object, e As EventArgs) Handles btnStockOut.Click
        LoadFormInPanel(New StockOutForm())
    End Sub

    Private Sub btnReceipts_Click(sender As Object, e As EventArgs) Handles btnReceipts.Click
        LoadFormInPanel(New ReceiptsForm())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        LoadFormInPanel(New InventoryReportForm())
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MessageBox.Show("Sales and Inventory Management System (SAIMS)" & vbCrLf &
                       "Version 1.0" & vbCrLf &
                       "UI Prototype for Presentation" & vbCrLf & vbCrLf &
                       "Technology: VB.NET WinForms · .NET 8.0" & vbCrLf &
                       "© 2024 SAIMS Development Team",
                       "About SAIMS",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim loginForm As New LoginForm()
            loginForm.Show()
            Me.Close()
        End If
    End Sub
End Class
