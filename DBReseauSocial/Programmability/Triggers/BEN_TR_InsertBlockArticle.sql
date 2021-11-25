CREATE TRIGGER [BEN_TR_InsertBlockArticle]

ON [dbo].[BlockArticle]

AFTER INSERT

AS

BEGIN

SET NOCOUNT ON

DELETE FROM [SignalArticle] WHERE ArticleId IN (SELECT ArticleId FROM inserted)
	
END
