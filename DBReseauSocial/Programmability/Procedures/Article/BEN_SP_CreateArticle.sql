CREATE PROCEDURE [dbo].[BEN_SP_CreateArticle]
	@Title NVARCHAR(75),
	@Content NVARCHAR(MAX),
	@CommentOk BIT = 1,
	@OnLigne BIT = 1,
	@UserId INT
AS
BEGIN
	INSERT INTO [Articles] (Title, Content, CommentOk, OnLigne, UserId, [Date])
	VALUES 
	(@Title, @Content, @CommentOk, @OnLigne, @UserId, GETDATE());

	RETURN 0;
END