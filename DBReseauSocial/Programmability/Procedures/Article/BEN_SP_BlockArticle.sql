CREATE PROCEDURE [dbo].[BEN_SP_BlockArticle]
	@ArticleId INT,
	@AdminId INT,
	@Message NVARCHAR(MAX)
	
AS
BEGIN

	IF(@AdminId IN (SELECT Id FROM Users WHERE IsAdmin = 1 ))

	BEGIN

		INSERT INTO [Blocked] (ArticleId, AdminId, [Message], [Date])
		VALUES 
		(@ArticleId, @AdminId, @Message, GETDATE())
	END

	RETURN 0;
END