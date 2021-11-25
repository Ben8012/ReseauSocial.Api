CREATE TABLE [dbo].BlockArticle
(
	[Id] INT IDENTITY NOT NULL ,
	[ArticleId] INT,
	[AdminId] INT,
	[Message] NVARCHAR(MAX),
	[Date] DATETIME, 
    CONSTRAINT [FK_BlockArticle_Users] FOREIGN KEY ([AdminId]) REFERENCES [Users]([Id]),
	CONSTRAINT [PK_BlockArticle] PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_BlockArticle_ArticleId_AdminId] UNIQUE ([AdminId], [ArticleId]),
)
