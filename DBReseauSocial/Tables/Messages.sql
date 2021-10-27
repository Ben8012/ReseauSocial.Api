CREATE TABLE [dbo].[Messages]
(
	[Id] INT IDENTITY NOT NULL,
	[Content] NVARCHAR(MAX) NOT NULL,
	[UserSend] INT NOT NULL,
	[UserGet] INT NOT NULL,
	[RecieveDate] DATETIME NULL,
	[SendDate] DATETIME NOT NULL,
	CONSTRAINT [FK_Messages_UserSend] FOREIGN KEY ([UserGet]) REFERENCES [Users](Id),
	CONSTRAINT [FK_Message_UserGet] FOREIGN KEY ([UserSend]) REFERENCES [Users](Id),
	CONSTRAINT [PK_Messages] PRIMARY KEY ([Id])
)
