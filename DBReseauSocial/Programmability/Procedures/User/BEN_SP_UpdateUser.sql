CREATE PROCEDURE [dbo].[BEN_SP_UpdateUser]
	@Id INT,
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75)/*,
	@IsAdmin  NVARCHAR(75),
	@Email NVARCHAR(75),
	@Passwd NVARCHAR(20) */
AS
BEGIN
	UPDATE [Users] 
	SET [LastName] = @LastName, [FirstName] = @FirstName /*, [Email] = @Email, [IsAdmin] = @IsAdmin, Passwd =  dbo.BEN_SF_GetHashPasswd(@Passwd) */
	WHERE Id = @Id 
	RETURN 0
END
