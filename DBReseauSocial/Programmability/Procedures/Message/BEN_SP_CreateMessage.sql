CREATE PROCEDURE [dbo].[BEN_SP_CreateMessage]
	@Content NVARCHAR(Max),
	@UserSend INT,
	@UserGet INT
	
AS
BEGIN
	INSERT INTO [Messages] (Content, UserSend, UserGet, SendDate) VALUES 
	(@Content, @UserSend, @UserGet, GETDATE());

	RETURN 0;
END