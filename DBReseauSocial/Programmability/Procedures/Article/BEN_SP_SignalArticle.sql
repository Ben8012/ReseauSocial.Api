CREATE PROCEDURE [dbo].[BEN_SP_SignalArticle]
	@UserId INT,
	@ArticleId INT
	
AS
BEGIN

	IF(@UserId NOT IN (SELECT UserId FROM Articles WHERE Id = @ArticleId ))

	BEGIN

		INSERT INTO [SignalArticle] (UserId, ArticleId, [Date])
		VALUES 
		(@UserId, @ArticleId, GETDATE() );

	END

	RETURN 0;
END