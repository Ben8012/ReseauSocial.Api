CREATE TABLE [dbo].[SignalArticle]
(
	[Id] INT IDENTITY NOT NULL ,
	[ArticleId] INT,
	[UserId] INT,
	[Date] DATETIME,
	CONSTRAINT [FK_SignalArticle_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_SignalArticle_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [Articles]([Id]),
	CONSTRAINT [PK_SignalArticle] PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_SignalArticle_ArticleId_UserId] UNIQUE ([ArticleId], [UserId]),
	
)
