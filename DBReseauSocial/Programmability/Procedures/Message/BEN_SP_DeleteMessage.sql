CREATE PROCEDURE [dbo].[BEN_SP_DeleteMessage]
	@Id INT,
	@UserSend INT

AS
BEGIN
	DELETE FROM [Messages]  
	WHERE Id = @Id AND UserSend = @UserSend AND RecieveDate IS NULL
	RETURN 0;
END