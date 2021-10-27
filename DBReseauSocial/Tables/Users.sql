CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY NOT NULL,
	[FirstName] NVARCHAR(75),
	[LastName] NVARCHAR(75),
	[IsAdmin] BIT,
	[Email] NVARCHAR(384) UNIQUE,
	[Passwd] BINARY(64), 
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),

)
