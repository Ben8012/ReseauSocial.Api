CREATE PROCEDURE [dbo].[BEN_SP_Follow]
	@FollowedId INT,
	@FollowerId INT
AS
BEGIN
	-- supprimer le followed de la Blackliste si il y est
	DELETE FROM [Blacklist] WHERE BlacklistedId = @FollowedId AND  BlacklisterId = @FollowerId

	INSERT INTO [Followers] ([FollowedId], [FollowerId],[Date]) VALUES 
	(@FollowedId, @FollowerId, GETDATE());

	RETURN 0;
END


