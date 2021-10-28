CREATE PROCEDURE [dbo].[BEN_SP_DeleteArticle]
	@Id int
AS
BEGIN

	Delete From [Articles] Where Id = @Id

	RETURN 0

END
