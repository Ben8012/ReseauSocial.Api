CREATE TABLE [dbo].[Articles]
(
	[Id] INT IDENTITY NOT NULL,
	[Title] NVARCHAR(75),
	[Content] NVARCHAR(MAX),
	[CommentOk] BIT,
	[OnLigne] BIT,
	[UserId] INT, 
	CONSTRAINT [FK_Articles_Users] FOREIGN KEY (UserId) REFERENCES [Users](Id),
	CONSTRAINT [PK_Articles] PRIMARY KEY ([Id]),

)