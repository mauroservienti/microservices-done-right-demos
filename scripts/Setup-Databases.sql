USE [master]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'1-Marketing')
CREATE DATABASE [1-Marketing]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'1-Sales')
CREATE DATABASE [1-Sales]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'1-Warehouse')
CREATE DATABASE [1-Warehouse]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Marketing')
CREATE DATABASE [2-Marketing]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Sales')
CREATE DATABASE [2-Sales]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Warehouse')
CREATE DATABASE [2-Warehouse]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'2-Shipping')
CREATE DATABASE [2-Shipping]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Marketing')
CREATE DATABASE [3-Marketing]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Sales')
CREATE DATABASE [3-Sales]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Warehouse')
CREATE DATABASE [3-Warehouse]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'3-Shipping')
CREATE DATABASE [3-Shipping]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Marketing')
CREATE DATABASE [4-Marketing]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Sales')
CREATE DATABASE [4-Sales]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Warehouse')
CREATE DATABASE [4-Warehouse]
GO

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'4-Shipping')
CREATE DATABASE [4-Shipping]
GO