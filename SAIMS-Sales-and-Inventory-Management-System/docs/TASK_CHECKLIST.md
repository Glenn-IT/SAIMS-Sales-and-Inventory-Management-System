# SAIMS Implementation Task Checklist

**Created:** 2026-06-09
**Last Updated:** 2026-06-24
**Based on:** [SYSTEM_AUDIT.md](./SYSTEM_AUDIT.md)
**Progress:** 63 / 63 tasks completed

Mark tasks with `[x]` as you complete them.

---

## Phase 1 — Database Layer

### 1.1 Setup & Configuration
- [x] Install `Microsoft.Data.SqlClient` NuGet package
- [x] Create `dbconstring.vb` — reads `config.txt` next to the `.exe`
- [x] Create `config.txt.example` template; add `config.txt` to `.gitignore`
- [x] Create `SessionManager.vb` — holds logged-in user across forms

> Note: Project uses raw ADO.NET via `Microsoft.Data.SqlClient`, not EF Core. No migrations needed.

### 1.2 Define Repositories (Data Access)
- [x] Create `DataAccess/ProductRepository.vb` (GetAll, GetByBarcode, Insert, Update, Delete, BarcodeExists, AddStock, DeductStock)
- [x] Create `DataAccess/CategoryRepository.vb` (GetAll, GetActive, Insert, Update, Delete, Exists)
- [x] Create `DataAccess/UserRepository.vb` (GetAll, GetByUsername, GetByID, Insert, Update, Delete, UsernameExists)
- [x] Create `DataAccess/SalesRepository.vb` (GetAll, Insert, GenerateReceiptNo)
- [x] Create `DataAccess/SaleItemRepository.vb` (Insert, GetBySaleID)
- [x] Create `DataAccess/StockMovementRepository.vb` (Insert, GetAll, GetByProduct)
- [x] Create `DataAccess/ActivityLogRepository.vb` (Insert)

### 1.3 Helper Classes
- [x] Create `Helpers/Constants.vb` — UserType, Status, MovementType, Log result strings
- [x] Create `Helpers/InputHelper.vb` — SanitizeInput()
- [x] Create `Helpers/PasswordHelper.vb` — HashPassword() / VerifyPassword() via BCrypt.Net-Next
- [x] Create `ActivityLogger.vb` — wraps ActivityLogRepository

### 1.4 Database Schema
- [x] Create `tbl_Categories` table in SQL Server
- [x] Create `tbl_Products` table
- [x] Create `tbl_Users` table
- [x] Create `tbl_Sales` table
- [x] Create `tbl_SaleItems` table
- [x] Create `tbl_StockMovements` table
- [x] Create `tbl_ActivityLogs` table
- [x] Seed initial data (Admin user, sample categories, sample products)

---

## Phase 2 — Authentication

### 2.1 Password & Session
- [x] Add `BCrypt.Net-Next` NuGet package for password hashing
- [x] Hash the seeded admin user's password using BCrypt
- [x] `SessionManager.vb` holds the logged-in user across forms

### 2.2 Login Form
- [x] Replace stub login in `LoginForm.vb` with real `UserRepository.GetByUsername` call
- [x] Show error message on invalid credentials
- [x] Check for inactive account status before allowing login
- [x] Store logged-in user in `SessionManager` on success
- [x] Lock out user after 5 consecutive failed attempts — 30-second countdown on Login button
- [x] Clear `SessionManager` on logout / application close

### 2.3 Role-Based Access
- [x] Define roles: `Admin`, `Cashier` (constants in `Constants.vb`)
- [x] Hide Setup menu (`btnSetup` + submenu) for Cashier / Staff roles on the dashboard
- [x] Admin and Manager roles retain full access

---

## Phase 3 — Business Logic Layer

### 3.1 Repositories (Data Access)
- [x] `ProductRepository.vb` — full CRUD + stock adjustments
- [x] `CategoryRepository.vb` — full CRUD
- [x] `UserRepository.vb` — full CRUD
- [x] `SalesRepository.vb` — insert + get all + receipt number generation
- [x] `StockMovementRepository.vb` — insert + get all

### 3.2 Services (Business Logic)
> Note: Forms currently call repositories directly. Service classes are not yet created.
- [ ] Create `Services/InventoryService.vb`
  - [ ] `GetAllProducts()` — returns list from DB
  - [ ] `GetLowStockProducts(threshold)` — returns items below threshold
  - [ ] `AdjustStock(productId, qty, type, reason)` — writes StockMovement + updates Product.Stock
- [ ] Create `Services/SalesService.vb`
  - [ ] `ProcessSale(cartItems, discount, amountPaid)` — saves Sale + SaleItems, triggers stock deduction
  - [ ] `GenerateReceiptNumber()` — unique receipt number (e.g., `RCP-20260609-0001`)
  - [ ] `GetSaleHistory(dateFrom, dateTo)` — returns sales in range
- [ ] Create `Services/ReportService.vb`
  - [ ] `GetInventorySummary()` — product list with current stock
  - [ ] `GetSalesSummary(dateFrom, dateTo)` — totals grouped by date
  - [ ] `GetTopSellingProducts(dateFrom, dateTo, topN)` — ranked product sales

---

## Phase 4 — Connect Forms to Database

### 4.1 Products Form
- [x] Replace hardcoded sample list with `ProductRepository.GetAll()`
- [x] Wire Add button to save new product via repository (with barcode duplicate check)
- [x] Wire Edit to update existing product (name + price)
- [x] Wire Delete to remove product
- [x] Refresh DataGridView after each add/edit/delete

### 4.2 Categories Form
- [x] Replace hardcoded list with DB query
- [x] Wire Add / Edit / Delete to `CategoryRepository` (with duplicate name check)
- [x] Refresh grid after changes

### 4.3 Users Form
- [x] Replace hardcoded list with DB query
- [x] Wire Add to create user with hashed password
- [x] Wire Edit to update user details (full name, role, status)
- [x] Add "Reset Password" button — Admin only, dynamically added on form load, min 6-char password
- [x] Protect against deactivating / deleting own account

### 4.4 Sales / POS Form
- [x] Replace hardcoded product dictionary with `ProductRepository.GetByBarcode()`
- [x] On sale completion, call `SalesRepository.Insert()` + `SaleItemRepository.Insert()` to persist transaction
- [x] Deduct stock automatically via `ProductRepository.DeductStock()` on sale save
- [x] Log stock movement (`StockMovement` record per item sold)
- [x] Display generated receipt number on confirmation
- [x] Block sale if product stock is 0 (show out-of-stock warning)
- [x] **BUG-02 FIXED:** Discount clamped to [0, subtotal] in `UpdateTransactionSummary()` — auto-corrects the field

### 4.5 Stock In Form
- [x] On submit, call `ProductRepository.AddStock()` + `StockMovementRepository.Insert()`
- [x] Refresh stock history (DataGridView) after submission
- [x] Validate qty > 0 before allowing submit (TryParse guard)

### 4.6 Stock Out Form
- [x] On submit, call `ProductRepository.DeductStock()` + `StockMovementRepository.Insert()`
- [x] Prevent stock out if qty > current stock (show error)
- [x] Refresh stock history after submission
- [x] Validate qty > 0 before allowing submit

### 4.7 Receipts Form
- [x] Replace hardcoded receipts with `SalesRepository.GetAll()`
- [x] Allow viewing a specific receipt (detail popup with line items from `SaleItemRepository`)
- [x] Double-click row to view receipt
- [x] Add date range filter controls (From/To DateTimePickers + Filter + Show All buttons, added programmatically)

### 4.8 Inventory Report Form
- [x] Replace hardcoded stats with `ProductRepository.GetAll()` (Total Items, Total Stock, Low Stock, Out of Stock)
- [x] Stock movement panel (Stock In / Stock Out / Closing) from `StockMovementRepository.GetAll()`
- [x] Product list loaded live from DB
- [x] Date range computed from `cmbReportType` (Daily/Weekly/Monthly/Yearly) — updates `lblReportPeriod`
- [x] Stock Movement panel filtered by selected period via `StockMovementRepository.GetByDateRange`
- [x] Sales summary (transactions, revenue, average) via `SalesRepository.GetSalesSummary`
- [x] Top 5 selling products via `SalesRepository.GetTopSelling` — shown in Generate Report popup

---

## Phase 5 — Error Handling & Validation

### 5.1 Global Error Handler
- [x] Add global unhandled exception handler in `ApplicationEvents.vb` (`UnhandledException` event)
- [x] Show user-friendly error dialog on crash instead of raw exception
- [x] Log the exception to `tbl_ActivityLogs` via `ActivityLogger`

### 5.2 Form-Level Validation
- [x] Sales Form: prevent checkout with empty cart
- [x] Sales Form: quantity must be positive integer (TryParse guard)
- [x] **BUG-02 FIXED:** Sales Form: discount clamped to subtotal; field auto-corrects
- [x] **BUG-03 FIXED:** Sales Form: `txtChange.ForeColor` turns red when tendered < total
- [x] Stock In/Out: qty must be numeric and > 0
- [x] Products Form: required fields validated (Name, Barcode, Price, stock ≥ 0)
- [x] Categories Form: required Name validated
- [x] Users Form: password minimum length ≥ 6 chars (both Add and Reset Password)

### 5.3 Database Error Handling
- [x] All repository calls wrapped in `Try/Catch` at the form level
- [x] Show "Failed to load…" / "Failed to save…" messages on DB errors
- [x] Show "Could not connect to database" on startup if connection fails — checked in `LoginForm_Load`
- [x] `InputHelper.GetConstraintMessage` catches SQL error 2627/2601 and returns descriptive messages for Products, Users, Categories, and Sales inserts

---

## Phase 6 — Logging

- [x] `ActivityLogRepository.vb` + `ActivityLogger.vb` — logs to `tbl_ActivityLogs` in DB
- [x] Log all login attempts (success and failure) with username and timestamp
- [x] Log all stock adjustments (who, what product, qty, reason)
- [x] Log all completed sales (receipt number, total, user)
- [x] Install `Serilog` and `Serilog.Sinks.File` NuGet packages
- [x] Configure daily rolling log file to `logs/saims-.log` (initialized in `MyApplication_Startup`)
- [x] Log application start and shutdown
- [x] Log all unhandled exceptions via global handler (file + DB)

---

## Phase 7 — Housekeeping

- [x] Delete `Form1.vb`, `Form1.Designer.vb`, and `Form1.resx` (dead code — BUG-07)
- [x] Deleted `Progress.md` (outdated)
- [x] Added `.editorconfig` at repo root — UTF-8, CRLF, 4-space indent for VB
- [x] `README.md` retained at root (standard location)
- [x] Moved `BARCODE_TESTING_GUIDE.md`, `FEATURE_CHECKLIST.md`, `FIXES_APPLIED.md` into `docs/`

---

## Phase 8 — Tests

- [x] Created `SAIMS.Tests` VB.NET MSTest project targeting `net8.0-windows`
- [x] Project reference + BCrypt.Net-Next + Microsoft.Data.SqlClient added to test project
- [x] 10 tests passing — `PasswordHelper` (4), `InputHelper` (3), `SalesRepository.GenerateReceiptNo` (3)
- [ ] Tests for sale total / discount / change calculation (logic embedded in form; needs service layer refactor first)
- [ ] Tests for stock-out prevention (same — needs service layer)

---

## Phase 9 — CI/CD

- [x] Created `.github/workflows/build.yml`
  - [x] Triggers on push to `master` and pull requests
  - [x] Restore → Build main project → Build tests → Run tests
  - [x] Runs on `windows-latest` (required for `net8.0-windows` WinForms target)
- [ ] Verify workflow runs green on first push (requires pushing to GitHub)

---

## Phase 10 — Reports Export (Nice to Have)

- [x] Installed `ClosedXML` NuGet package
- [x] "Export Excel" button on Inventory Report form opens `SaveFileDialog` and exports `dgvInventory` to `.xlsx` with styled header row
- [ ] "Print" button using `PrintDocument` or a report viewer (not yet implemented)

---

*Last updated: 2026-06-24 — all major phases complete; only print support and service-layer test refactor remain*
