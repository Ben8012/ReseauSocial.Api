CREATE VIEW [dbo].[View_Followers]
		AS 

		SELECT Users.[Id], LastName, FirstName, Email, IsAdmin, Followers.FollowedId
		FROM [Followers] 
		JOIN [Users] ON Users.Id = Followers.FollowerId
