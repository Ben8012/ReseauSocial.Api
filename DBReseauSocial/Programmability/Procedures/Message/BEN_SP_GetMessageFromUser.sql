CREATE PROCEDURE [dbo].[BEN_SP_GetMessageFromUser]
	@UserSendId int,
	@UserGetId int
AS
BEGIN
	SELECT * FROM [Messages] 
	WHERE ([UserSend]= @UserSendId AND [UserGet] = @UserGetId) 
	RETURN 0
END
