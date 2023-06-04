use ATOM;
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spGetOTP') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spGetOTP
GO

CREATE PROCEDURE dbo.spGetOTP
	@AID INT,
	@AOTP NVARCHAR(65) NULL
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID,0),
		@OTP NVARCHAR(65) = @AOTP

	SELECT [ID]
		  ,[OTP]
		  ,[Expired]
		  ,[CreationDate]
		  ,[ValidityPeriodInMinutes]
	FROM [pbl].[OTP]
	WHERE (@ID < 1 OR ID = @ID)
	AND (OTP IS NULL OR (OTP = @OTP AND DATEDIFF(MINUTE,CreationDate,GETDATE()) < [ValidityPeriodInMinutes]))

END
GO