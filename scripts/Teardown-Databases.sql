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