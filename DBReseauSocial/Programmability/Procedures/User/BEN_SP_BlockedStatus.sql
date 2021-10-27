CREATE PROCEDURE [dbo].[BEN_SP_BlockedStatus]
	@ChangedUserId int,
	@EditorUserId int
	
AS
BEGIN

	DECLARE @CurrentStatus INT
	SELECT @CurrentStatus = [StatusId] 
	FROM [StatusChange] 
	WHERE [ChangedUserId] = @ChangedUserId AND [EndDate] IS NULL;

	IF( @CurrentStatus IN (1, 2, 5, 6)  )
	BEGIN

		UPDATE [StatusChange] SET [EndDate] = GETDATE() 
		WHERE [ChangedUserId] = @ChangedUserId AND [EndDate] IS NULL;

		INSERT INTO [StatusChange] ([EditorUserId], [ChangedUserId], [StatusId], [StartDate]) 
		VALUES ( @EditorUserId, @ChangedUserId, 3 , GETDATE())
	END

RETURN 0
END
