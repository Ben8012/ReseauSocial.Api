CREATE PROCEDURE [dbo].[BEN_SP_ReciveMessage]
	@UserGet int,
	@Id int
AS
BEGIN
	UPDATE [Messages] SET [RecieveDate] = GETDATE()
	WHERE Id = @Id AND UserGet = @UserGet
END
