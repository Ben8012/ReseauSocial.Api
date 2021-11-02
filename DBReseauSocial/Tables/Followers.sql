CREATE TABLE [dbo].[Followers]
(
	[Id] INT IDENTITY NOT NULL,
	[FollowedId] INT, -- celui qui est suivit
	[FollowerId] INT, -- celui qui suit
	[Date] DATETIME,
	CONSTRAINT [FK_Followers_UserId] FOREIGN KEY ([FollowedId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Followers_FollowerId] FOREIGN KEY ([FollowerId]) REFERENCES [Users]([Id]),
	CONSTRAINT [PK_Followers] PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_Followers_Followed] UNIQUE ([FollowedId], [FollowerId]),
)
