CREATE PROCEDURE [dbo].[BEN_SP_AddComment]
@Message VARCHAR(MAX),
@ArticleId INT,
@UserId INT
AS
BEGIN
INSERT INTO [CommentArticle] ([Message], [ArticleId], [UserId], [Date]) VALUES
(@Message, @ArticleId, @UserId, GETDATE());
-- Sélectionner l'id de la ligne enregietrée
SELECT CONVERT(INT, @@IDENTITY)
RETURN 0;
END