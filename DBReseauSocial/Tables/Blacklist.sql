CREATE TABLE [dbo].[Blacklist]
(
	[Id] INT IDENTITY NOT NULL,
	[BlacklisterId] INT, -- celui qui blacklist
	[BlacklistedId] INT, -- celui qui est blacklister
	[Date] DATETIME,
	CONSTRAINT [FK_Blacklist_UserId] FOREIGN KEY ([BlacklisterId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Blacklist_FollowerId] FOREIGN KEY ([BlacklistedId]) REFERENCES [Users]([Id]),
	CONSTRAINT [PK_Blacklist] PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_Blacklist] UNIQUE ([BlacklisterId], [BlacklistedId]),
)
