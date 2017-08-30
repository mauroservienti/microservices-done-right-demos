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