use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spDeleteProfile') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spDeleteProfile
GO

CREATE PROCEDURE dbo.spDeleteProfile
	@AUserID INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@UserID INT = COALESCE(@AUserID, 0)

	DELETE FROM pbl.[Profile] WHERE UserID = @UserID


END
GO