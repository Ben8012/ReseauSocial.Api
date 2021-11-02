CREATE PROCEDURE [dbo].[BEN_SP_Follow]
	@FollowedId INT,
	@FollowerId INT
AS
BEGIN
	INSERT INTO [Followers] ([FollowedId], [FollowerId],[Date]) VALUES 
	(@FollowedId, @FollowerId, GETDATE());

	RETURN 0;
END


