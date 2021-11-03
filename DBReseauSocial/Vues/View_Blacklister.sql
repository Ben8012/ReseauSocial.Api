CREATE VIEW [dbo].[View_Blacklister]
	AS 

		SELECT Users.[Id], LastName, FirstName, Email, IsAdmin, Blacklist.BlacklistedId
		FROM [Blacklist] 
		JOIN [Users] ON Users.Id = Blacklist.BlacklisterId
