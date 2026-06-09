# SAIMS Implementation Task Checklist

**Created:** 2026-06-09
**Based on:** [SYSTEM_AUDIT.md](./SYSTEM_AUDIT.md)
**Progress:** 0 / 63 tasks completed

Mark tasks with `[x]` as you complete them.

---

## Phase 1 — Database Layer

### 1.1 Setup & Configuration
- [ ] Install EF Core NuGet packages (`Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer` or `Microsoft.EntityFrameworkCore.Sqlite`)
- [ ] Add `app.config` with `connectionStrings` section
- [ ] Create `Data/AppDbContext.vb` with DbSet for each entity
- [ ] Enable EF Core migrations in the project

### 1.2 Define Models
- [ ] Create `Models/Product.vb` (Id, Code, Name, CategoryId, Price, StockQty, Barcode, CreatedAt)
- [ ] Create `Models/Category.vb` (Id, Name, Description)
- [ ] Create `Models/User.vb` (Id, Username, PasswordHash, Role, CreatedAt, IsActive)
- [ ] Create `Models/Sale.vb` (Id, ReceiptNo, UserId, TotalAmount, Discount, AmountPaid, Change, CreatedAt)
- [ ] Create `Models/SaleItem.vb` (Id, SaleId, ProductId, Qty, UnitPrice, Subtotal)
- [ ] Create `Models/StockMovement.vb` (Id, ProductId, Type, Qty, Reason, UserId, CreatedAt)

### 1.3 Migrations & Seed Data
- [ ] Generate initial EF Core migration (`Add-Migration InitialCreate`)
- [ ] Apply migration to create the database (`Update-Database`)
- [ ] Write seed data script to insert default categories, products, and admin user
- [ ] Verify all tables are created and seed data loads correctly

---

## Phase 2 — Authentication

### 2.1 Password & Session
- [ ] Add `BCrypt.Net-Next` NuGet package for password hashing
- [ ] Create `Services/UserService.vb` with `ValidateLogin(username, password)` method
- [ ] Hash the seeded admin user's password using BCrypt
- [ ] Create a `SessionContext` class (module-level) to hold the logged-in user across forms

### 2.2 Login Form
- [ ] Replace stub login in `LoginForm.vb` with a call to `UserService.ValidateLogin`
- [ ] Show error message on invalid credentials (do not specify which field is wrong)
- [ ] Lock out user after 5 consecutive failed attempts (show countdown or disable button)
- [ ] Store logged-in user in `SessionContext` on success
- [ ] Clear `SessionContext` on logout / application close

### 2.3 Role-Based Access
- [ ] Define roles: `Admin`, `Cashier`
- [ ] Hide or disable Setup module menu items for `Cashier` role on the dashboard
- [ ] Hide or disable Users form for non-Admin users

---

## Phase 3 — Business Logic Layer

### 3.1 Repositories (Data Access)
- [ ] Create `Repositories/ProductRepository.vb` (GetAll, GetByBarcode, GetById, Save, Delete)
- [ ] Create `Repositories/CategoryRepository.vb` (GetAll, Save, Delete)
- [ ] Create `Repositories/UserRepository.vb` (GetAll, GetByUsername, Save, Deactivate)
- [ ] Create `Repositories/SaleRepository.vb` (Save, GetById, GetByDateRange)
- [ ] Create `Repositories/StockMovementRepository.vb` (Save, GetByProduct, GetByDateRange)

### 3.2 Services (Business Logic)
- [ ] Create `Services/InventoryService.vb`
  - [ ] `GetAllProducts()` — returns list from DB
  - [ ] `GetLowStockProducts(threshold)` — returns items below threshold
  - [ ] `AdjustStock(productId, qty, type, reason)` — writes StockMovement + updates Product.StockQty
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
- [ ] Replace hardcoded sample list with `InventoryService.GetAllProducts()`
- [ ] Wire Add button to save new product via repository
- [ ] Wire Edit to update existing product
- [ ] Wire Delete to soft-delete or remove product
- [ ] Refresh DataGridView after each add/edit/delete

### 4.2 Categories Form
- [ ] Replace hardcoded list with DB query
- [ ] Wire Add / Edit / Delete to `CategoryRepository`
- [ ] Refresh grid after changes

### 4.3 Users Form
- [ ] Replace hardcoded list with DB query
- [ ] Wire Add to create user with hashed password
- [ ] Wire Edit to update user details (not password directly)
- [ ] Add "Reset Password" action (admin only)
- [ ] Wire Deactivate instead of hard delete

### 4.4 Sales / POS Form
- [ ] Replace hardcoded product dictionary with `ProductRepository.GetByBarcode()`
- [ ] On sale completion, call `SalesService.ProcessSale()` to persist transaction
- [ ] Deduct stock automatically via `InventoryService.AdjustStock()` on sale save
- [ ] Display generated receipt number on confirmation
- [ ] Block sale if product stock is 0 (show out-of-stock warning)

### 4.5 Stock In Form
- [ ] On submit, call `InventoryService.AdjustStock(productId, qty, "IN", reason)`
- [ ] Refresh product stock display after submission
- [ ] Validate qty > 0 before allowing submit

### 4.6 Stock Out Form
- [ ] On submit, call `InventoryService.AdjustStock(productId, qty, "OUT", reason)`
- [ ] Prevent stock out if qty > current stock (show error)
- [ ] Refresh product stock display after submission

### 4.7 Receipts Form
- [ ] Replace hardcoded receipts with `SalesService.GetSaleHistory()` query
- [ ] Allow filtering by date range
- [ ] Allow reprinting/viewing a specific receipt by clicking a row

### 4.8 Inventory Report Form
- [ ] Replace hardcoded data with `ReportService.GetInventorySummary()`
- [ ] Add date range picker controls
- [ ] Wire sales summary section to `ReportService.GetSalesSummary()`
- [ ] Wire top products section to `ReportService.GetTopSellingProducts()`

---

## Phase 5 — Error Handling & Validation

### 5.1 Global Error Handler
- [ ] Add global unhandled exception handler in `ApplicationEvents.vb` (`UnhandledException` event)
- [ ] Show user-friendly error dialog on crash instead of raw exception
- [ ] Log the full exception details to file (see Phase 6)

### 5.2 Form-Level Validation
- [ ] Products Form: required fields (Name, Code, Price), duplicate code check
- [ ] Categories Form: required Name, duplicate name check
- [ ] Users Form: required fields, username uniqueness check, password min length
- [ ] Sales Form: prevent checkout with empty cart
- [ ] Stock In/Out: qty must be numeric and > 0

### 5.3 Database Error Handling
- [ ] Wrap all repository calls in `Try/Catch`
- [ ] Show "Could not connect to database" message if connection fails on startup
- [ ] Handle unique constraint violations with descriptive messages (e.g., "Product code already exists")

---

## Phase 6 — Logging

- [ ] Install `Serilog` and `Serilog.Sinks.File` NuGet packages
- [ ] Initialize Serilog in `ApplicationEvents.vb` at app startup
- [ ] Configure daily rolling log file to `logs/saims-.log`
- [ ] Log application start and shutdown
- [ ] Log all login attempts (success and failure) with username and timestamp
- [ ] Log all unhandled exceptions via global handler
- [ ] Log all stock adjustments (who, what product, qty, reason)
- [ ] Log all completed sales (receipt number, total, user)

---

## Phase 7 — Housekeeping

- [ ] Delete `Form1.vb`, `Form1.Designer.vb`, and `Form1.resx` (dead code)
- [ ] Remove `Progress.md` from the project folder (use git commits for tracking instead)
- [ ] Add `.editorconfig` with VB.NET formatting rules (indent size, charset)
- [ ] Review and update `README.md` to reflect the real architecture after refactor
- [ ] Move existing `.md` docs (`BARCODE_TESTING_GUIDE.md`, `FEATURE_CHECKLIST.md`, etc.) into `docs/` folder

---

## Phase 8 — Tests

- [ ] Create a new VB.NET test project (`SAIMS.Tests`) using MSTest or xUnit
- [ ] Add project reference from test project to main project
- [ ] Write tests for `SalesService.GenerateReceiptNumber()` (format and uniqueness)
- [ ] Write tests for `SalesService.ProcessSale()` (total, discount, change calculation)
- [ ] Write tests for `InventoryService.AdjustStock()` (stock increases/decreases correctly)
- [ ] Write tests for `UserService.ValidateLogin()` (correct hash comparison, lockout)
- [ ] Write tests for stock-out prevention when qty > available stock

---

## Phase 9 — CI/CD

- [ ] Create `.github/workflows/` directory
- [ ] Create `build.yml` workflow:
  - [ ] Trigger on push to `master` and pull requests
  - [ ] Restore NuGet packages step
  - [ ] Build solution step (`dotnet build`)
  - [ ] Run tests step (`dotnet test`)
- [ ] Verify workflow runs green on first push

---

## Phase 10 — Reports Export (Nice to Have)

- [ ] Install `ClosedXML` NuGet package for Excel export
- [ ] Add "Export to Excel" button on Inventory Report form
- [ ] Export current report DataGridView contents to `.xlsx`
- [ ] Add "Print" button using `PrintDocument` or a report viewer

---

*Last updated: 2026-06-09*
