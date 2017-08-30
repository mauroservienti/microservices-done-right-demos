USE [master]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'1-Marketing')
DROP DATABASE [1-Marketing]
GO