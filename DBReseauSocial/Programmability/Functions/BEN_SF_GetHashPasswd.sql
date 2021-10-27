CREATE FUNCTION [dbo].[BEN_SF_GetHashPasswd]
(
	@Passwd NVARCHAR(20) 

)
RETURNS BINARY(64)
AS
BEGIN
	RETURN  HASHBYTES('SHA2_512', dbo.BEN_SF_GetPreSalt() + @Passwd + dbo.BEN_SF_GetPostSalt() )
END
