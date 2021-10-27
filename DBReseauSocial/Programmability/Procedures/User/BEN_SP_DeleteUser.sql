CREATE PROCEDURE [dbo].[BEN_SP_DeleteUser]
	@Id int
AS
BEGIN
	Delete From [Users] Where Id = @Id
	RETURN 0
END
