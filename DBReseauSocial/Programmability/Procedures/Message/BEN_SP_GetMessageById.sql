CREATE PROCEDURE [dbo].[BEN_SP_GetMessageById]
	@Id int
	
AS
BEGIN
	SELECT *  FROM [Messages] WHERE Id = @Id;
	RETURN 0
END
