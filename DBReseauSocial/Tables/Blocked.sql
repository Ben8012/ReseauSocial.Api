CREATE TABLE [dbo].[Blocked]
(
	[Id] INT IDENTITY NOT NULL ,
	[ArticleId] INT,
	[AdminId] INT,
	[Message] NVARCHAR(MAX),
	[Date] DATETIME, 
    CONSTRAINT [FK_Blocked_Users] FOREIGN KEY ([AdminId]) REFERENCES [Users]([Id]),
	CONSTRAINT [PK_Blocked] PRIMARY KEY ([Id]),
)
