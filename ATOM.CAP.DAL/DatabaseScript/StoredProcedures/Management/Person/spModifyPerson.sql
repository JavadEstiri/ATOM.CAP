use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spModifyUser') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spModifyUser
GO

CREATE PROCEDURE dbo.spModifyUser
	@AID INT,
	@APersonID INT,
	@AStatusType INT,
	@AUserType INT,
	@ADisableDate SMALLDATETIME = NULL,
	@ADisablerID INT = 0,
	@ACode varchar(20) = NULL,
	@AStartDate SMALLDATETIME = NULL,
	@AEnablerID INT = 0,
	@ARemoverID INT = 0,
	@ARemoveDate SMALLDATETIME = NULL
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@PersonID INT = COALESCE(@APersonID, 0),
		@UserType INT = @AUserType,
		@StatusType VARCHAR(100) = @AStatusType,
		@DisableDate SMALLDATETIME = @ADisableDate,
		@DisablerID INT = @ADisablerID,
		@Code varchar(20) = @ACode,
		@StartDate SMALLDATETIME = @AStartDate,
		@RemoverID INT = @ARemoverID,
		@RemoveDate SMALLDATETIME = @ARemoveDate,
		@MAXID INT,
		@EnablerID INT = COALESCE(@AEnablerID, 0)

	BEGIN TRY
		BEGIN TRAN
			IF @ID < 1 		 -- insert 
			BEGIN
				SET @MAXID = COALESCE((SELECT MAX(ID) FROM pbl.[User]),0) +1
				INSERT INTO [pbl].[User]
					   ([ID]
					   ,[PersonID]
					   ,[UserType]
					   ,[StatusType]
					   ,[DisablerID]
					   ,[DisableDate]
					   ,[RemoverID]
					   ,[RemoveDate]
					   ,[StartDate]
					   ,[EnablerID])
				 VALUES
					   (@MAXID
					   ,@PersonID
					   ,@UserType
					   ,@StatusType
					   ,@DisablerID
					   ,@DisableDate
					   ,@RemoverID
					   ,@RemoveDate
					   ,GETDATE()
					   ,@EnablerID)

				SET @ID = @MAXID

			END
			ELSE 			 -- update
			BEGIN
				
				UPDATE [pbl].[User]
				   SET [UserType] = @UserType
					  ,[StatusType] = @StatusType
					  ,[DisablerID] = @DisablerID
					  ,[DisableDate] = @DisableDate
					  ,[RemoverID] = @RemoverID
					  ,[RemoveDate] = @RemoveDate
					  ,[EnablerID] = @EnablerID
				 WHERE ID = @ID

			END
	
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