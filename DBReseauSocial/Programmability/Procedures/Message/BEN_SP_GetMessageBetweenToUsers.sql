CREATE PROCEDURE [dbo].[BEN_SP_GetMessageBetweenToUsers]
	@UserId1 int,
	@UserId2 int
AS
BEGIN
	SELECT * FROM [Messages] 
	WHERE ([UserSend]= @UserId1 AND [UserGet] = @UserId2) OR  ([UserSend]= @UserId2 AND [UserGet] = @UserId1)
	RETURN 0
END