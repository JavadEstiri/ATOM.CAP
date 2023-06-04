use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spGetProfilekills') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spGetProfileSkills
GO

CREATE PROCEDURE dbo.spGetProfilekills
	@AProfileID INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ProfileID INT = COALESCE(@AProfileID, 0)

	SELECT [ID]
		  ,[ProfileID]
		  ,[SkillID]
	FROM [pbl].[UserSkills]
	WHERE ProfileID = @ProfileID


END
GO