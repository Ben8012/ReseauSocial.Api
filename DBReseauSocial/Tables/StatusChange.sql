CREATE TABLE [dbo].[StatusChange]
(
[Id] INT NOT NULL IDENTITY,
[EditorUserId] INT NOT NULL,
[ChangedUserId] INT NOT NULL,
[StatusId] INT NOT NULL,
[StartDate] DATETIME NOT NULL,
[EndDate] DATETIME NULL,
CONSTRAINT [PK_StatusChange] PRIMARY KEY ([Id]),
CONSTRAINT [FK_StatusChange_User_EditorUserId] FOREIGN KEY ([EditorUserId]) REFERENCES [Users]([Id]),
CONSTRAINT [FK_StatusChange_User_ChangedUserId] FOREIGN KEY ([ChangedUserId]) REFERENCES [Users]([Id]),
CONSTRAINT [FK_StatusChange_StatusAccount] FOREIGN KEY ([StatusId]) REFERENCES [StatusAccount]([Id])
)