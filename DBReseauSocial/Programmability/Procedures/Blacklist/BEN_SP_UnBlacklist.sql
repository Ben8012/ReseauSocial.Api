CREATE PROCEDURE [dbo].[BEN_SP_UnBlacklist]
	@BlacklisterId INT,
	@BlacklistedId INT
AS
BEGIN
	DELETE FROM [Blacklist] WHERE BlacklisterId = @BlacklisterId AND BlacklistedId = @BlacklistedId
	RETURN 0;
END

