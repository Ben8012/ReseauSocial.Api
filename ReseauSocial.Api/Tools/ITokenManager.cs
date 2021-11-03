using BLL.Models;

namespace ReseauSocial.Api.Tools
{
    public interface ITokenManager
    {
        string GenerateJWTUser(UserBll client);
      
    }
}