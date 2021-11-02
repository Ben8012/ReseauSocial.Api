CREATE PROCEDURE [dbo].[BEN_SP_UnFollow]
	@FollowedId INT,
	@FollowerId INT
AS
BEGIN
	DELETE FROM [Followers] WHERE FollowedId = @FollowedId AND FollowerId = @FollowerId
	RETURN 0;
END
