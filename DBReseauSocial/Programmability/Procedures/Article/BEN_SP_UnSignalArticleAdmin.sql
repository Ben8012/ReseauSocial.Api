CREATE PROCEDURE [dbo].[BEN_SP_UnSignalArticleAdmin]
	@ArticleId INT,
	@UserId INT

AS
BEGIN
	IF(@UserId IN (SELECT Id FROM Users WHERE IsAdmin = 1 ))
	BEGIN

		DELETE FROM [SignalArticle] WHERE ArticleId = @ArticleId;	
	END

	RETURN 0;
END
