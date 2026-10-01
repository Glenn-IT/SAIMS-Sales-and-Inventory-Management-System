# SAIMS — Capstone Defense Presentation Walkthrough & Panelist Demonstration Guide
<!-- System: Sales and Inventory Management System (SAIMS) -->
<!-- Enterprise Client: Rhenwas Poultry Supply (Poblacion 1, Piat, Cagayan) -->
<!-- Institution: Cagayan State University - Piat Campus (CSU-Piat) -->
<!-- Developers: Aaron Jake Narag Asuncion | Peejay Arravez Taliping -->
<!-- Technology Stack: VB.NET WinForms (.NET 8.0), Microsoft SQL Server, BCrypt, MSTest -->
<!-- Target Audience: Capstone Defense Panelists, Advisers, Deans, and Evaluators -->

---

## 🧭 Executive Summary & Timing Strategy

| Phase | Section | Recommended Duration | Primary Interface |
| :--- | :--- | :--- | :--- |
| **Phase 1** | Project Rationale, Enterprise Context & Local Agro-Supply Problem Statement | 1.5 mins | Title Slide / [LoginForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/LoginForm.vb) |
| **Phase 2** | Technical Architecture, Data Layer & Defensive Security Baseline | 1.0 min | [SAIMS_DB_Setup.sql](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Database/SAIMS_DB_Setup.sql) / [dbconstring.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/dbconstring.vb) |
| **Phase 3** | Operator Authentication, Brute-Force Lockout & Defensive Session Governance | 1.0 min | [LoginForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/LoginForm.vb) & [SessionManager.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/SessionManager.vb) |
| **Phase 4** | Offline Self-Service Security Challenge & Password Recovery Workflow | 1.0 min | [ForgotPasswordForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/ForgotPasswordForm.vb) |
| **Phase 5** | Role-Adaptive Main Dashboard & Dynamic Module Navigation Control | 1.0 min | [MainDashboardForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/MainDashboardForm.vb) |
| **Phase 6** | User Governance, Role Assignment & Security Question Provisioning | 1.0 min | [UsersForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Setup/UsersForm.vb) |
| **Phase 7** | Product Category Classification & Structural Inventory Grouping | 1.0 min | [CategoriesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Setup/CategoriesForm.vb) |
| **Phase 8** | Product Catalog Management, Barcode Encoding & Low-Stock Thresholds | 1.5 mins | [ProductsForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Setup/ProductsForm.vb) |
| **Phase 9** | Stock Replenishment, Delivery Batch Logging & Historical Inflow Tracking | 1.0 min | [StockInForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/StockInForm.vb) |
| **Phase 10** | Point-of-Sale (POS) Cashiering & High-Speed Barcode Checkout | 2.0 mins | [SalesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/SalesForm.vb) |
| **Phase 11** | Transaction Finalization, Instant Stock Deduction & Movement Audit Logging | 1.0 min | [SalesRepository.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/DataAccess/SalesRepository.vb) & [StockMovementRepository.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/DataAccess/StockMovementRepository.vb) |
| **Phase 12** | Thermal Receipt Generation, Audit Trail & POS Receipt Reprinting | 1.0 min | [ReceiptsForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/ReceiptsForm.vb) & [ReceiptPrinter.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Helpers/ReceiptPrinter.vb) |
| **Phase 13** | Executive Inventory Analytics, Stock Valuation & Real-Time Alerts | 1.5 mins | [InventoryReportForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Reports/InventoryReportForm.vb) |
| **Phase 14** | Audit-Compliant Printable Reports with Official Custom Signatories | 1.0 min | [ReportPrinter.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Helpers/ReportPrinter.vb) & Browser PDF View |
| **Phase 15** | In-App System Manual & Interactive Architectural Documentation | 1.0 min | [SystemManualForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/About/SystemManualForm.vb) |
| **Phase 16** | Engineering Credits & Developer Attribution | 0.5 min | [DevelopersInfoForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/About/DevelopersInfoForm.vb) |
| **Phase 17** | Automated MSTest Verification Suite, Code Quality & Database Reliability | 0.5 min | [SAIMS.Tests](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS.Tests/Test1.vb) (`dotnet test`) |
| **Phase 18** | Concluding Defense Synthesis & Transition to Panelist Q&A | 0.5 min | Concluding Slide / Q&A Floor |
| **Total** | **Full System Defense Presentation** | **~18.5 mins** | — |

---

## 🛠️ Pre-Defense Staging & Credentials Setup

Before starting the defense presentation, prepare your demonstration workstation:

1. **Hardware & Scanner Configuration**:
   * **Barcode Scanner:** Connect any standard USB/Bluetooth handheld barcode scanner (operates as an automatic Keyboard Wedge, terminating scans with `ENTER`).
   * **Alternative (No Physical Scanner):** Keep the test barcode cheat sheet open or type test barcodes (`P001` through `P010`) directly into the input field and press `ENTER`.
2. **Database Engine & Connection**:
   * Ensure Microsoft SQL Server is active on your machine (`Glenn\SQLEXPRESS` or local instance).
   * Confirm database schema and initial seed data are synchronized via [`Database/SAIMS_DB_Setup.sql`](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Database/SAIMS_DB_Setup.sql).
   * Confirm [`config.txt`](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/config.txt.example) points to the active instance with `TrustServerCertificate=True`.
3. **Application Build**:
   * Build the solution cleanly in Release or Debug mode via Visual Studio 2022 or terminal: `dotnet build --nologo`.
4. **Automated Test Validation**:
   * Verify all automated unit tests pass prior to presenting by running: `dotnet test .\SAIMS.Tests\SAIMS.Tests.vbproj --nologo` (11 of 11 passing tests).

### 👥 Seeded Demonstration Accounts

| # | Role | Username | Password | Full Name | Access Level / Module Permissions |
| :- | :--- | :--- | :--- | :--- | :--- |
| 1 | **Admin** | `admin` | `admin123` | System Administrator | Unrestricted: Users, Categories, Products, POS, Stock In, Receipts, Reports, Security Resets |
| 2 | **Manager** | `manager` | `manager123` | Store Operations Manager | Products, Categories, Stock In/Out, POS Sales, Inventory Reports, Receipt Auditing |
| 3 | **Cashier** | `cashier1` | `cashier123` | Primary Cashier Desk | Point of Sale (POS), Receipt Printing / Reprinting, Stock In Verification |
| 4 | **Staff** | `staff1` | `staff123` | Warehouse / Floor Staff | Stock In replenishment entry, Product catalog inventory inquiry |

### 📦 Seeded Product Inventory & Barcode Registry

| Barcode | Product Name | Category | Unit | Price (₱) | Stock Qty | Low Stock Threshold | Live Status | Demonstration Purpose |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| **P001** | Coca Cola 1.5L | Beverages | bottle | ₱55.00 | 150 | 20 | `Active / Available` | Standard high-volume item for barcode scan |
| **P002** | Lucky Me Pancit Canton | Noodles | pack | ₱12.50 | 200 | 30 | `Active / Available` | Low unit-price item for multi-quantity test (+5, +10) |
| **P003** | Argentina Corned Beef | Canned Goods | can | ₱45.00 | 80 | 15 | `Active / Available` | Standard grocery / feed store staple |
| **P004** | Red Horse Beer 1L | Beer & Spirits | bottle | ₱50.00 | 100 | 20 | `Active / Available` | Standard retail product |
| **P005** | Sugar 1kg | Condiments | pack | ₱65.00 | 60 | 10 | `Active / Available` | Dry goods inventory demonstration |
| **P006** | Champion Detergent 100g | Detergents | pack | ₱8.50 | 120 | 25 | `Active / Available` | Small pack product for cash change calculation |
| **P007** | San Miguel Beer 330ml | Beer & Spirits | bottle | ₱45.00 | **5** | **5** | `Low Stock Alert` | **Critical Defense Demo:** triggers low stock threshold warning |
| **P008** | Del Monte Tomato Sauce | Condiments | pack | ₱18.00 | 90 | 15 | `Active / Available` | Fast-moving item |
| **P009** | Alaska Condensed Milk | Dairy | can | ₱35.00 | **0** | **10** | `Out of Stock` | **Critical Defense Demo:** POS blocks sale when stock = 0 |
| **P010** | Jack n Jill Piattos | Snacks | pack | ₱25.00 | 110 | 20 | `Active / Available` | General retail item |

---

## 🎬 Step-by-Step Presentation Script (From First to Last)

---

### Step 1: Project Rationale, Enterprise Context & Local Agro-Supply Problem Statement
* **Screen Display:** Title Slide / [LoginForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/LoginForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:** Launch the application; display the clean, modern login interface featuring the official business branding: *"Sales & Inventory Management of Rhenwas Poultry Supply"*.
* **🗣️ Verbal Script:**
  > *"Good morning, honorable panel of examiners, project advisers, and guests. Today, we present **SAIMS — the Sales and Inventory Management System**, custom-built for **Rhenwas Poultry Supply** located in Poblacion 1, Piat, Cagayan.
  >
  > *Piat is a thriving agricultural municipality where poultry farmers, backyard raisers, and agricultural workers depend on local commercial suppliers for poultry feeds, veterinary medicines, supplements, disinfectants, and daily retail supplies.
  >
  > *Historically, Rhenwas Poultry Supply operated entirely on manual paper logbooks and handwritten cashier receipts. This manual workflow suffered from severe operational pain points:
  >
  > 1. **Slow Cashier Checkout:** Cashiers manually wrote prices on receipt stubs and calculated totals by hand, causing long lines during early morning market rushes.
  > 2. **Ghost Stock & Stockouts:** Feed sacks and medicines frequently ran out unnoticed because there was no automated low-stock tracking or expiry alerts.
  > 3. **Unrecorded Discrepancies:** Discrepancies between physical inventory and cash drawers were nearly impossible to trace without an immutable audit trail.
  > 4. **Audit Vulnerability:** Generating weekly sales or inventory reports required hours of manual tallying, highly prone to human mathematical errors.
  >
  > *SAIMS eliminates these vulnerabilities by introducing an integrated, barcode-driven desktop POS, automated stock replenishment tracking, role-governed user access, and one-click printable audit reports."*

---

### Step 2: Technical Architecture, Data Layer & Defensive Security Baseline
* **Screen Display:** Architecture Diagram / [Database/SAIMS_DB_Setup.sql](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Database/SAIMS_DB_Setup.sql) / [dbconstring.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/dbconstring.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:** Present the layered system architecture, database relational model, and technical specifications.
* **🗣️ Verbal Script:**
  > *"Under the hood, SAIMS is engineered with industrial reliability and strict security standards:
  >
  > 1. **Modern Runtime:** Built on **.NET 8.0** and **VB.NET WinForms**, delivering responsive native 64-bit performance without heavy web browser overhead or cloud latency.
  > 2. **Relational Database Integrity:** Powered by **Microsoft SQL Server (`SAIMS_DB`)** across 7 normalized tables: `tbl_Users`, `tbl_Categories`, `tbl_Products`, `tbl_Sales`, `tbl_SaleItems`, `tbl_StockMovements`, and `tbl_ActivityLogs`. Foreign key constraints and unique indexes enforce referential integrity at the database engine level.
  > 3. **Clean Repository Pattern:** All database queries are isolated into specialized DataAccess repositories (`UserRepository`, `ProductRepository`, `SalesRepository`, `StockMovementRepository`), completely decoupling the UI from data queries.
  > 4. **Defensive SQL Parameterization:** 100% of SQL commands utilize strongly-typed `SqlParameter` objects with `SqlCommand`, mathematically eliminating SQL Injection vectors.
  > 5. **Cryptographic Password Security:** Credentials are never stored in plain text. Passwords use **BCrypt with individual cryptographic salts and a cost factor of 11** via [PasswordHelper.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Helpers/PasswordHelper.vb).
  > 6. **Automated Verification:** 11 unit tests running in MSTest continuously validate input sanitization, password hashing algorithms, and session integrity."*

---

### Step 3: Operator Authentication, Brute-Force Lockout & Defensive Session Governance
* **Screen Display:** [Forms/LoginForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/LoginForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Demonstrate client-side input sanitization by entering a name with trailing whitespace or angle brackets.
  2. Type an incorrect password 3 consecutive times to demonstrate the **Defensive Brute-Force Lockout**:
     * Show the countdown timer disabling the login inputs for 30 seconds.
     * Explain that every failed attempt is recorded in `tbl_ActivityLogs`.
  3. Wait for timer or enter valid credentials (`admin` / `admin123`).
  4. Explain how [SessionManager.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/SessionManager.vb) securely retains `UserID`, `Username`, `FullName`, and `UserType` for the lifetime of the session.
* **🗣️ Verbal Script:**
  > *"Security begins at the authentication gateway. 
  >
  > *To protect the enterprise against automated password guessing and credential stuffing, [LoginForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/LoginForm.vb) enforces a defensive **3-attempt brute-force lockout**. After three failed attempts, the interface disables itself for 30 seconds with an active countdown timer, while simultaneously logging the incident to the audit database.
  >
  > *Upon successful validation, [SessionManager.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/SessionManager.vb) instantiates an in-memory session object holding the operator's verified identity and access tier. Furthermore, inactive accounts are immediately blocked from logging in."*

---

### Step 4: Offline Self-Service Security Challenge & Password Recovery Workflow
* **Screen Display:** [Forms/ForgotPasswordForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/ForgotPasswordForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"Forgot Password?"** on the Login Form.
  2. Enter username `admin`.
  3. Show how the system retrieves that specific user's assigned security question (e.g., *"What city were you born in?"*).
  4. Type an incorrect answer to demonstrate the 5-attempt security challenge lockout.
  5. Provide the correct security answer, enter a new password, and demonstrate real-time BCrypt re-hashing and database update.
  6. Return to Login and authenticate with the newly updated password.
* **🗣️ Verbal Script:**
  > *"In rural enterprise environments like Piat, internet outages often disrupt cloud email services and SMS gateways. Therefore, cloud-dependent password reset links are impractical.
  >
  > *SAIMS solves this through an offline, high-security **Self-Service Security Challenge Recovery Workflow**.
  >
  > *When an operator forgets their password, the system challenges them with their pre-configured secret question. The answer itself is cryptographically hashed with BCrypt in `tbl_Users.SecurityAnswerHash`. Once validated, the operator sets a fresh password without requiring manual intervention from a database administrator, ensuring zero store downtime."*

---

### Step 5: Role-Adaptive Main Dashboard & Dynamic Module Navigation Control
* **Screen Display:** [Forms/MainDashboardForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/MainDashboardForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Log in as `admin`. Showcase the top header panel displaying user identity: *"System Administrator (Admin)"*.
  2. Point out the left collapsible sidebar menu:
     * **Setup:** Products, Categories, Users.
     * **Transactions:** Sales (POS), Stock In, Receipts.
     * **Reports:** Inventory Report.
     * **About Us:** System Manual, Developers Info.
     * **Logout Button**.
  3. Explain the **Role-Based Access Control (RBAC)**:
     * If logged in as `Cashier`, the entire `Setup` menu is automatically hidden to prevent cashiers from viewing or altering system users, product prices, or category classifications.
  4. Showcase the dynamic form hosting mechanism in `panelContent` without multiple disjointed desktop windows.
* **🗣️ Verbal Script:**
  > *"Upon authentication, the user enters the Main Dashboard. Notice the clean, ergonomic interface tailored for fast daily operation.
  >
  > *All application modules load dynamically inside the central container panel using parent-child form containment. This prevents desktop window clutter and creates a seamless, modern single-window experience.
  >
  > *Most importantly, the dashboard is **Role-Adaptive**. If a Cashier or Staff member logs in, the administrative Setup menu is automatically hidden from the sidebar. Cashiers can only access the POS Cashiering and Receipt lookup modules, strictly adhering to the Principle of Least Privilege."*

---

### Step 6: User Governance, Role Assignment & Security Question Provisioning
* **Screen Display:** [Forms/Setup/UsersForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Setup/UsersForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Navigate to **Setup -> Users**.
  2. Review the user directory grid: User ID, Username, Full Name, User Type (`Admin`, `Manager`, `Cashier`, `Staff`), Status (`Active`, `Inactive`), and Creation Date.
  3. Click **"Add New"** to display the user creation modal:
     * Enter Full Name, unique Username, Role dropdown, and initial password.
  4. Select a user and click **"Set Security Question"**:
     * Show the selection of standard questions or custom prompts.
     * Explain that the answer is salted and hashed before persistence.
  5. Demonstrate the **"Activate / Deactivate"** toggle:
     * Show how deactivating an account revokes login access immediately without deleting their sales history or transaction audit records.
* **🗣️ Verbal Script:**
  > *"In the User Management module, administrators govern store personnel accounts.
  >
  > *Four distinct operational roles can be assigned: Admin, Manager, Cashier, and Staff. Administrators can provision new accounts, configure secret recovery questions, and perform instant password resets.
  >
  > *Furthermore, instead of performing destructive database deletes which would violate historical sales integrity, administrators simply toggle accounts between 'Active' and 'Inactive'. If an employee resigns, deactivating their account immediately cuts off access while preserving their name on all past receipts and stock movement records."*

---

### Step 7: Product Category Classification & Structural Inventory Grouping
* **Screen Display:** [Forms/Setup/CategoriesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Setup/CategoriesForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Navigate to **Setup -> Categories**.
  2. Showcase existing categories: *Feeds & Grains, Veterinary Medicines, Poultry Supplements, Disinfectants & Chemicals, Feeding Equipment, Beverages, Canned Goods, Condiments*.
  3. Demonstrate real-time searching: type `Feed` in the search box; show the DataGridView instantly filter rows.
  4. Click **"Add New"** to open `CategoryDialogForm`:
     * Enter Category Name: `Biosecurity & Pest Control`.
     * Enter Description: `Rodenticides, fly control, and coop sanitizers`.
     * Click Save. Point out the instant database persistence and notification.
  5. Show duplicate name validation: attempt to create an existing category name and observe the duplicate warning dialog.
* **🗣️ Verbal Script:**
  > *"Effective supply management requires structured classification. In the Category Management module, inventory is cataloged into clear agricultural and retail departments.
  >
  > *Categories feature real-time search filtering, duplicate name prevention, and soft deactivation. Deactivated categories are excluded from new product registration while remaining intact for historical transaction reporting."*

---

### Step 8: Product Catalog Management, Barcode Encoding & Low-Stock Thresholds
* **Screen Display:** [Forms/Setup/ProductsForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Setup/ProductsForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Navigate to **Setup -> Products**.
  2. Review the product catalog grid: Barcode, Product Name, Category, Unit (`bottle`, `pack`, `can`, `sack`), Price, Stock, Stock Status, and Date Added.
  3. Point out the **Stock Status indicator column**:
     * Green: `In Stock` (e.g., *P001 Coca Cola 1.5L* - 150 pcs).
     * Orange/Warning: `Low Stock` (e.g., *P007 San Miguel Beer* - stock is 5, threshold is 5).
     * Red/Danger: `Out of Stock` (e.g., *P009 Alaska Condensed Milk* - stock is 0).
  4. Demonstrate real-time searching by typing `P007` or `Beer` into the search bar.
  5. Click **"Add Product"**:
     * Enter Barcode: `P011`.
     * Name: `B-Meg Integra 3000 Starter 50kg`.
     * Category: `Feeds & Grains`.
     * Unit: `sack`.
     * Price: `₱1,850.00`.
     * Initial Stock: `40`.
     * Low Stock Alert Level: `10`.
     * Save and verify immediate appearance in the grid.
* **🗣️ Verbal Script:**
  > *"The Product Management module represents the core master data repository.
  >
  > *Every product is registered with its unique manufacturer barcode, product name, category, unit of measure, unit retail price, physical stock level, and custom low-stock threshold.
  >
  > *Notice our dynamic stock alerting engine: when physical stock drops to or below the configured low-stock threshold, the status automatically flags as 'Low Stock' in warning orange. If stock reaches zero, it flags as 'Out of Stock' in red. This provides visual inventory intelligence at a single glance."*

---

### Step 9: Stock Replenishment, Delivery Batch Logging & Historical Inflow Tracking
* **Screen Display:** [Forms/Transactions/StockInForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/StockInForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Navigate to **Transactions -> Stock In**.
  2. Point out the replenishment interface:
     * Product dropdown selection.
     * Quantity input field.
     * Delivery Date picker.
     * Supplier/Delivery Remarks text box.
  3. Perform a live stock replenishment demonstration:
     * Select product `P007` (*San Miguel Beer 330ml*, currently low stock with only 5 units).
     * Enter Quantity: `45`.
     * Enter Remarks: `Supplier Delivery Batch #INV-8892 - San Miguel Brewery`.
     * Click **"Add Stock"**.
  4. Showcase the result:
     * The stock level in the summary grid immediately increases from 5 to 50.
     * A permanent record is inserted into `tbl_StockMovements` with `MovementType = 'StockIn'`.
     * An entry is written to `tbl_ActivityLogs` attributing the replenishment to the active operator.
  5. Demonstrate the **"Stock In Summary & Drilldown"**:
     * Show cumulative replenishment quantities grouped by product.
     * Toggle the date filter checkbox to view deliveries received today or within a custom date window.
* **🗣️ Verbal Script:**
  > *"When delivery trucks arrive at Rhenwas Poultry Supply, staff record incoming goods through the Stock In module.
  >
  > *Here, the operator selects the product, specifies the delivered quantity, and enters supplier delivery invoice details.
  >
  > *Upon saving, SAIMS performs an atomic inventory update: the physical stock quantity in `tbl_Products` is immediately credited, an immutable replenishment record is logged in `tbl_StockMovements`, and the action is stamped with the operator's user ID and timestamp.
  >
  > *Notice that product P007, which was previously in 'Low Stock' status with only 5 bottles, now has 50 bottles and automatically transitions back to healthy 'In Stock' status."*

---

### Step 10: Point-of-Sale (POS) Cashiering & High-Speed Barcode Checkout
* **Screen Display:** [Forms/Transactions/SalesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/SalesForm.vb)
* **Estimated Time:** 2.0 minutes
* **Screen Action:**
  1. Navigate to **Transactions -> Sales**.
  2. Point out that the cursor automatically focuses inside the **Barcode Scanner Input** field upon loading.
  3. **Barcode Scanning Demonstration:**
     * Scan or type `P001` and press `ENTER`: *Coca Cola 1.5L* (₱55.00) instantly enters the shopping cart.
     * Scan `P001` a second time: observe the cart quantity automatically increment to `2` with Line Total updated to `₱110.00` and the input field auto-clearing for the next item.
     * Scan `P002` (*Lucky Me Pancit Canton* - ₱12.50).
  4. **Rapid Quantity Adjustment Buttons:**
     * Select *P002* in the cart; click **"+5"** or **"+10"** to demonstrate fast-bulk cashiering for poultry raisers purchasing items in bundles.
     * Alternatively, type a custom quantity directly into the `Qty` box and press `ENTER`.
  5. **Out of Stock Prevention Trap (Defensive Feature):**
     * Scan or type `P009` (*Alaska Condensed Milk*, currently at 0 stock).
     * Show the defensive system warning dialog: *"Product is Out of Stock! (Available: 0)"* and verify that the system refuses to add it to the cart.
  6. **Discount Calculation:**
     * In the summary panel, enter a discount of `₱10.00`.
     * Point out the real-time recalculation: Subtotal, Discount, and Net Total Amount.
  7. **Tendered Cash & Change Calculation:**
     * Point out Payment Method dropdown: `Cash`, `GCash`, `Credit Card`, `Debit Card`.
     * Enter Amount Tendered: `₱500.00`.
     * Point out the auto-calculated change in high-contrast text.
* **🗣️ Verbal Script:**
  > *"Now presenting the primary operational feature of SAIMS: the **High-Speed Point-of-Sale Barcode Cashiering Module**.
  >
  > *When a customer approaches the checkout counter, the cashier simply scans the item with any USB or wireless barcode scanner. SAIMS listens on the input field, intercepts the scanner's carriage return signal, performs a database lookup, and adds the product to the shopping cart in milliseconds.
  >
  > *If the same barcode is scanned again, the system automatically increments the quantity instead of cluttering the cart with duplicate rows. Cashiers can also use rapid increment buttons like '+5' or '+10' for wholesale agricultural transactions.
  >
  > *Notice our **Defensive Inventory Guard**: when we attempt to scan product P009, which has 0 stock in the database, the system immediately blocks the addition with an 'Out of Stock' alert, preventing negative inventory errors.
  >
  > *Finally, the cashier enters the payment details. Discounts and change are computed automatically in real time, eliminating cashier calculation mistakes."*

---

### Step 11: Transaction Finalization, Instant Stock Deduction & Movement Audit Logging
* **Screen Display:** [Forms/Transactions/SalesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/SalesForm.vb) -> Click **"Save & Print"**
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"Save & Print"**.
  2. Point out the system confirmation dialog summarizing:
     * Generated Unique Receipt Number: `RCP-YYYYMMDD-XXXX`.
     * Total Amount Charged.
     * Amount Tendered & Change Due.
  3. Explain the backend database sequence executed during this click:
     * Insert master record into `tbl_Sales` with Cashier ID and payment method.
     * Insert line items into `tbl_SaleItems`.
     * Deduct sold quantities from `tbl_Products.Stock` via `ProductRepository.DeductStock`.
     * Record sales deductions into `tbl_StockMovements` (`MovementType = 'Sale'`).
     * Log successful completion to `tbl_ActivityLogs`.
     * Clear the cart and reset the scanner focus for the next customer.
* **🗣️ Verbal Script:**
  > *"When the cashier clicks 'Save & Print', SAIMS executes an atomic multi-table transaction:
  >
  > 1. It generates an official, non-repeating receipt control number.
  > 2. It inserts the transaction into `tbl_Sales` and line items into `tbl_SaleItems`.
  > 3. It immediately decrements the physical product stock in `tbl_Products`.
  > 4. It logs a corresponding movement record in `tbl_StockMovements` categorized as 'Sale'.
  > 5. It writes an activity log audit entry stamped with the cashier's credentials.
  >
  > *The cart is instantly cleared and the cursor automatically returns to the barcode input field, preparing the cashier for the next customer in less than a second."*

---

### Step 12: Thermal Receipt Generation, Audit Trail & POS Receipt Reprinting
* **Screen Display:** [Forms/Transactions/ReceiptsForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/ReceiptsForm.vb) & Browser Thermal Receipt Window
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Showcase the thermal receipt automatically rendered in Google Chrome via [ReceiptPrinter.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Helpers/ReceiptPrinter.vb):
     * Official Store Header: *Rhenwas Poultry Supply, Poblacion 1, Piat, Cagayan*.
     * Receipt Number, Transaction Timestamp, Cashier Name.
     * Itemized table: Item Name, Quantity, Unit Price, Line Total.
     * Subtotal, Discount, Net Total, Amount Tendered, Change, and Payment Method.
     * Official footer: *"Thank you for your business! Please keep this receipt."*
  2. Navigate to **Transactions -> Receipts**:
     * Showcase the searchable Receipts Audit Ledger.
     * Filter by Date Range (`From` and `To`).
     * Select any past receipt and click **"Print Receipt"** to demonstrate instant receipt reprinting for customer refunds or audit inquiries.
* **🗣️ Verbal Script:**
  > *"Upon completing the sale, SAIMS automatically formats and renders a clean, standardized **58mm/80mm Thermal POS Receipt**.
  >
  > *The receipt contains complete enterprise metadata: store name, address, receipt number, cashier name, itemized pricing, subtotal, discount, cash tendered, and change.
  >
  > *Furthermore, in the Receipts Management module, managers can inspect all past transactions, filter by date range, and reprint authentic receipt duplicates on demand whenever a customer requests a duplicate copy or inquires about an item exchange."*

---

### Step 13: Executive Inventory Analytics, Stock Valuation & Real-Time Alerts
* **Screen Display:** [Forms/Reports/InventoryReportForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Reports/InventoryReportForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Navigate to **Reports -> Inventory Report**.
  2. Showcase the **Executive Inventory KPI Summary Cards**:
     * **Total Items:** Count of registered product lines.
     * **Total Stock:** Cumulative unit count across all warehouse products.
     * **Low Stock Count:** Number of items currently below reorder levels.
     * **Out of Stock Count:** Number of depleted items needing immediate procurement.
  3. Showcase the **Report Type Period Selector**:
     * Select `Daily`, `Weekly`, `Monthly`, or `Yearly`.
     * Observe the dynamic date period banner updating automatically (e.g., *Period: Sep 01, 2026 - Sep 29, 2026*).
  4. Showcase the live **Product Inventory Status Grid**:
     * Review real-time product rows, unit prices, live stock counts, and colored status badges.
* **🗣️ Verbal Script:**
  > *"For store proprietors and managers, operational decisions depend on clear inventory intelligence.
  >
  > *In the Inventory Reports module, SAIMS computes four critical inventory KPIs in real time: Total Product Lines, Total Physical Stock on Hand, Low Stock Alert Count, and Out of Stock Count.
  >
  > *Management can switch between Daily, Weekly, Monthly, and Yearly audit periods with a single click. There is no need to wait until the end of the month to know whether critical poultry feeds or antibiotics are running low."*

---

### Step 14: Audit-Compliant Printable Reports with Official Custom Signatories
* **Screen Display:** [Forms/Reports/InventoryReportForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Reports/InventoryReportForm.vb) -> Click **"Print Report"** -> Browser Print Preview
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. In the **Report Signatory** field, point out how the system auto-fills the name of the logged-in administrator (*System Administrator* or proprietor name).
  2. Click **"Print Report"**.
  3. Showcase the generated HTML/PDF document opened in Google Chrome via [ReportPrinter.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Helpers/ReportPrinter.vb):
     * Official Header: *Rhenwas Poultry Supply - Comprehensive Inventory & Stock Movement Audit Report*.
     * Metadata: Generated Date, Period Covered, Store Address (*Poblacion 1, Piat, Cagayan*).
     * KPI Summary Box: Total Product Lines, Total Physical Units, Low Stock Alerts, Out of Stock Alerts.
     * Formatted Product Inventory Table: Barcode, Item Name, Category, Unit, Unit Price, Current Stock, Status.
     * Formal **Signatory Endorsement Section**:
       * *"Prepared / Certified Correct By: [Signatory Name]"*
       * Signature line and date placeholder.
  4. Press `Ctrl + P` to demonstrate the clean, page-break optimized print layout ready for physical filing or PDF archiving.
* **🗣️ Verbal Script:**
  > *"For formal business reviews, BIR compliance, or bank financing audits, business owners require signed documentation.
  >
  > *With one click, SAIMS compiles the active inventory state into an **Audit-Ready Inventory Report**.
  >
  > *Notice that the document features the official enterprise header, store address, audit period, executive KPI cards, an itemized stock breakdown, and an official 'Prepared By' endorsement line bearing the authorized signatory's name.
  >
  > *The document is formatted with dedicated print media CSS rules, allowing instant physical printing or digital PDF export without awkward layout clipping."*

---

### Step 15: In-App System Manual & Interactive Architectural Documentation
* **Screen Display:** [Forms/About/SystemManualForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/About/SystemManualForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Navigate to **About Us -> System Manual**.
  2. Showcase the comprehensive in-app user guide organized into 8 tabbed chapters:
     * *Overview, Users, Categories, Products, Stock In, Sales (POS), Receipts, Reports*.
  3. Click across different tabs to demonstrate how each section pairs formatted instructional text with embedded system screenshots and operational tips.
  4. Point out that new cashiers or warehouse staff can train themselves directly within the application without needing printed external manuals.
* **🗣️ Verbal Script:**
  > *"To ensure seamless onboarding for newly hired store staff, SAIMS includes an **In-App Interactive System Manual**.
  >
  > *Divided into 8 comprehensive chapters, it guides operators through user management, category setup, product registration, barcode scanning, cashiering shortcuts, and inventory auditing.
  >
  > *Each module pairs step-by-step instructions with high-resolution screenshot references and best practice recommendations, eliminating employee training bottlenecks."*

---

### Step 16: Engineering Credits & Developer Attribution
* **Screen Display:** [Forms/About/DevelopersInfoForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/About/DevelopersInfoForm.vb)
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Navigate to **About Us -> Developers Info**.
  2. Present the software engineering team credentials:
     * **Aaron Jake Narag Asuncion:** 4th Year BSIT, CSU-Piat.
     * **Peejay Arravez Taliping:** 4th Year BSIT, CSU-Piat.
  3. Highlight the institutional affiliation: *Cagayan State University - Piat Campus*.
* **🗣️ Verbal Script:**
  > *"The Developers Information module highlights the engineering team behind SAIMS.
  >
  > *Developed by Aaron Jake Narag Asuncion and Peejay Arravez Taliping, both 4th Year BSIT students at Cagayan State University - Piat Campus, this application represents our commitment to solving real-world enterprise challenges in our local community."*

---

### Step 17: Automated MSTest Verification Suite, Code Quality & Database Reliability
* **Screen Display:** Terminal executing `dotnet test .\SAIMS.Tests\SAIMS.Tests.vbproj --nologo` or [SAIMS.Tests/Test1.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS.Tests/Test1.vb)
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Open a command prompt or integrated terminal in the solution directory.
  2. Execute: `dotnet test .\SAIMS.Tests\SAIMS.Tests.vbproj --nologo`.
  3. Showcase the instant test execution results:
     * `Passed! - Failed: 0, Passed: 11, Skipped: 0, Total: 11`.
  4. Explain the test coverage:
     * Validating BCrypt hashing correctness and non-empty hashes.
     * Validating BCrypt verification with correct vs. wrong passwords.
     * Validating unique salting behavior across identical plaintext inputs.
     * Validating input sanitization and XSS angle bracket stripping.
* **🗣️ Verbal Script:**
  > *"To ensure enterprise-grade stability and zero regression errors, we implemented an automated unit test suite using **Microsoft MSTest**.
  >
  > *Running `dotnet test` executes 11 rigorous automated test cases verifying cryptographic password hashing, salt uniqueness, password verification, and input string sanitization.
  >
  > *Every test passes with 100% success in under 2 seconds, verifying that our core security and utility logic is mathematically proven before deployment."*

---

### Step 18: Concluding Defense Synthesis & Transition to Panelist Q&A
* **Screen Display:** Concluding Slide / Main Dashboard / Terminal
* **Estimated Time:** 0.5 minute
* **Screen Action:** Summarize project achievements, express gratitude to the panel, and open the floor for questioning.
* **🗣️ Verbal Script:**
  > *"In conclusion, SAIMS replaces fragile paper logbooks and manual cashier calculations at Rhenwas Poultry Supply with a secure, barcode-driven, and audit-compliant sales and inventory management ecosystem.
  >
  > *It protects store revenue, accelerates customer checkout, prevents stock depletion, and empowers management with real-time operational intelligence.
  >
  > *Thank you very much, honorable members of the panel. We are now ready and eager to entertain your questions."*

---

## 🛡️ Capstone Defense Panelist Q&A Cheat Sheet

| Question | Recommended Technical & Institutional Answer |
| :--- | :--- |
| **Q1: Why build a desktop WinForms application instead of a web-based or mobile application for Rhenwas Poultry Supply?** | *"In rural municipalities like Piat, Cagayan, **unstable internet connectivity and bandwidth latency** pose significant risks to high-speed commercial retail checkout. A web application that goes offline freezes the cashier's counter and halts store sales. SAIMS is built as a native **.NET 8.0 Windows Forms desktop application** communicating over a local LAN with Microsoft SQL Server. It has zero cloud dependency, delivers sub-millisecond barcode response times, directly interfaces with USB hardware barcode scanners and local thermal POS receipt printers, and continues functioning seamlessly even during complete ISP outages."* |
| **Q2: How does the system handle concurrent transactions and inventory race conditions when multiple cashiers sell the same product simultaneously?** | *"Concurrency is managed through **Microsoft SQL Server ACID transactions and atomic decrement operations**. In [ProductRepository.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/DataAccess/ProductRepository.vb), stock deductions are executed using parameterized atomic SQL statements: `UPDATE tbl_Products SET Stock = Stock - @qty WHERE ProductID = @id AND Stock >= @qty`. The `AND Stock >= @qty` clause guarantees that SQL Server's internal row-level locks prevent two cashiers from reducing stock below zero. If the stock is insufficient, the query affects 0 rows, which the application detects and flags immediately."* |
| **Q3: How does the barcode scanning mechanism function without requiring external scanner drivers or vendor lock-in?** | *"Standard commercial handheld barcode scanners operate in **Keyboard Wedge Emulation Mode**. When a barcode is scanned, the hardware transmits the decoded characters directly into the active Windows focus control as rapid keyboard keystrokes, followed by a carriage return (`Keys.Enter`). In [SalesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/SalesForm.vb), the `txtBarcodeScanner` control maintains permanent input focus and traps `KeyDown` for `Keys.Enter`. It immediately executes `ProductRepository.GetByBarcode()`, retrieves the product, updates the cart, and clears the input box for the next item in under 50 milliseconds, with zero proprietary third-party SDK dependencies."* |
| **Q4: How is operator password security and account recovery handled without internet or external SMTP email servers?** | *"Cloud-dependent password recovery systems rely on email links or SMS gateways, both of which fail when internet access is down. SAIMS implements an offline, high-security **Self-Service Security Challenge Recovery Engine** in [ForgotPasswordForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/ForgotPasswordForm.vb). Each operator configures a secret challenge question whose answer is salted and hashed with **BCrypt (cost factor 11)** in `tbl_Users.SecurityAnswerHash`. The system validates the hashed response locally, locks out the terminal after 5 incorrect attempts, and allows password reset without database administrator intervention."* |
| **Q5: What prevents a cashier from selling items that are completely out of stock or causing negative inventory?** | *"SAIMS enforces a strict two-layer inventory guard: (1) **UI-Level Pre-Check:** In [SalesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/SalesForm.vb), when a product is scanned or added to the cart, the system checks `If product.Stock <= 0` or if the requested quantity exceeds available stock. If violated, an alert is displayed and the item is rejected. (2) **Database-Level Guard:** In [ProductRepository.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/DataAccess/ProductRepository.vb), stock deductions require `Stock >= @qty`, mathematically preventing negative quantities in the database."* |
| **Q6: How are stock replenishments audited and reconciled with historical inventory counts?** | *"SAIMS implements a **Double-Entry Stock Movement Ledger** in `tbl_StockMovements`. Whenever inventory changes — whether through a delivery replenishment in [StockInForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/StockInForm.vb), a customer sale in [SalesForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Transactions/SalesForm.vb), or a damaged goods write-off — the system records `MovementType` (`StockIn`, `StockOut`, `Sale`), the exact quantity change, supplier or receipt references, the responsible operator's `UserID`, and a timestamp. Physical inventory audits can be reconciled by calculating `Opening Stock + Stock In - Sales = Closing Stock`."* |
| **Q7: How does the system protect against SQL Injection, cross-site scripting, and unauthorized database tampering?** | *"We employ defense-in-depth: (1) **100% Parameterized SQL Commands:** User inputs are passed strictly as typed parameters (`cmd.Parameters.AddWithValue` or explicit `SqlDbType`), ensuring input strings are treated strictly as literals, completely neutralizing SQL Injection. (2) **Input Sanitization:** [InputHelper.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Helpers/InputHelper.vb) trims whitespace and strips HTML/script tags (`<`, `>`). (3) **Repository Isolation:** Forms never construct raw SQL queries directly; all operations pass through dedicated repository classes. (4) **Audit Trails:** All security-sensitive actions and login failures are logged to `tbl_ActivityLogs`."* |
| **Q8: How does thermal receipt printing and formal inventory report generation work without proprietary Crystal Reports or heavy third-party reporting libraries?** | *"Proprietary reporting tools like Crystal Reports or ActiveReports introduce heavy runtime dependencies, licensing costs, and frequent DLL version conflicts. In SAIMS, [ReceiptPrinter.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Helpers/ReceiptPrinter.vb) and [ReportPrinter.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/Helpers/ReportPrinter.vb) generate clean, standards-compliant HTML5 documents with embedded CSS print media queries (`@media print`). Receipts format dynamically for 58mm/80mm thermal roll paper, while inventory reports generate professional multi-page letter-sized layouts with headers, footers, and official signatory lines. The document opens directly in Google Chrome or the default browser, allowing instant printing or zero-loss PDF export."* |
| **Q9: How does role-based access control restrict unauthorized cashiers from altering prices, deleting categories, or resetting credentials?** | *"Role-based permissions are enforced at the architectural level. In [MainDashboardForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/MainDashboardForm.vb), `ApplyRoleAccess()` checks `SessionManager.UserType`. For Cashier and Staff roles, the administrative `btnSetup` and its entire submenu (Products, Categories, Users) are rendered invisible. Even within accessible forms like [UsersForm.vb](file:///C:/Users/GLENN/source/repos/SAIMS-Sales-and-Inventory-Management-System/SAIMS-Sales-and-Inventory-Management-System/Forms/Setup/UsersForm.vb), credential reset buttons check `SessionManager.UserType = Constants.USERTYPE_ADMIN`. A cashier has physically no interface to modify prices, user accounts, or financial settings."* |
| **Q10: How scalable is SAIMS if Rhenwas Poultry Supply opens branch stores in Solana, Tuao, or Tuguegarao City?** | *"Because SAIMS utilizes a decoupled repository architecture and centralized SQL Server database, scaling to multiple store locations is straightforward: (1) **Local Area Network (LAN):** Multiple POS terminals within the Piat store connect to a single local SQL Server instance. (2) **Multi-Branch Scaling:** By adding a `BranchID` foreign key to `tbl_Sales`, `tbl_StockMovements`, and `tbl_Products`, multiple branches can either connect to a secure centralized SQL Server instance via VPN, or maintain local SQL instances with automated end-of-day replication, reusing 100% of the existing business logic and UI modules."* |

---

## 💡 Pro-Tips for Defense Day

1. **Barcode Scanner Demonstration Setup:**
   * If using a physical USB scanner, test it 15 minutes before the defense by opening Notepad and scanning a barcode. Confirm it outputs the barcode followed by an Enter keypress.
   * If presenting without a physical scanner, have the seeded test barcodes ready on a small sticky note or index card:
     * `P001` (Coke 1.5L - Available)
     * `P002` (Pancit Canton - Available, test "+5" quantity button)
     * `P007` (San Miguel Beer - Low Stock trigger!)
     * `P009` (Alaska Condensed Milk - Out of Stock block!)
   * Simply typing `P001` and pressing `ENTER` mimics the exact signal sent by an optical scanner.
2. **Demonstrate the "Out of Stock" & "Low Stock" Traps:**
   * Defense panels love seeing **defensive programming and business validation rules**.
   * First, show product `P009` in the Products table with 0 stock. Then go to Sales POS and try to scan `P009`. When the red "Out of Stock" message appears, highlight how this prevents ghost inventory sales and keeps store records accurate.
   * Then show product `P007` with stock level 5. Explain how the threshold warns warehouse staff to reorder before the product completely runs out.
3. **Showcase the Dual Print Outputs:**
   * Demonstrate both the **Thermal POS Receipt** (via `ReceiptsForm.vb` or POS checkout) and the **Formal Inventory Report with Executive Signatory** (via `InventoryReportForm.vb`).
   * Point out the official enterprise address (*Poblacion 1, Piat, Cagayan*) and the custom signatory line (*Prepared By: System Administrator / Proprietor*). Panelists appreciate clean, real-world bureaucratic documents.
4. **Demonstrate Automated Code Quality Live:**
   * If a technical panelist asks about test coverage, error handling, or code quality, open PowerShell and run:
     ```powershell
     dotnet test .\SAIMS.Tests\SAIMS.Tests.vbproj --nologo
     ```
   * Showing **11 passing tests** covering cryptographic password security and input sanitization provides immediate proof of software engineering rigor.
5. **Highlight Local Agricultural Impact:**
   * Ground your presentation in Piat, Cagayan's agricultural reality: mention local poultry growers, feed supply cycles, delivery trucks coming from suppliers, and how reducing checkout wait times directly improves customer loyalty for Rhenwas Poultry Supply.
6. **Ensure 100% Offline Readiness:**
   * Confirm SQL Server is running locally on your laptop (`Glenn\SQLEXPRESS`).
   * Because SAIMS has zero external cloud dependencies, your entire presentation and live demo will execute flawlessly even if the campus Wi-Fi disconnects during the defense.
