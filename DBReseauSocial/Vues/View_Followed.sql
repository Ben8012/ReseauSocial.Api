CREATE VIEW [dbo].[View_Followed]
	AS 

		SELECT Users.[Id], LastName, FirstName, Email, IsAdmin, Followers.FollowerId
		FROM [Followers] 
		JOIN [Users] ON Users.Id = Followers.FollowedId

