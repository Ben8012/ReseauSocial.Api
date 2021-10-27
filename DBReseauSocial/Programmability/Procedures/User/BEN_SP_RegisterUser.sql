CREATE PROCEDURE [dbo].[BEN_SP_RegisterUser]
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75),
	@Email NVARCHAR(384),
	@IsAdmin BIT,
	@Passwd NVARCHAR(20)
AS
BEGIN
	INSERT INTO [Users] (LastName, FirstName, Email, IsAdmin, Passwd) VALUES 
	(@LastName, @FirstName, @Email, @IsAdmin, dbo.BEN_SF_GetHashPasswd(@Passwd));

	RETURN 0;
END
