# ?? Sales and Inventory Management System (SAIMS) – UI Prototype

> **Technology:** VB.NET WinForms · Visual Studio 2022 · .NET 8.0  
> **Purpose:** Frontend UI Prototype for Presentation Only

---

## ?? Important Notice

* ? **Frontend / UI Only** - This is a UI prototype
* ? **No Database** - No backend integration
* ? **No Authentication Logic** - Simple navigation only
* ? **Sample Placeholder Data** - Hardcoded sample data
* ? **WinForms Designer Layout** - Clean and modern UI
* ? **Navigation between forms only** - Form-to-form navigation

---

## ?? Key Features

### ? Barcode Scanner Support
The **Sales Transaction** module includes full barcode scanner support:
- Real-time barcode input field
- Automatic product lookup by barcode
- Instant cart updates when scanning
- Support for manual product entry
- Enter key triggers barcode processing

---

## ?? Project Structure

```
SAIMS-Sales-and-Inventory-Management-System/
?
??? Forms/
?   ??? LoginForm.vb ........................... ?? Login Screen
?   ??? MainDashboardForm.vb ................... ?? Main Dashboard
?   ?
?   ??? Setup/
?   ?   ??? ProductsForm.vb .................... ?? Products Management
?   ?   ??? CategoriesForm.vb .................. ?? Categories Management
?   ?   ??? UsersForm.vb ....................... ?? Users Management
?   ?
?   ??? Transactions/
?   ?   ??? SalesForm.vb ....................... ?? Sales Transaction (WITH BARCODE SCANNER)
?   ?   ??? StockInForm.vb ..................... ?? Stock In
?   ?   ??? StockOutForm.vb .................... ?? Stock Out
?   ?   ??? ReceiptsForm.vb .................... ?? Receipts
?   ?
?   ??? Reports/
?       ??? InventoryReportForm.vb ............. ?? Inventory Reports
?
??? README.md ................................... ?? This File
```

---

## ?? System Navigation Flow

```
?? Login Form
    ?
?? Main Dashboard
    ??? ?? Setup Module
    ?   ??? ?? Products
    ?   ??? ?? Categories
    ?   ??? ?? Users
    ?
    ??? ?? Transactions Module
    ?   ??? ?? Sales (Barcode Scanner)
    ?   ??? ?? Stock In
    ?   ??? ?? Stock Out
    ?   ??? ?? Receipts
    ?
    ??? ?? Reports Module
        ??? ?? Inventory Report
```

---

## ?? How to Run

### Prerequisites
- Visual Studio 2022 or later
- .NET 8.0 SDK installed
- Windows OS

### Steps
1. **Open the project** in Visual Studio 2022
2. **Build the solution** (Ctrl + Shift + B)
3. **Run the application** (F5)
4. **Login Form** will appear (no actual authentication)
5. Click **"Log In"** to access the Main Dashboard

---

## ?? Form Details

### 1?? Login Form
- Username input field
- Password input field (masked)
- Login button ? Opens Main Dashboard
- Cancel button ? Exits application
- **Note:** No actual authentication logic

---

### 2?? Main Dashboard
- **Top Header:** System title + User info (Admin)
- **Left Sidebar Menu:**
  - ?? Setup (expandable)
  - ?? Transactions (expandable)
  - ?? Reports
  - ?? About Us
  - ?? Logout
- **Main Content Panel:** Loads selected module forms

---

### 3?? Products Management
**Features:**
- DataGridView displaying products
- Search bar (filters products)
- Pagination display
- Add / Edit / Delete buttons
- Refresh button

**Columns:**
- Barcode
- Product Name
- Category
- Price
- Stock Qty
- Status

**Sample Data:** 10 products with various categories

---

### 4?? Categories Management
**Features:**
- Category list (DataGridView)
- Add / Edit / Delete buttons
- Refresh button

**Columns:**
- Category ID
- Category Name
- Description
- Status

**Sample Data:** 8 categories

---

### 5?? Users Management
**Features:**
- User list (DataGridView)
- Add / Update / Delete buttons
- Refresh button

**Columns:**
- User ID
- Username
- Role
- Status

**Sample Data:** 5 users

---

### 6?? Sales Transaction (? WITH BARCODE SCANNER)

**?? Key Feature: Barcode Scanner Support**

**Barcode Input Field:**
- ?? Located at the top of the form
- Accepts barcode scanner input
- Press **ENTER** to process scanned barcode
- Automatically adds product to cart
- Clears input after successful scan
- Shows error if product not found

**Supported Barcodes (Sample):**
- **P001** - Coca Cola 1.5L (?55.00)
- **P002** - Lucky Me Pancit Canton (?12.50)
- **P003** - Argentina Corned Beef (?45.00)
- **P004** - Red Horse Beer (?50.00)
- **P005** - Payless White Sugar 1kg (?65.00)
- **P006** - Champion Detergent (?8.50)
- **P007** - San Miguel Pale Pilsen (?45.00)
- **P008** - Del Monte Tomato Sauce (?18.00)
- **P009** - Alaska Condensed Milk (?35.00) - OUT OF STOCK
- **P010** - Jack n Jill Piattos (?25.00)

**Features:**
- ?? **Barcode Scanner Input** - Primary input method
- ?? Shopping cart (DataGridView)
- ? Add manual item
- ??? Remove item
- ?? Transaction summary panel
- ?? Real-time total calculation
- ?? Discount field
- ?? Payment method selection (Cash, GCash, Credit Card, Debit Card)
- ?? Amount tendered input
- ?? Auto-calculated change
- ?? Save & Print button
- ??? Clear all button
- ? Cancel button

**Cart Columns:**
- Barcode
- Product Name
- Price
- Quantity (editable)
- Total

**Transaction Summary:**
- Total Items
- Subtotal
- Discount
- Total Amount
- Payment Method
- Amount Tendered
- Change

---

### 7?? Stock In
**Features:**
- Product selection dropdown
- Quantity input
- Date picker
- Remarks field
- Add Stock button
- Stock In history (DataGridView)

**History Columns:**
- Stock In ID
- Product Name
- Quantity
- Date
- Remarks

---

### 8?? Stock Out
**Features:**
- Product selection dropdown
- Quantity input
- Reason dropdown (Damaged, Expired, Returns, Wastage, Other)
- Date picker
- Remarks field
- Add Stock Out button
- Stock Out history (DataGridView)

**History Columns:**
- Stock Out ID
- Product Name
- Quantity
- Reason
- Date
- Remarks

---

### 9?? Receipts
**Features:**
- Receipts list (DataGridView)
- View Receipt button
- Print Receipt button
- Refresh button
- Double-click to view

**Columns:**
- Receipt No.
- Date & Time
- Amount
- Payment Method
- Status

**Sample Data:** 8 recent transactions

---

### ?? Inventory Report
**Features:**

**Report Filters:**
- Daily
- Weekly
- Monthly
- Yearly

**Inventory Summary:**
- ?? Total Items
- ?? Total Stock
- ?? Low Stock Count
- ?? Out of Stock Count

**Stock Movement:**
- Opening Stock
- Stock In
- Stock Out
- Closing Stock

**Product List Table:**
- Product Name
- Category
- Price
- Stock
- Status

**Action Buttons:**
- ?? Generate Report
- ?? Export PDF
- ?? Export Excel
- ??? Print
- ?? Refresh

---

## ?? UI Design Guidelines

| **Element**    | **Description**                          |
|----------------|------------------------------------------|
| **Layout**     | Panels for sidebar and content          |
| **Tables**     | DataGridView with alternating rows      |
| **Font**       | Segoe UI (Modern Windows font)          |
| **Colors**     | Professional blue/green color scheme    |
| **Spacing**    | Minimum 10-12px padding                 |
| **Theme**      | Clean and minimal flat design           |
| **Navigation** | Load forms inside main panel            |
| **Icons**      | Emoji icons for visual appeal           |

---

## ?? Color Scheme

| **Color**               | **Usage**                  |
|-------------------------|----------------------------|
| **Blue (#3498db)**      | Primary buttons            |
| **Green (#2ecc71)**     | Success/Add buttons        |
| **Yellow (#f1c40f)**    | Warning/Edit buttons       |
| **Red (#e74c3c)**       | Delete/Danger buttons      |
| **Dark Blue (#34495e)** | Sidebar/Header backgrounds |
| **Light Gray (#ecf0f1)**| Page backgrounds           |
| **White (#ffffff)**     | Panel backgrounds          |

---

## ?? Sample Data Overview

### Products (10 items)
- Beverages: Coca Cola, Red Horse, San Miguel
- Noodles: Lucky Me Pancit Canton
- Canned Goods: Argentina Corned Beef, Del Monte Tomato Sauce
- Groceries: Payless White Sugar
- Household: Champion Detergent
- Dairy: Alaska Condensed Milk
- Snacks: Jack n Jill Piattos

### Categories (8 categories)
- Beverages
- Noodles
- Canned Goods
- Groceries
- Household
- Dairy
- Snacks
- Personal Care

### Users (5 users)
- Admin (Administrator)
- Cashier1 (Cashier)
- Cashier2 (Cashier)
- Manager (Manager)
- Staff1 (Staff - Inactive)

### Receipts (8 transactions)
- Various payment methods (Cash, GCash, Credit Card)
- Different amounts and timestamps
- All completed status

---

## ?? Security Note

?? **This is a UI prototype only!**

- No actual database connections
- No real authentication system
- No data persistence
- No encryption or security measures
- Placeholder data only
- Intended for presentation/demo purposes

---

## ?? Future Enhancements (If Implementing Full System)

1. **Database Integration**
   - SQL Server or MySQL
   - Entity Framework
   - Data persistence

2. **Authentication System**
   - User login validation
   - Role-based access control
   - Password encryption

3. **Barcode Scanner Hardware**
   - USB barcode scanner integration
   - Serial port communication
   - HID keyboard emulation

4. **Business Logic**
   - Inventory calculations
   - Stock alerts
   - Sales analytics
   - Report generation

5. **Reporting**
   - PDF generation
   - Excel export
   - Thermal printer support

6. **Additional Features**
   - Customer management
   - Supplier management
   - Purchase orders
   - Audit logs
   - Dashboard charts

---

## ?? Notes

- All buttons show placeholder messages
- No data is saved between sessions
- Forms load in the main content panel
- Sidebar menu is collapsible
- Sample data is hardcoded
- No validation beyond basic UI checks

---

## ????? Development Info

- **Framework:** .NET 8.0 (Windows)
- **Language:** Visual Basic .NET
- **UI Framework:** Windows Forms
- **IDE:** Visual Studio 2022
- **Target Platform:** Windows Desktop

---

## ?? Support

This is a prototype system for educational/presentation purposes.

---

## ?? License

This is a prototype project for educational purposes.

---

## ? Checklist for Presentation

- [x] Login Form functional
- [x] Main Dashboard navigation works
- [x] All Setup forms accessible
- [x] All Transaction forms accessible
- [x] Reports form accessible
- [x] **Barcode scanner input implemented**
- [x] Sample data displays correctly
- [x] UI is clean and professional
- [x] All buttons have feedback
- [x] Navigation flows smoothly
- [x] No build errors
- [x] Forms load properly
- [x] Logout returns to login

---

## ?? Demonstration Flow

**Recommended demonstration sequence:**

1. **Start** ? Login Form (any credentials)
2. **Dashboard** ? Show sidebar menu
3. **Setup** ? Products (show search, sample data)
4. **Setup** ? Categories (show list)
5. **Setup** ? Users (show user roles)
6. **Transactions** ? **Sales** (demonstrate barcode scanner - type P001 and press Enter)
7. **Transactions** ? Stock In (show form)
8. **Transactions** ? Stock Out (show reasons)
9. **Transactions** ? Receipts (show transaction history)
10. **Reports** ? Inventory Report (show summary & filters)
11. **Logout** ? Return to login

---

**?? TIP:** Use barcodes **P001** to **P010** to test the scanner functionality in Sales!

---

**?? SAIMS v1.0 - Sales and Inventory Management System**  
*Built with ?? using VB.NET WinForms*
