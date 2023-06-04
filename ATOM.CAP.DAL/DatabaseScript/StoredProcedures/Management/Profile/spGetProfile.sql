use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spGetProfile') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spGetProfile
GO

CREATE PROCEDURE dbo.spGetProfile
	@AID INT,
	@AUserID INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@UserID INT = COALESCE(@AUserID,0)

	SELECT [ID]
		  ,[UserID]
		  ,[Bio]
	FROM [pbl].[Profile]
	WHERE 
		(@ID < 1 OR ID = @ID)
	AND (@UserID < 1 OR UserID = @UserID)


END
GO