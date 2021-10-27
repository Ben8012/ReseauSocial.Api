CREATE PROCEDURE [dbo].[BEN_SP_CommentArticle]
	@ArticleId INT,
	@UserId INT,
	@Message NVARCHAR(MAX)
	
AS
BEGIN
	INSERT INTO [CommentArticle] (ArticleId, UserId, [Message], [Date])
	VALUES 
	(@ArticleId,@UserId, @Message, GETDATE());

	RETURN 0;
END


