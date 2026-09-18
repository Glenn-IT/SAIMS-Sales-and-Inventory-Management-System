Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Public Class SystemManualForm

    Private Sub SystemManualForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuildManualTabs()
    End Sub

    Private Sub SystemManualForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AdjustAllSplitters()
    End Sub

    Private Sub tabManual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabManual.SelectedIndexChanged
        AdjustAllSplitters()
    End Sub

    Private Sub AdjustAllSplitters()
        For Each page As TabPage In tabManual.TabPages
            For Each c As Control In page.Controls
                If TypeOf c Is SplitContainer Then
                    Dim s = DirectCast(c, SplitContainer)
                    If s.Width > 500 Then
                        Dim target = CInt(s.Width * 0.44)
                        If target > 200 AndAlso target < (s.Width - 250) Then
                            Try
                                s.SplitterDistance = target
                            Catch
                            End Try
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub BuildManualTabs()
        tabManual.SuspendLayout()
        tabManual.TabPages.Clear()

        ' 1. System Overview
        AddManualTab("Overview", "System Overview & Access Roles", "DashboardOverview.png",
            Sub(rtb)
                AppendTitle(rtb, "SALES & INVENTORY MANAGEMENT SYSTEM")
                AppendSubtitle(rtb, "Rhenwas Poultry Supply — User Operating Manual & Architectural Guide")

                AppendHeading(rtb, "1. System Introduction")
                AppendParagraph(rtb, "The Sales & Inventory Management System (SAIMS) is an enterprise desktop application tailored for Rhenwas Poultry Supply. It centralizes inventory control, stock replenishments, fast-paced point-of-sale cashiering, and automated audit logging.")

                AppendHeading(rtb, "2. User Access Roles & Privileges")
                AppendBullet(rtb, "Administrator", "Unrestricted access across all modules: User Management, Product & Category Setup, Stock Movements, Point-of-Sale (Sales), Receipts Auditing, Financial & Stock Reports, and Activity Logs.")
                AppendBullet(rtb, "Manager", "Comprehensive operational management: Products, Categories, Stock In/Out movements, Sales transactions, and Inventory Reports.")
                AppendBullet(rtb, "Cashier", "Dedicated cashier workflow: Point-of-Sale checkout, Receipt viewing and reprinting, and Stock In verification.")
                AppendBullet(rtb, "Staff", "Inventory handling: Stock replenishment entry and inventory lookup.")

                AppendHeading(rtb, "3. Dashboard & Sidebar Navigation")
                AppendParagraph(rtb, "The main window features a collapsible sidebar that organizes all functionality into intuitive submenus:")
                AppendBullet(rtb, "Setup Submenu", "Provides direct links to Products Management, Categories Setup, and User Accounts.")
                AppendBullet(rtb, "Transactions Submenu", "Houses Point-of-Sale (Sales), Stock In replenishment, and Receipts history.")
                AppendBullet(rtb, "Reports", "Direct access to executive inventory summaries and printable stock status reports.")
                AppendBullet(rtb, "About Us Submenu", "Provides the System Manual (this guide) and Developer Contact details.")
                AppendBullet(rtb, "Logout", "Safely clears the authenticated session, logs the logout timestamp to the audit trail, and returns to the Login screen.")

                AppendTip(rtb, "TIP: The system automatically adapts its sidebar menus depending on the role of the currently logged-in user.")
            End Sub)

        ' 2. User Management
        AddManualTab("Users", "User Management & Security", "UsersForm.png",
            Sub(rtb)
                AppendTitle(rtb, "USER MANAGEMENT")
                AppendSubtitle(rtb, "Operator Credentials, Roles, and Account Security (Admin Only)")

                AppendHeading(rtb, "1. Overview & Capabilities")
                AppendParagraph(rtb, "The User Management module allows administrators to create system operator accounts, assign operational roles, reset credentials, and configure security recovery questions.")

                AppendHeading(rtb, "2. Adding a New User")
                AppendBullet(rtb, "Step 1", "Click the 'Add New' button above the user records grid.")
                AppendBullet(rtb, "Step 2", "In the dialog, enter the operator's Full Name and a unique Username.")
                AppendBullet(rtb, "Step 3", "Select the appropriate Role (Admin, Manager, Cashier, or Staff).")
                AppendBullet(rtb, "Step 4", "Enter an initial password. Passwords are securely hashed with BCrypt salt before database storage.")
                AppendBullet(rtb, "Step 5", "Click 'Save' to immediately register the new operator.")

                AppendHeading(rtb, "3. Modifying & Deactivating Accounts")
                AppendBullet(rtb, "Editing", "Select any user in the table and click 'Edit' to update name, role, or contact info.")
                AppendBullet(rtb, "Status Control", "Click 'Activate/Deactivate' to toggle account accessibility. Deactivating locks the account without deleting sales history or audit records.")

                AppendHeading(rtb, "4. Password Reset & Recovery Questions")
                AppendBullet(rtb, "Reset Password", "Administrators can click 'Reset Password' to assign a fresh temporary password to users who forgot their credentials.")
                AppendBullet(rtb, "Security Question", "Click 'Set Security Question' to configure secret challenge questions used on the Login screen's Forgot Password flow.")

                AppendTip(rtb, "SECURITY NOTE: System passwords are never stored in plain text. Always ensure operators choose memorable security questions.")
            End Sub)

        ' 3. Category Setup
        AddManualTab("Categories", "Category Classification Setup", "CategoriesForm.png",
            Sub(rtb)
                AppendTitle(rtb, "CATEGORY SETUP")
                AppendSubtitle(rtb, "Organizing Products into Logical Inventory Classifications")

                AppendHeading(rtb, "1. Purpose of Product Categories")
                AppendParagraph(rtb, "Categories organize poultry supply inventory (e.g. Feeds, Antibiotics, Supplements, Equipment, Disinfectants) for structured product creation and segmented reporting.")

                AppendHeading(rtb, "2. Category Operations")
                AppendBullet(rtb, "Add New Category", "Click 'Add New', type the Category Name (must be unique) and an optional Description, then click 'Save'.")
                AppendBullet(rtb, "Edit Category", "Select a category row, click 'Edit', modify details in the dialog, and confirm.")
                AppendBullet(rtb, "Activate / Deactivate", "Click 'Activate/Deactivate' to toggle availability. Inactive categories remain in existing transaction history but are hidden from new product entries.")
                AppendBullet(rtb, "Search Filter", "Type in the 'Search Bar' to filter category names in real-time as you type.")
                AppendBullet(rtb, "Refresh", "Click 'Refresh' at any time to reload category records directly from the database.")

                AppendTip(rtb, "BEST PRACTICE: Group fast-moving seasonal supplies under distinct categories for faster inventory audits.")
            End Sub)

        ' 4. Product Setup
        AddManualTab("Products", "Product Catalog & Inventory Settings", "ProductsForm.png",
            Sub(rtb)
                AppendTitle(rtb, "PRODUCT MANAGEMENT")
                AppendSubtitle(rtb, "Catalog Registration, Pricing, Barcodes, and Stock Thresholds")

                AppendHeading(rtb, "1. Product Master Registry")
                AppendParagraph(rtb, "The Products module serves as the single source of truth for all poultry supply items sold or stocked by Rhenwas Poultry Supply.")

                AppendHeading(rtb, "2. Adding a Product")
                AppendBullet(rtb, "Barcode Input", "Scan the item's barcode using a handheld scanner, or type a custom unique barcode number.")
                AppendBullet(rtb, "Product Name", "Enter the descriptive name of the feed, medicine, or supply.")
                AppendBullet(rtb, "Category & Unit", "Choose the parent Category from the dropdown. Select the Unit of measure (pcs, kg, sack, bottle, box).")
                AppendBullet(rtb, "Cost & Selling Price", "Input the Cost Price (supplier purchase cost) and Selling Price (retail price).")
                AppendBullet(rtb, "Initial Stock", "Enter the opening inventory quantity present on shelves or warehouse.")
                AppendBullet(rtb, "Low Stock Warning Level", "Set the threshold quantity (e.g., 10 sacks). When stock falls to or below this level, the system alerts managers.")

                AppendHeading(rtb, "3. Searching & Managing Products")
                AppendBullet(rtb, "Instant Search", "Search by Barcode or Product Name in the search box to filter instantly.")
                AppendBullet(rtb, "Edit Product", "Select an item and click 'Edit' to adjust pricing, unit, or status.")
                AppendBullet(rtb, "Status Flag", "Set products as Available or Inactive when discontinued.")

                AppendTip(rtb, "TIP: Maintain accurate Low Stock thresholds so that the Inventory Reports module can proactively flag items requiring reorders.")
            End Sub)

        ' 5. Stock In
        AddManualTab("Stock In", "Stock Replenishment & Delivery Logging", "StockInForm.png",
            Sub(rtb)
                AppendTitle(rtb, "STOCK IN MANAGEMENT")
                AppendSubtitle(rtb, "Warehouse Inflow, Barcode Ingestion, and Movement Audit")

                AppendHeading(rtb, "1. Replenishing Warehouse Stock")
                AppendParagraph(rtb, "Whenever a supplier delivers feeds, vaccines, or store items, the Stock In module records the arrival, credits product stock, and writes a permanent timestamped movement log.")

                AppendHeading(rtb, "2. How to Record Incoming Stock")
                AppendBullet(rtb, "Step 1", "Select the product from the dropdown list, or scan the barcode directly.")
                AppendBullet(rtb, "Step 2", "Type the incoming Quantity delivered.")
                AppendBullet(rtb, "Step 3", "Enter optional Remarks (e.g., Supplier Invoice #, Batch #, or Delivery Truck ID).")
                AppendBullet(rtb, "Step 4", "Confirm the delivery Date and click 'Add Stock'.")

                AppendHeading(rtb, "3. Understanding Stock In Grid & Metrics")
                AppendBullet(rtb, "Current Stock", "Displays the immediate live quantity available in the store.")
                AppendBullet(rtb, "Total Stocked In", "Cumulative tally of all incoming units recorded for this item.")
                AppendBullet(rtb, "Last Stock In Date", "Exact date and time when the most recent replenishment occurred.")
                AppendBullet(rtb, "View Dates Action", "Click 'View Dates' in any row to inspect all historical delivery dates and quantities for that specific product.")
                AppendBullet(rtb, "Filter by Date", "Check 'Filter by Date' and choose a date to isolate deliveries received on that day.")

                AppendTip(rtb, "AUDIT SAFETY: All stock additions log the active user's name and cannot be altered retrospectively.")
            End Sub)

        ' 6. Point of Sale (POS)
        AddManualTab("Sales (POS)", "Point of Sale Cashier Checkout", "SalesForm.png",
            Sub(rtb)
                AppendTitle(rtb, "POINT OF SALE (POS) & SALES TRANSACTION")
                AppendSubtitle(rtb, "Rapid Barcode Checkout, Cart Adjustments, Payment & Change")

                AppendHeading(rtb, "1. Point-of-Sale Workflow")
                AppendParagraph(rtb, "Designed for fast, error-free retail operations at Rhenwas Poultry Supply. Supports automatic barcode scanners and rapid keyboard entry.")

                AppendHeading(rtb, "2. Adding Items to Cart")
                AppendBullet(rtb, "Barcode Scanner", "Scan the barcode directly into the search bar and press Enter to instantly increment the cart.")
                AppendBullet(rtb, "Manual Product Lookup", "Click 'Add Manual' or type the item name to pick products without physical barcodes.")
                AppendBullet(rtb, "Quantity Quick-Buttons", "Select a cart line and click '-', '+', '+5', or '+10' to adjust units on the fly.")
                AppendBullet(rtb, "Remove Item", "Highlight any row in the cart and click 'Remove Item' to delete it.")

                AppendHeading(rtb, "3. Pricing, Discounts & Payment")
                AppendBullet(rtb, "Subtotal & Discount", "Subtotal calculates automatically. Type an optional Discount to apply immediate price reductions.")
                AppendBullet(rtb, "Payment Method", "Select Cash, GCash, Debit Card, or Credit Card.")
                AppendBullet(rtb, "Amount Tendered & Change", "Enter the cash given by the customer. The Change box updates automatically in real-time.")
                AppendBullet(rtb, "Save & Print", "Click 'Save & Print' (or Enter) to finalize the transaction. Stock is deducted, the sale is recorded, and the print receipt dialog opens.")

                AppendTip(rtb, "SHORTCUT: Press 'Clear All' to reset the transaction if a customer cancels before checkout.")
            End Sub)

        ' 7. Receipts History
        AddManualTab("Receipts", "Receipt Auditing & Thermal Printing", "ReceiptsForm.png",
            Sub(rtb)
                AppendTitle(rtb, "RECEIPTS HISTORY & AUDIT")
                AppendSubtitle(rtb, "Sales Transaction Archives, Detail Breakdown, and Thermal Printing")

                AppendHeading(rtb, "1. Historical Sales Ledger")
                AppendParagraph(rtb, "Every finalized transaction generates a unique receipt number (e.g. RCP-20260914-212056). This module allows cashiers and managers to locate, audit, and reprint any transaction.")

                AppendHeading(rtb, "2. Searching & Date Filtering")
                AppendBullet(rtb, "Date Range Search", "Select 'From' and 'To' dates and click 'Filter Date' to view receipts from specific periods.")
                AppendBullet(rtb, "Show All", "Click 'Show All' to reset date filters and view the complete receipt archive.")

                AppendHeading(rtb, "3. Viewing Receipt Details & Printing")
                AppendBullet(rtb, "View Receipt", "Double-click any receipt row (or select and click 'View Receipt') to open the modal breakdown showing every purchased item, quantity, unit price, cashier, and tendered payment.")
                AppendBullet(rtb, "Print Receipt", "Click 'Print Receipt' to render a clean, high-contrast HTML receipt directly in Google Chrome. Compatible with 58mm/80mm POS thermal receipt printers and standard paper.")
                AppendBullet(rtb, "PDF Export", "In the Google Chrome print preview, choose 'Save as PDF' to archive digital copies.")

                AppendTip(rtb, "AUDIT NOTE: Receipts track the exact cashier who processed the sale for accountability.")
            End Sub)

        ' 8. Inventory Reports
        AddManualTab("Reports", "Inventory Analytics & Audit Reports", "InventoryReportForm.png",
            Sub(rtb)
                AppendTitle(rtb, "INVENTORY & SALES REPORTS")
                AppendSubtitle(rtb, "Stock Health Summary, Low Stock Alerts, and Printable Reports")

                AppendHeading(rtb, "1. Executive Inventory KPI Summary")
                AppendParagraph(rtb, "The Reports module aggregates live stock data into actionable executive metrics:")
                AppendBullet(rtb, "Total Items", "Total number of registered catalog products.")
                AppendBullet(rtb, "Total Stock", "Total cumulative physical quantity on hand across all items.")
                AppendBullet(rtb, "Low Stock", "Count of products that have reached or dropped below their threshold alert level.")
                AppendBullet(rtb, "Out of Stock", "Count of items with zero stock remaining requiring immediate supplier reorders.")

                AppendHeading(rtb, "2. Report Periods & Signatory")
                AppendBullet(rtb, "Report Type", "Choose Daily, Weekly, Monthly, or Annual intervals to evaluate stock movement trends.")
                AppendBullet(rtb, "Signatory Name", "Enter the name and title of the inspecting manager or inventory officer.")
                AppendBullet(rtb, "Print Report", "Click 'Print' to open a formatted official inventory document with company branding, summary tables, and signature blocks ready for physical printing or PDF filing.")
                AppendBullet(rtb, "Refresh", "Click 'Refresh' to recalculate live stock tallies after receiving new deliveries.")

                AppendTip(rtb, "MANAGEMENT TIP: Generate the Monthly report at the end of each month to support accounting audits.")
            End Sub)

        tabManual.ResumeLayout(True)
    End Sub

    Private Sub AddManualTab(tabTitle As String, headerText As String, screenshotFile As String, populateTextAction As Action(Of RichTextBox))
        Dim page As New TabPage(tabTitle) With {
            .BackColor = Color.White,
            .Padding = New Padding(8)
        }

        ' Main split container: Left for documentation text, Right for Screenshot preview
        Dim split As New SplitContainer() With {
            .Dock = DockStyle.Fill,
            .Orientation = Orientation.Vertical,
            .SplitterWidth = 6,
            .BackColor = Color.FromArgb(220, 225, 230)
        }

        ' Handle dynamic proportional sizing
        AddHandler split.SizeChanged, Sub()
            If split.Width > 500 Then
                Dim targetDistance = CInt(split.Width * 0.44)
                If targetDistance > 200 AndAlso targetDistance < (split.Width - 250) Then
                    Try
                        split.SplitterDistance = targetDistance
                    Catch
                    End Try
                End If
            End If
        End Sub

        ' === LEFT PANEL: Documentation Content ===
        Dim panelDoc As New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White,
            .Padding = New Padding(12)
        }

        Dim rtb As New RichTextBox() With {
            .Dock = DockStyle.Fill,
            .ReadOnly = True,
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.White,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular),
            .ScrollBars = RichTextBoxScrollBars.Vertical
        }

        populateTextAction(rtb)
        panelDoc.Controls.Add(rtb)
        split.Panel1.Controls.Add(panelDoc)
        split.Panel1.BackColor = Color.White

        ' === RIGHT PANEL: Screenshot Preview Card ===
        Dim panelPreview As New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(248, 249, 250),
            .Padding = New Padding(10)
        }

        ' Screenshot card container with border
        Dim card As New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' Card header banner
        Dim cardHeader As New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 38,
            .BackColor = Color.FromArgb(52, 73, 94),
            .Padding = New Padding(10, 8, 10, 6)
        }

        Dim lblCardTitle As New Label() With {
            .Text = "Form Interface: " & headerText,
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.White,
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoEllipsis = True
        }
        cardHeader.Controls.Add(lblCardTitle)

        ' Screenshot PictureBox
        Dim loadedImage As Image = GetManualImage(screenshotFile)
        Dim pic As New PictureBox() With {
            .Dock = DockStyle.Fill,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .BackColor = Color.FromArgb(245, 247, 250),
            .Image = loadedImage,
            .Cursor = Cursors.Hand
        }

        ' Bottom button bar for View Full Size
        Dim cardFooter As New Panel() With {
            .Dock = DockStyle.Bottom,
            .Height = 40,
            .BackColor = Color.FromArgb(241, 245, 249),
            .Padding = New Padding(8, 6, 8, 6)
        }

        Dim lblHint As New Label() With {
            .Text = "Click image or button to zoom",
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Italic),
            .ForeColor = Color.FromArgb(127, 140, 141),
            .Dock = DockStyle.Left,
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoSize = True
        }

        Dim btnViewFull As New Button() With {
            .Text = "Zoom / Full Size",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(41, 128, 185),
            .FlatStyle = FlatStyle.Flat,
            .Dock = DockStyle.Right,
            .Width = 135,
            .Cursor = Cursors.Hand
        }
        btnViewFull.FlatAppearance.BorderSize = 0

        Dim openViewerAction As Action = Sub()
            Using viewer As New ScreenshotViewerForm(headerText, loadedImage)
                viewer.ShowDialog(Me)
            End Using
        End Sub

        AddHandler btnViewFull.Click, Sub() openViewerAction()
        AddHandler pic.Click, Sub() openViewerAction()

        cardFooter.Controls.Add(lblHint)
        cardFooter.Controls.Add(btnViewFull)

        card.Controls.Add(pic)
        card.Controls.Add(cardFooter)
        card.Controls.Add(cardHeader)

        panelPreview.Controls.Add(card)
        split.Panel2.Controls.Add(panelPreview)
        split.Panel2.BackColor = Color.White

        page.Controls.Add(split)
        tabManual.TabPages.Add(page)
    End Sub

    Private Function GetManualImage(fileName As String) As Image
        Try
            ' 1. Check local application directory Resources/ManualScreenshots
            Dim localPath = Path.Combine(Application.StartupPath, "Resources", "ManualScreenshots", fileName)
            If File.Exists(localPath) Then
                Return Image.FromFile(localPath)
            End If

            ' 2. Check solution directory relative to runtime
            Dim devPath = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\Resources\ManualScreenshots", fileName))
            If File.Exists(devPath) Then
                Return Image.FromFile(devPath)
            End If

            ' 3. Check AppDomain base directory
            Dim baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ManualScreenshots", fileName)
            If File.Exists(baseDir) Then
                Return Image.FromFile(baseDir)
            End If

            ' 4. Check embedded resource in assembly
            Dim asm = Assembly.GetExecutingAssembly()
            Dim resNames = asm.GetManifestResourceNames()
            Dim match = resNames.FirstOrDefault(Function(n) n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase))
            If Not String.IsNullOrEmpty(match) Then
                Using s = asm.GetManifestResourceStream(match)
                    If s IsNot Nothing Then
                        Return Image.FromStream(s)
                    End If
                End Using
            End If
        Catch ex As Exception
            ' fallback to placeholder
        End Try

        ' Fallback clean placeholder graphic
        Dim bmp As New Bitmap(800, 500)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.FromArgb(245, 247, 250))
            Using pen As New Pen(Color.FromArgb(189, 195, 199), 2)
                g.DrawRectangle(pen, 20, 20, 760, 460)
            End Using
            Using f As New Font("Segoe UI", 14.0F, FontStyle.Bold)
                Using b As New SolidBrush(Color.FromArgb(52, 73, 94))
                    g.DrawString("📸 Form Preview: " & fileName, f, b, 40, 230)
                End Using
            End Using
        End Using
        Return bmp
    End Function

#Region "RichText Formatting Helpers"

    Private Sub AppendTitle(rtb As RichTextBox, text As String)
        rtb.SelectionFont = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(41, 128, 185)
        rtb.AppendText(text & vbCrLf)
    End Sub

    Private Sub AppendSubtitle(rtb As RichTextBox, text As String)
        rtb.SelectionFont = New Font("Segoe UI", 9.5F, FontStyle.Italic)
        rtb.SelectionColor = Color.FromArgb(127, 140, 141)
        rtb.AppendText(text & vbCrLf & vbCrLf)
    End Sub

    Private Sub AppendHeading(rtb As RichTextBox, text As String)
        rtb.SelectionFont = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(52, 73, 94)
        rtb.AppendText(text & vbCrLf)
    End Sub

    Private Sub AppendParagraph(rtb As RichTextBox, text As String)
        rtb.SelectionFont = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        rtb.SelectionColor = Color.FromArgb(44, 62, 80)
        rtb.AppendText(text & vbCrLf & vbCrLf)
    End Sub

    Private Sub AppendBullet(rtb As RichTextBox, title As String, description As String)
        rtb.SelectionFont = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(41, 128, 185)
        rtb.AppendText("  • " & title & ": ")

        rtb.SelectionFont = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        rtb.SelectionColor = Color.FromArgb(52, 73, 94)
        rtb.AppendText(description & vbCrLf)
    End Sub

    Private Sub AppendTip(rtb As RichTextBox, tipText As String)
        rtb.AppendText(vbCrLf)
        rtb.SelectionFont = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(39, 174, 96)
        rtb.AppendText("NOTE / TIP: " & tipText & vbCrLf)
    End Sub

#End Region

End Class
