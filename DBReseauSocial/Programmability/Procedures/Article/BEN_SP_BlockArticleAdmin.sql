CREATE PROCEDURE [dbo].[BEN_SP_BlockArticleAdmin]
	@ArticleId INT,
	@AdminId INT,
	@Message NVARCHAR(MAX)
	
AS
BEGIN

	IF(@AdminId IN (SELECT Id FROM Users WHERE IsAdmin = 1 ))

	BEGIN

		INSERT INTO [BlockArticle] (ArticleId, AdminId, [Message], [Date])
		VALUES 
		(@ArticleId, @AdminId, @Message, GETDATE())
	END

	RETURN 0;
END