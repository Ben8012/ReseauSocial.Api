CREATE PROCEDURE [dbo].[BEN_SP_Blacklist]
	@BlacklisterId INT,
	@BlacklistedId INT
AS
BEGIN
	-- supprimer le blacklister de la liste de mes suivis si il y est
	DELETE FROM [Followers] WHERE FollowedId = @BlacklistedId AND  FollowerId = @BlacklisterId 

	INSERT INTO [Blacklist] ([BlacklisterId],[BlacklistedId] ,[Date]) VALUES 
	(@BlacklisterId, @BlacklistedId, GETDATE());
	
	RETURN 0;
END
