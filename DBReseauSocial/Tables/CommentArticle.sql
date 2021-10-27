CREATE TABLE [dbo].[CommentArticle]
(
	[Id] INT IDENTITY NOT NULL,
	[ArticleId] INT,
	[UserId] INT,
	[Message] NVARCHAR(MAX),
	[Date] DATETIME,
	CONSTRAINT [FK_CommentArticle_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_CommentArticle_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [Articles]([Id]),
	CONSTRAINT [PK_CommentArticle] PRIMARY KEY ([Id]),
)
