CREATE VIEW [dbo].[View_Users]
	AS 

		SELECT [Id], LastName, FirstName, Email, IsAdmin
		FROM [Users] 