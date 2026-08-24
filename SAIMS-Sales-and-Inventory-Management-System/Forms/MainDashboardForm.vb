Public Class MainDashboardForm
    Private currentForm As Form = Nothing

    Private Sub MainDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserInfo.Text = $"{SessionManager.FullName} ({SessionManager.UserType})"
        ApplyRoleAccess()
    End Sub

    Private Sub ApplyRoleAccess()
        Dim isAdmin As Boolean = (SessionManager.UserType = Constants.USERTYPE_ADMIN OrElse
                                  SessionManager.UserType = Constants.USERTYPE_MANAGER)
        btnSetup.Visible          = isAdmin
        panelSetupSubmenu.Visible = False
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

    ''' Loads the requested feature if it's unlocked for the current presentation version,
    ''' otherwise shows the "Under Construction" placeholder maximized in panelContent instead.
    Private Sub LoadGatedForm(requiredVersion As Integer, formFactory As Func(Of Form))
        If requiredVersion <= UnderConstructionForm.CURRENT_VERSION_NUMBER Then
            LoadFormInPanel(formFactory())
        Else
            LoadFormInPanel(New UnderConstructionForm())
        End If
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        ShowSetupSubmenu()
    End Sub

    Private Sub ShowSetupSubmenu()
        panelSetupSubmenu.Visible = Not panelSetupSubmenu.Visible
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        LoadGatedForm(3, Function() New ProductsForm())
    End Sub

    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        LoadGatedForm(1, Function() New CategoriesForm())
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        LoadGatedForm(2, Function() New UsersForm())
    End Sub

    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        ShowTransactionsSubmenu()
    End Sub

    Private Sub ShowTransactionsSubmenu()
        panelTransactionsSubmenu.Visible = Not panelTransactionsSubmenu.Visible
    End Sub

    Private Sub btnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        LoadGatedForm(7, Function() New SalesForm())
    End Sub

    Private Sub btnStockIn_Click(sender As Object, e As EventArgs) Handles btnStockIn.Click
        LoadGatedForm(4, Function() New StockInForm())
    End Sub

    Private Sub btnReceipts_Click(sender As Object, e As EventArgs) Handles btnReceipts.Click
        LoadGatedForm(8, Function() New ReceiptsForm())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        LoadGatedForm(6, Function() New InventoryReportForm())
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        ShowAboutSubmenu()
    End Sub

    Private Sub ShowAboutSubmenu()
        panelAboutSubmenu.Visible = Not panelAboutSubmenu.Visible
    End Sub

    Private Sub btnSystemManual_Click(sender As Object, e As EventArgs) Handles btnSystemManual.Click
        LoadFormInPanel(New SystemManualForm())
    End Sub

    Private Sub btnDevelopersInfo_Click(sender As Object, e As EventArgs) Handles btnDevelopersInfo.Click
        LoadFormInPanel(New DevelopersInfoForm())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ActivityLogger.Log(SessionManager.Username, Constants.LOG_SUCCESS, "User logged out.")
            SessionManager.Clear()
            Dim loginForm As New LoginForm()
            loginForm.Show()
            Me.Close()
        End If
    End Sub
End Class
