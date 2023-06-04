use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spModifyAccount') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spModifyAccount
GO

CREATE PROCEDURE dbo.spModifyAccount
	@AID INT,
	@AUserName VARCHAR(11),
	@APassWord VARCHAR(200)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@UserName VARCHAR(11) = @AUserName,
		@PassWord VARCHAR(200) = @APassWord,
		@MAXID INT

	BEGIN TRY
		BEGIN TRAN
			IF @ID < 1 		 -- insert 
			BEGIN
				SET @MAXID = COALESCE((SELECT MAX(ID) FROM pbl.[Account]),0) +1
				INSERT INTO [pbl].[Account]
						   ([ID]
						   ,[UserName]
						   ,[Password]
						   ,[OTP]
						   ,[OTP_Expired]
						   ,[OTP_CreationDate]
						   ,[OTP_ValidityPeriodInMinutes])
					 VALUES
						   (@MAXID
						   ,@UserName
						   ,@PassWord
						   ,NULL
						   ,1
						   ,NULL
						   ,0)

				SET @ID = @MAXID

			END
			ELSE 			 -- update
			BEGIN
				
				UPDATE [pbl].[Account]
					SET [UserName] = @UserName ,[Password] = @PassWord
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