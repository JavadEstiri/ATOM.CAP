use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spGetAccount') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spGetAccount
GO

CREATE PROCEDURE dbo.spGetAccount
	@AID INT,
	@AUserName NVARCHAR(11)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@UserName NVARCHAR(11) = @AUserName

	SELECT [ID]
		  ,[UserName]
		  ,[Password]
		  ,[OTP]
		  ,[OTP_Expired]
		  ,[OTP_CreationDate]
		  ,[OTP_ValidityPeriodInMinutes]
	FROM [pbl].[Account]
	WHERE (@ID < 1 OR ID = @ID )
	AND (@UserName IS NULL OR UserName = @UserName)


END
GO