use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spDeleteUser') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spDeleteUser
GO

CREATE PROCEDURE dbo.spDeleteUser
	@AID INT,
	@A_ri_UserID INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0),
		@ri_UserID INT = COALESCE(@A_ri_UserID,0)

	UPDATE [pbl].[User]
	   SET [StatusType] = 3
		  ,[RemoverID] = @ri_UserID
		  ,[RemoveDate] = GETDATE()
	 WHERE ID = @ID


END
GO