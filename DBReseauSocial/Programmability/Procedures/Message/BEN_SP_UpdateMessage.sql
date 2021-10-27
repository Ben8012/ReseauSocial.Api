CREATE PROCEDURE [dbo].[BEN_SP_UpdateMessage]
	@Content NVARCHAR(Max),
	@Id INT,
	@UserSend INT
	
AS
BEGIN
	Update [Messages] SET Content = @Content 
	WHERE Id = @Id AND UserSend = @UserSend AND RecieveDate IS NULL
	RETURN 0;
END