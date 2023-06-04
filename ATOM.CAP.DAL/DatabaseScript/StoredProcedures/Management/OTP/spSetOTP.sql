use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spSetOTP') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spSetOTP
GO

CREATE PROCEDURE dbo.spSetOTP
	@AAccountID INT,
	@AOTP VARCHAR(50),
	@AValidityPeriodTime INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@AccountID INT = COALESCE(@AAccountID,0),
		@OTP NVARCHAR(50) = @AOTP,
		@ValidityPeriodTime INT = COALESCE(@AValidityPeriodTime,2),
		@MAXID INT

	BEGIN TRY
		BEGIN TRAN
			
				SET @MAXID = COALESCE((SELECT MAX(ID) FROM pbl.[OTP]),0) +1
				INSERT INTO [pbl].[OTP]
						   ([ID]
						   ,[AccountID]
						   ,[OTP]
						   ,[Expired]
						   ,[CreationDate]
						   ,[ValidityPeriodInMinutes])
					 VALUES
						   (@MAXID
						   ,@AccountID
						   ,@OTP
						   ,0
						   ,GETDATE()
						   ,@ValidityPeriodTime)

		COMMIT

	END TRY
	BEGIN CATCH 
		ROLLBACK
		DECLARE @Error VARCHAR(MAX) = ERROR_MESSAGE()
		RAISERROR(@Error, 16, 1)
	END CATCH

	SELECT @MAXID

END
GO