use ATOM;

GO

-- Create Schemas

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'pbl')
BEGIN
	EXEC('CREATE SCHEMA [pbl]')
END

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'blg')
BEGIN
	EXEC('CREATE SCHEMA [blg]')
END

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'log')
BEGIN
	EXEC('CREATE SCHEMA [log]')
END
GO