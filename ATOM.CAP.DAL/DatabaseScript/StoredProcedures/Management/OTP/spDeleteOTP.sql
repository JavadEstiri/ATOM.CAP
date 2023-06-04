use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spDeleteOTP') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spDeleteOTP
GO

CREATE PROCEDURE dbo.spDeleteOTP
	@AID INT,
	@AAccountID INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@AccountID INT = COALESCE(@AAccountID,0)

	DELETE 
	FROM pbl.OTP 
	WHERE (@ID < 1 OR ID = @ID)
	AND (@AccountID < 1 OR AccountID = @AAccountID)


END
GO