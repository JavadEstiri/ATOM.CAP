use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spGetUsers') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spGetUsers
GO

CREATE PROCEDURE dbo.spGetUsers
	@AID INT,
	@APersonID INT,
	@AUserType INT,
	@AStatusType INT,
	@A_ri_UserID INT,
	@A_ri_UserType INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@PersonID INT = COALESCE(@APersonID,0),
		@UserType INT = COALESCE(@AUserType,0),
		@StatusType INT = COALESCE(@AStatusType , 0)

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
		WHERE RemoveDate IS NULL
		AND	(@ID < 1 OR ID = @ID)
		AND (@PersonID <1 OR PersonID = @PersonID)
		AND (@UserType < 1 OR UserType = @UserType)
		AND (@StatusType < 1 OR StatusType = @UserType)


END
GO