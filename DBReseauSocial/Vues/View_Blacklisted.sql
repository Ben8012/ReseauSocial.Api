CREATE VIEW [dbo].[View_Blacklisted]
		AS 

		SELECT Users.[Id], LastName, FirstName, Email, IsAdmin, Blacklist.BlacklisterId
		FROM [Blacklist] 
		JOIN [Users] ON Users.Id = Blacklist.BlacklistedId
