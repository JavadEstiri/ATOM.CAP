use ATOM;
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spDeleteAccount') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spDeleteAccount
GO

CREATE PROCEDURE dbo.spDeleteAccount
	@AID INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID INT = COALESCE(@AID, 0)

	DELETE FROM pbl.Account WHERE ID = @ID


END
GO