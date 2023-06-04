use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spModifyProfile') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spModifyProfile
GO

CREATE PROCEDURE dbo.spModifyProfile
	@AID INT,
	@AUserID INT,
	@ABio NVARCHAR(3000),
	@ASkills NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@UserID INT = COALESCE(@AUserID, 0),
		@Bio INT = @ABio,
		@Skills NVARCHAR(MAX) = @ASkills,
		@MAXID INT

	BEGIN TRY
		BEGIN TRAN
			IF @ID < 1 		 -- insert 
			BEGIN
				SET @MAXID = COALESCE((SELECT MAX(ID) FROM pbl.[Profile]),0) +1
				INSERT INTO [pbl].[Profile]
					   ([ID]
					   ,[UserID]
					   ,[Bio])
				 VALUES
					   (@MAXID
					   ,@UserID
					   ,@Bio)

				SET @ID = @MAXID

			END
			ELSE 			 -- update
			BEGIN
				UPDATE [pbl].[Profile] SET [Bio] = @Bio WHERE ID = @ID
			END

			-- Update Skills
			DELETE FROM [pbl].[UserSkills] WHERE ProfileID = @ID
			SET @MAXID = COALESCE((SELECT MAX(ID) FROM [pbl].[UserSkills] ), 0)

			INSERT INTO [pbl].[UserSkills]
			([ID], [ProfileID], [SkillID])
			SELECT 
				@MaxID + ROW_NUMBER() OVER (ORDER BY Skills.SkillID) ID, 
				@ID ProfileID, 
				SkillID
			FROM OPENJSON(@Skills) 
			WITH(
				SkillID INT
			) Skills 

		COMMIT
	END TRY
	BEGIN CATCH 
		ROLLBACK
		DECLARE @Error VARCHAR(MAX) = ERROR_MESSAGE()
		RAISERROR(@Error, 16, 1)
	END CATCH

	SELECT @ID

END
GO