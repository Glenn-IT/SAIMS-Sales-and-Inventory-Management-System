-- ============================================================
-- SAIMS - Drop the Products -> Categories foreign key
-- Run this once against any existing SAIMS_DB that still has the
-- CategoryID FK constraint on tbl_Products, so Categories can be
-- deleted even when Products reference them (presentation-only fix).
--
-- Safe to re-run: does nothing if the FK is already gone.
-- The constraint name is looked up dynamically because SQL Server
-- auto-generates it (e.g. FK__tbl_Produ__Categ__3C69FB99) and the
-- exact suffix can differ between machines/database instances.
-- ============================================================
USE SAIMS_DB;
GO

DECLARE @fkName NVARCHAR(128);

SELECT @fkName = fk.name
FROM sys.foreign_keys fk
JOIN sys.tables tp ON fk.parent_object_id = tp.object_id
JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
JOIN sys.columns c ON c.object_id = fkc.parent_object_id AND c.column_id = fkc.parent_column_id
WHERE tp.name = 'tbl_Products' AND c.name = 'CategoryID';

IF @fkName IS NOT NULL
BEGIN
    DECLARE @sql NVARCHAR(300) = N'ALTER TABLE tbl_Products DROP CONSTRAINT [' + @fkName + N']';
    EXEC sp_executesql @sql;
    PRINT 'Dropped constraint: ' + @fkName;
END
ELSE
BEGIN
    PRINT 'No FK constraint found on tbl_Products.CategoryID - nothing to do.';
END
GO
