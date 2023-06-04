use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spGetUser') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spGetUser
GO

CREATE PROCEDURE dbo.spGetUser
	@AID INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0)

	SELECT [ID]
			,[PersonID]
			,[UserType]
			,[StatusType]
			,[DisablerID]
			,[DisableDate]
			,[RemoverID]
			,[RemoveDate]
			,[StartDate]
			,[EnablerID]
		FROM [pbl].[User]
	WHERE ID = @ID


END
GO