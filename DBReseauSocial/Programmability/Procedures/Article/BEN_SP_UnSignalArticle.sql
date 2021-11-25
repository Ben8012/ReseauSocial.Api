CREATE PROCEDURE [dbo].[BEN_SP_UnSignalArticle]
	@ArticleId INT,
	@UserId INT

AS
BEGIN
		DELETE FROM [SignalArticle] WHERE ArticleId = @ArticleId AND UserId = @UserId;	

	RETURN 0;
END