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
	INSERT INTO [Articles] ( Title, Content, CommentOk, OnLigne, UserId )
	VALUES
	( CONCAT('Article', 4*@i+1), CONCAT('Content',4*@i+1),1 ,0 , 1),
	( CONCAT('Article', 4*@i+2), CONCAT('Content',4*@i+2),0 ,1 , 2),
	( CONCAT('Article', 4*@i+3), CONCAT('Content',4*@i+3),0 ,0 , 3),
	( CONCAT('Article', 4*@i+4), CONCAT('Content',4*@i+4),1 ,1 , 4)

	SET @i = @i + 1

END

/*MESSAGES*/

SET @i = 0
WHILE @i < 10 
BEGIN

	INSERT INTO [Messages] ( Content, UserSend, UserGet, SendDate)
	VALUES
	( CONCAT('test', 4*@i+1 ), 1 , 4 , GETDATE()),
	( CONCAT('test', 4*@i+2 ), 2 , 3 , GETDATE()),
	( CONCAT('test', 4*@i+3 ), 3 , 2 , GETDATE()),
	( CONCAT('test', 4*@i+4 ), 4 , 1 , GETDATE())
	SET @i = @i +1

END
