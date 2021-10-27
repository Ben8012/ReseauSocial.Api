CREATE TABLE [dbo].[StatusAccount]

(

[Id] INT NOT NULL IDENTITY,

[Name] VARCHAR(50) NOT NULL,

CONSTRAINT [PK_StatusAccount] PRIMARY KEY ([Id]),

CONSTRAINT [AK_StatusAccount_Name] UNIQUE ([Name])

)