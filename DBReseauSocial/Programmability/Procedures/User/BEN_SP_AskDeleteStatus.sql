CREATE PROCEDURE [dbo].[BEN_SP_AskDeleteStatus]
	@ChangedUserId int
	
AS
BEGIN
	
	DECLARE @CurrentStatus INT
	SELECT @CurrentStatus = [StatusId] 
	FROM [StatusChange] 
	WHERE [ChangedUserId] = @ChangedUserId AND [EndDate] IS NULL;

	IF( @CurrentStatus IN (1)  )
	BEGIN

		UPDATE [StatusChange] SET [EndDate] = GETDATE() 
		WHERE [ChangedUserId] = @ChangedUserId AND [EndDate] IS NULL;

		INSERT INTO [StatusChange] ([EditorUserId], [ChangedUserId], [StatusId], [StartDate]) 
		VALUES ( @ChangedUserId, @ChangedUserId, 5 , GETDATE())

	END 

RETURN 0
END


