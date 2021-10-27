CREATE TRIGGER [BEN_TR_InsertStatusOnRegister]

ON [dbo].[Users]

AFTER INSERT

AS

BEGIN

SET NOCOUNT ON

DECLARE @Id INT;

SELECT @Id = Id FROM inserted;

INSERT INTO [StatusChange] ([EditorUserId], [ChangedUserId], [StatusId], [StartDate], [EndDate])
	SELECT Id, Id, 1, GETDATE(), NULL
		FROM inserted;

END
