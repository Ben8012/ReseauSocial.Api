CREATE PROCEDURE [dbo].[BEN_SP_UnBlockArticleAdmin]
	@ArticleId INT,
	@AdminId INT

AS
BEGIN

	IF(@AdminId IN (SELECT Id FROM Users WHERE IsAdmin = 1 ))

	BEGIN

		DELETE FROM [BlockArticle] WHERE ArticleId = @ArticleId;
		
	END

	RETURN 0;
END
