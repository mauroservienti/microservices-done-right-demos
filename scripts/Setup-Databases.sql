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