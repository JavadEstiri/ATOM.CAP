USE ATOM;  
GO  
-- Truncate the log by changing the database recovery model to SIMPLE.  
ALTER DATABASE ATOM
SET RECOVERY SIMPLE;  
GO  
-- Shrink the truncated log file to 1 MB.  
DBCC SHRINKFILE (ATOM_log, 1);  
GO  
-- Reset the database recovery model.  
ALTER DATABASE ATOM
SET RECOVERY FULL;  
GO 