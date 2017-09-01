USE [master]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'1-Marketing')
DROP DATABASE [1-Marketing]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'1-Sales')
DROP DATABASE [1-Sales]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'1-Warehouse')
DROP DATABASE [1-Warehouse]
GO


IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Marketing')
DROP DATABASE [2-Marketing]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Sales')
DROP DATABASE [2-Sales]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Warehouse')
DROP DATABASE [2-Warehouse]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Shipping')
DROP DATABASE [2-Shipping]
GO


IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Marketing')
DROP DATABASE [3-Marketing]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Sales')
DROP DATABASE [3-Sales]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Warehouse')
DROP DATABASE [3-Warehouse]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Shipping')
DROP DATABASE [3-Shipping]
GO


IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Marketing')
DROP DATABASE [4-Marketing]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Sales')
DROP DATABASE [4-Sales]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Warehouse')
DROP DATABASE [4-Warehouse]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Shipping')
DROP DATABASE [4-Shipping]
GO


IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'5-Marketing')
DROP DATABASE [5-Marketing]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'5-Sales')
DROP DATABASE [5-Sales]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'5-Warehouse')
DROP DATABASE [5-Warehouse]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'5-Shipping')
DROP DATABASE [5-Shipping]
GO