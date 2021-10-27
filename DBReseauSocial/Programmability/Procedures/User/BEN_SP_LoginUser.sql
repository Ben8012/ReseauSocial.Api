CREATE PROCEDURE [dbo].[BEN_SP_LoginUser]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [Id], LastName, FirstName, Email, IsAdmin
	FROM [Users] 
	WHERE Email = @Email
	AND Passwd = dbo.BEN_SF_GetHashPasswd(@Passwd);
	RETURN 0;
END

