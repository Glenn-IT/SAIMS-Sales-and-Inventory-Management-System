Imports System.Drawing

Public Class SystemManualForm

    Private Sub SystemManualForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateManual()
    End Sub

    Private Sub PopulateManual()
        txtManualContent.Clear()

        AppendHeader("SAIMS — SALES AND INVENTORY MANAGEMENT SYSTEM")
        AppendSubHeader("SYSTEM OPERATING MANUAL & USER GUIDE" & vbCrLf)

        AppendSectionTitle("1. OVERVIEW & ACCESS ROLES")
        AppendText("SAIMS is an enterprise sales and inventory management application designed for streamlined product tracking, inventory replenishment, point-of-sale (POS) cashier transactions, and receipt auditing." & vbCrLf & vbCrLf)
        AppendBullet("Administrator / Manager", "Full access to Setup (Users, Products, Categories), Stock In, Sales POS, Receipts, and Reports.")
        AppendBullet("Cashier", "Access to Point-of-Sale (Sales), Receipts viewing & printing, and Stock In functions.")

        AppendSectionTitle("2. SETUP & INVENTORY MANAGEMENT")
        AppendBullet("Categories Setup", "Manage product classifications. Add, edit, or delete categories.")
        AppendBullet("Products Setup", "Register products with Barcode, Name, Category, Price, Unit (pcs, kg, box), Initial Stock, and Low Stock Alert Quantity threshold.")
        AppendBullet("User Management", "Admin can create accounts, assign roles (Admin/Manager/Cashier), reset passwords, and set security questions.")

        AppendSectionTitle("3. STOCK IN & MOVEMENT LOGGING")
        AppendBullet("Stock In Entry", "Select a product (or scan barcode), enter quantity added, date, and optional remarks.")
        AppendBullet("Automatic Stock Update", "Every Stock In updates total product stock and logs the movement with timestamp for audit trails.")
        AppendBullet("Added vs Total Quantity", "The grid displays both the added quantity for that entry and the updated Total Quantity (TQ) of the product.")

        AppendSectionTitle("4. SALES & POINT-OF-SALE (POS)")
        AppendBullet("Barcode Scanner Integration", "Scan barcode in POS search box or press Enter to add items to cart instantly.")
        AppendBullet("Cart Management", "Adjust quantity or remove cart items directly.")
        AppendBullet("Discount & Payment", "Apply discounts and enter amount tendered. Change is calculated automatically.")
        AppendBullet("Save & Print", "Completing a transaction saves the sale, deducts product stock, and opens the printable receipt.")

        AppendSectionTitle("5. RECEIPTS & PRINTING")
        AppendBullet("Receipt History", "View all completed sales filtered by date range or search key.")
        AppendBullet("View Receipt Detail", "Double-click or select a row and click 'View Receipt' to view full item breakdown and payment info.")
        AppendBullet("Print Receipt / PDF Export", "Click 'Print Receipt' to open a formatted HTML receipt directly in Google Chrome where you can print to physical thermal printers or save as PDF.")

        AppendSectionTitle("6. AUDIT TRAIL & LOGOUT")
        AppendBullet("Activity Audit Logs", "All critical system actions (logins, stock changes, sales) are logged for security auditing.")
        AppendBullet("Secure Logout", "Click 'Logout' on the sidebar menu to safely clear active user session.")
    End Sub

    Private Sub AppendHeader(text As String)
        txtManualContent.SelectionFont = New Font("Segoe UI", 14, FontStyle.Bold)
        txtManualContent.SelectionColor = Color.FromArgb(41, 128, 185)
        txtManualContent.AppendText(text & vbCrLf)
    End Sub

    Private Sub AppendSubHeader(text As String)
        txtManualContent.SelectionFont = New Font("Segoe UI", 10, FontStyle.Italic)
        txtManualContent.SelectionColor = Color.FromArgb(127, 140, 141)
        txtManualContent.AppendText(text & vbCrLf & vbCrLf)
    End Sub

    Private Sub AppendSectionTitle(text As String)
        txtManualContent.SelectionFont = New Font("Segoe UI", 11, FontStyle.Bold)
        txtManualContent.SelectionColor = Color.FromArgb(52, 73, 94)
        txtManualContent.AppendText(text & vbCrLf)
    End Sub

    Private Sub AppendText(text As String)
        txtManualContent.SelectionFont = New Font("Segoe UI", 10, FontStyle.Regular)
        txtManualContent.SelectionColor = Color.FromArgb(44, 62, 80)
        txtManualContent.AppendText(text)
    End Sub

    Private Sub AppendBullet(title As String, description As String)
        txtManualContent.SelectionFont = New Font("Segoe UI", 10, FontStyle.Bold)
        txtManualContent.SelectionColor = Color.FromArgb(44, 62, 80)
        txtManualContent.AppendText("  • " & title & ": ")

        txtManualContent.SelectionFont = New Font("Segoe UI", 10, FontStyle.Regular)
        txtManualContent.SelectionColor = Color.FromArgb(52, 73, 94)
        txtManualContent.AppendText(description & vbCrLf)
    End Sub

End Class
