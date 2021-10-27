CREATE PROCEDURE [dbo].[BEN_SP_UpdateArticle]
	@Id INT,
	@Title NVARCHAR(75),
	@Content NVARCHAR(MAX),
	@CommentOk BIT,
	@OnLigne BIT,
	@UserId INT
AS
BEGIN

	
	IF(@UserId IN (SELECT UserId FROM Articles WHERE Id = @Id ))

	BEGIN

	UPDATE  [Articles] 
	SET Title = @Title, Content = @Content, CommentOk = @CommentOk, OnLigne = @OnLigne, UserId = @UserId  
	WHERE Id = @Id 
	RETURN 0

	END
END
