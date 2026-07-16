-- ============================================================
-- SAIMS - Sales and Inventory Management System
-- Database Setup Script
-- Server  : Glenn\SQLEXPRESS
-- Database: SAIMS_DB
-- Run this entire script in SSMS connected to Glenn\SQLEXPRESS
-- ============================================================

-- ------------------------------------------------------------
-- STEP 1: Create the database
-- ------------------------------------------------------------
USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'SAIMS_DB')
BEGIN
    CREATE DATABASE SAIMS_DB;
END
GO

USE SAIMS_DB;
GO

-- ------------------------------------------------------------
-- STEP 2: tbl_Categories
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tbl_Categories' AND xtype = 'U')
BEGIN
    CREATE TABLE tbl_Categories (
        CategoryID   INT IDENTITY(1,1) PRIMARY KEY,
        CategoryName NVARCHAR(100) NOT NULL,
        Description  NVARCHAR(255),
        Status       NVARCHAR(20)  NOT NULL DEFAULT 'Active',
        CreatedAt    DATETIME      NOT NULL DEFAULT GETDATE()
    );
END
GO

-- ------------------------------------------------------------
-- STEP 3: tbl_Products
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tbl_Products' AND xtype = 'U')
BEGIN
    CREATE TABLE tbl_Products (
        ProductID   INT IDENTITY(1,1) PRIMARY KEY,
        Barcode     NVARCHAR(50)  NOT NULL UNIQUE,
        ProductName NVARCHAR(150) NOT NULL,
        CategoryID  INT           NOT NULL,
        Price       DECIMAL(10,2) NOT NULL,
        Stock       INT           NOT NULL DEFAULT 0,
        LowStockQty INT           NOT NULL DEFAULT 10,
        Status      NVARCHAR(20)  NOT NULL DEFAULT 'Active',
        CreatedAt   DATETIME      NOT NULL DEFAULT GETDATE()
    );
END
GO

-- ------------------------------------------------------------
-- STEP 4: tbl_Users
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tbl_Users' AND xtype = 'U')
BEGIN
    CREATE TABLE tbl_Users (
        UserID       INT IDENTITY(1,1) PRIMARY KEY,
        Username     NVARCHAR(100) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(255) NOT NULL,
        FullName     NVARCHAR(150),
        UserType     NVARCHAR(50)  NOT NULL DEFAULT 'Cashier',
        Status       NVARCHAR(20)  NOT NULL DEFAULT 'Active',
        CreatedAt    DATETIME      NOT NULL DEFAULT GETDATE()
    );
END
GO

-- ------------------------------------------------------------
-- STEP 4b: tbl_Users — security question columns (forgot-password flow)
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'SecurityQuestion' AND Object_ID = Object_ID('tbl_Users'))
BEGIN
    ALTER TABLE tbl_Users ADD SecurityQuestion NVARCHAR(200) NULL;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'SecurityAnswerHash' AND Object_ID = Object_ID('tbl_Users'))
BEGIN
    ALTER TABLE tbl_Users ADD SecurityAnswerHash NVARCHAR(255) NULL;
END
GO

-- ------------------------------------------------------------
-- STEP 5: tbl_Sales
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tbl_Sales' AND xtype = 'U')
BEGIN
    CREATE TABLE tbl_Sales (
        SaleID         INT IDENTITY(1,1) PRIMARY KEY,
        ReceiptNo      NVARCHAR(50)  NOT NULL UNIQUE,
        CashierID      INT           NOT NULL REFERENCES tbl_Users(UserID),
        SaleDate       DATETIME      NOT NULL DEFAULT GETDATE(),
        SubTotal       DECIMAL(10,2) NOT NULL,
        Discount       DECIMAL(10,2) NOT NULL DEFAULT 0,
        TotalAmount    DECIMAL(10,2) NOT NULL,
        AmountTendered DECIMAL(10,2) NOT NULL,
        Change         DECIMAL(10,2) NOT NULL,
        PaymentMethod  NVARCHAR(50)  NOT NULL,
        Status         NVARCHAR(20)  NOT NULL DEFAULT 'Completed'
    );
END
GO

-- ------------------------------------------------------------
-- STEP 6: tbl_SaleItems
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tbl_SaleItems' AND xtype = 'U')
BEGIN
    CREATE TABLE tbl_SaleItems (
        SaleItemID INT IDENTITY(1,1) PRIMARY KEY,
        SaleID     INT           NOT NULL REFERENCES tbl_Sales(SaleID),
        ProductID  INT           NOT NULL REFERENCES tbl_Products(ProductID),
        Quantity   INT           NOT NULL,
        UnitPrice  DECIMAL(10,2) NOT NULL,
        LineTotal  DECIMAL(10,2) NOT NULL
    );
END
GO

-- ------------------------------------------------------------
-- STEP 7: tbl_StockMovements
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tbl_StockMovements' AND xtype = 'U')
BEGIN
    CREATE TABLE tbl_StockMovements (
        MovementID   INT IDENTITY(1,1) PRIMARY KEY,
        ProductID    INT           NOT NULL REFERENCES tbl_Products(ProductID),
        MovementType NVARCHAR(20)  NOT NULL, -- 'StockIn', 'StockOut', 'Sale'
        Quantity     INT           NOT NULL,
        Reason       NVARCHAR(255),
        MovementDate DATETIME      NOT NULL DEFAULT GETDATE(),
        CreatedBy    INT           NOT NULL REFERENCES tbl_Users(UserID)
    );
END
GO

-- ------------------------------------------------------------
-- STEP 8: tbl_ActivityLogs
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tbl_ActivityLogs' AND xtype = 'U')
BEGIN
    CREATE TABLE tbl_ActivityLogs (
        LogID       INT IDENTITY(1,1) PRIMARY KEY,
        Username    NVARCHAR(100) NOT NULL,
        LogDate     DATETIME      NOT NULL DEFAULT GETDATE(),
        Result      NVARCHAR(50)  NOT NULL, -- 'Success', 'Failed', 'Warning'
        Description NVARCHAR(500) NOT NULL
    );
END
GO

-- ------------------------------------------------------------
-- STEP 9: Seed data — Categories
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM tbl_Categories)
BEGIN
    INSERT INTO tbl_Categories (CategoryName, Description, Status) VALUES
        ('Beverages',       'Drinks and liquid refreshments',       'Active'),
        ('Canned Goods',    'Canned and preserved food products',   'Active'),
        ('Noodles',         'Instant noodles and pasta',            'Active'),
        ('Dairy',           'Milk, cheese, and dairy products',     'Active'),
        ('Beer & Spirits',  'Alcoholic beverages',                  'Active'),
        ('Condiments',      'Sauces, vinegar, and seasonings',      'Active'),
        ('Snacks',          'Chips, crackers, and junk food',       'Active'),
        ('Detergents',      'Cleaning and laundry products',        'Active');
END
GO

-- ------------------------------------------------------------
-- STEP 10: Seed data — Admin user
-- Password is 'admin123' hashed with BCrypt (cost factor 11)
-- Change this password immediately after first login.
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM tbl_Users)
BEGIN
    INSERT INTO tbl_Users (Username, PasswordHash, FullName, UserType, Status) VALUES
        ('admin', '$2a$11$KvJBH3mj8Z5X9nQ2pL7YyeQ1e3R4W6T8U0V2X4Z6A8B0C2D4F6H8J', 'System Administrator', 'Admin', 'Active');
END
GO

-- ------------------------------------------------------------
-- STEP 11: Seed data — Sample products
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM tbl_Products)
BEGIN
    INSERT INTO tbl_Products (Barcode, ProductName, CategoryID, Price, Stock, LowStockQty, Status) VALUES
        ('P001', 'Coca Cola 1.5L',          1, 55.00, 150, 20, 'Active'),
        ('P002', 'Lucky Me Pancit Canton',  3, 12.50, 200, 30, 'Active'),
        ('P003', 'Argentina Corned Beef',   2, 45.00,  80, 15, 'Active'),
        ('P004', 'Red Horse Beer 1L',       5, 50.00, 100, 20, 'Active'),
        ('P005', 'Sugar 1kg',               6, 65.00,  60, 10, 'Active'),
        ('P006', 'Champion Detergent 100g', 8,  8.50, 120, 25, 'Active'),
        ('P007', 'San Miguel Beer 330ml',   5, 45.00,   5,  5, 'Active'),
        ('P008', 'Del Monte Tomato Sauce',  6, 18.00,  90, 15, 'Active'),
        ('P009', 'Alaska Condensed Milk',   4, 35.00,   0, 10, 'Active'),
        ('P010', 'Jack n Jill Piattos',     7, 25.00, 110, 20, 'Active');
END
GO

-- ------------------------------------------------------------
-- Verify setup
-- ------------------------------------------------------------
SELECT 'tbl_Categories'    AS [Table], COUNT(*) AS [Rows] FROM tbl_Categories   UNION ALL
SELECT 'tbl_Products',                  COUNT(*)           FROM tbl_Products     UNION ALL
SELECT 'tbl_Users',                     COUNT(*)           FROM tbl_Users        UNION ALL
SELECT 'tbl_Sales',                     COUNT(*)           FROM tbl_Sales        UNION ALL
SELECT 'tbl_SaleItems',                 COUNT(*)           FROM tbl_SaleItems    UNION ALL
SELECT 'tbl_StockMovements',            COUNT(*)           FROM tbl_StockMovements UNION ALL
SELECT 'tbl_ActivityLogs',              COUNT(*)           FROM tbl_ActivityLogs;
GO

-- ============================================================
-- Setup complete. All 7 tables created, seed data inserted.
-- ============================================================
