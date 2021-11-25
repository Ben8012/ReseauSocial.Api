CREATE PROCEDURE [dbo].[BEN_SP_DeleteStatusAdmin]
	@ChangedUserId int,
	@EditorUserId int
	
AS
BEGIN

	DECLARE @CurrentStatus INT
	SELECT @CurrentStatus = [StatusId] 
	FROM [StatusChange] 
	WHERE [ChangedUserId] = @ChangedUserId AND [EndDate] IS NULL;

	IF( @CurrentStatus IN (5)  )
	BEGIN

		UPDATE [StatusChange] SET [EndDate] = GETDATE() 
		WHERE [ChangedUserId] = @ChangedUserId AND [EndDate] IS NULL;

		INSERT INTO [StatusChange] ([EditorUserId], [ChangedUserId], [StatusId], [StartDate], [EndDate] ) 
		VALUES ( @EditorUserId, @ChangedUserId, 4 , GETDATE(), NULL)

		UPDATE [Users] SET [LastName]= 'anonyme', [FirstName]= 'anonyme', [IsAdmin]= 0, [Passwd]= dbo.BEN_SF_GetHashPasswd(N'')
		WHERE [Id] = @ChangedUserId

	END

RETURN 0
END

