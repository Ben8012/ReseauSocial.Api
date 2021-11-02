/* STATUS*/

SET IDENTITY_INSERT [StatusAccount] ON;
INSERT INTO [StatusAccount] (Id, [Name]) 
VALUES

(1, 'Activer'),
(2, 'Déactiver'),
(3, 'Bloqué'),
(4, 'Supprimé'), 
(5, 'Demande de suppression'), 
(6, 'Demande de réactivation');

SET IDENTITY_INSERT [StatusAccount] OFF;

 /* USERS*/

DECLARE 
	@i INT = 0

WHILE @i < 10  
BEGIN
	INSERT INTO  [Users] ([LastName], [FirstName],[Email],[IsAdmin],[Passwd] )
	VALUES
	( CONCAT('LastName', 2*@i+1), CONCAT('FirstName', 2*@i+1), CONCAT('test', 2*@i+1 , '@mail.com'), 0 , dbo.BEN_SF_GetHashPasswd('test1234=')),

	( CONCAT('LastName', 2*@i+2), CONCAT('FirstName', 2*@i+2), CONCAT('test', 2*@i+2 , '@mail.com'), 1 , dbo.BEN_SF_GetHashPasswd('test1234='))
	SET @i = @i +1

END


/*ARTICLES*/


SET	@i = 0

WHILE @i < 10 
BEGIN
	INSERT INTO [Articles] ( Title, Content, CommentOk, OnLigne, UserId, [Date] )
	VALUES
	( CONCAT('Article', 4*@i+1), CONCAT('Content',4*@i+1),1 ,0 , 1,GETDATE()),
	( CONCAT('Article', 4*@i+2), CONCAT('Content',4*@i+2),0 ,1 , 2,GETDATE()),
	( CONCAT('Article', 4*@i+3), CONCAT('Content',4*@i+3),0 ,0 , 3,GETDATE()),
	( CONCAT('Article', 4*@i+4), CONCAT('Content',4*@i+4),1 ,1 , 4,GETDATE())

	SET @i = @i + 1

END

/*MESSAGES*/

SET @i = 0
WHILE @i < 5 
BEGIN

	INSERT INTO [Messages] ( Content, UserSend, UserGet, SendDate)
	VALUES
	( CONCAT('test', 12*@i+1 ), 1 , 2 , GETDATE()),
	( CONCAT('test', 12*@i+2 ), 1 , 3 , GETDATE()),
	( CONCAT('test', 12*@i+3 ), 1 , 4 , GETDATE()),
	( CONCAT('test', 12*@i+4 ), 2 , 1 , GETDATE()),
	( CONCAT('test', 12*@i+5 ), 2 , 3 , GETDATE()),
	( CONCAT('test', 12*@i+6 ), 2 , 4 , GETDATE()),
	( CONCAT('test', 12*@i+7 ), 3 , 1 , GETDATE()),
	( CONCAT('test', 12*@i+8 ), 3 , 2 , GETDATE()),
	( CONCAT('test', 12*@i+9 ), 3 , 4 , GETDATE()),
	( CONCAT('test', 12*@i+10 ), 4 , 1 , GETDATE()),
	( CONCAT('test', 12*@i+11 ), 4 , 2 , GETDATE()),
	( CONCAT('test', 12*@i+12 ), 4 , 3 , GETDATE())
	SET @i = @i +1

END

/*FOLLOWERS*/


SET @i = 0
WHILE @i < 5 
BEGIN

	INSERT INTO [Followers] ( [FollowedId],[FollowerId], [Date])
	VALUES
	( @i+1 , @i+2,GETDATE()),
	( @i+1 , @i+3,GETDATE()),
	( @i+1 , @i+4,GETDATE())

	SET @i = @i +1

END

	