CREATE PROCEDURE [dbo].[BEN_SP_Status]
	@UserId INT

AS
BEGIN
	SELECT StatusAccount.Id AS Id ,[Name]  
	FROM StatusChange
	JOIN StatusAccount ON StatusAccount.Id = StatusChange.StatusId
	WHERE EndDate IS NULL AND [ChangedUserId] = @UserId

	
	RETURN 0
END