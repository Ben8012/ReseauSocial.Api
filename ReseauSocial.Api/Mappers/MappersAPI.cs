using API.Models;
using BLL.Models;
using ReseauSocial.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Mappers
{
    internal static class MappersAPI
    {
        internal static UserBll UserApiToUserBll(this RegisterUser entity)
        {
            return new UserBll()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                IsAdmin = entity.IsAdmin,
                Passwd = entity.Passwd,
            };
        }


        internal static LoginUserBll LoginUserBllToLoginUserDal(this LoginUser entity)
        {
            return new LoginUserBll()
            {
                Email = entity.Email,
                Passwd = entity.Passwd,
            };
        }

        internal static ArticleBll ArticleApiToArticleBll(this AddArticle entity)
        {
            return new ArticleBll()
            {
                Title = entity.Title,
                Content = entity.Content,
                UserId = entity.UserId,
                CommentOk = entity.CommentOk,
                OnLigne = entity.OnLigne             
            };
        }

        internal static MessageBll MessageApiToMessageBll(this AddMessage entity)
        {
            return new MessageBll()
            {
                Content = entity.Content,
                UserSend = entity.UserSend,
                UserGet = entity.UserGet

            };
        }


      

    }
}
