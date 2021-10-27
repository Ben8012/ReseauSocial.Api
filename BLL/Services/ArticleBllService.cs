using BLL.Interfaces;
using BLL.Models;
using ConnectionTool;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;

namespace BLL.Services
{
    public class ArticleBllService : IArticleBll
    {

        private readonly IArticleDal _articleDal;

        public ArticleBllService(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void Insert(ArticleBll article)
        {
            _articleDal.Insert(article.ArticleBllToArticleDal());
        }

        public void Update(int id, ArticleBll article)
        {
            _articleDal.Update(id, article.ArticleBllToArticleDal());
        }

        public void Delete(int id)
        {
            _articleDal.Delete(id);
        }

        public void SignalArticle(int articleId, int userId)
        {
            _articleDal.SignalArticle(articleId, userId);
        }

        public void BlockArticle(int articleId, int AdminId, string message)
        {
            _articleDal.BlockArticle( articleId,  AdminId,  message);
        }

        public void CommentArticle(int articleId, int userId, string message)
        {
            _articleDal.CommentArticle( articleId, userId, message);
        }

    }
}
