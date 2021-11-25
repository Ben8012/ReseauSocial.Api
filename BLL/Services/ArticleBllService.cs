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

        public void BlockArticleAdmin(int articleId, int AdminId, string message)
        {
            _articleDal.BlockArticleAdmin( articleId,  AdminId,  message);
        }

        public void CommentArticle(int articleId, int userId, string message)
        {
            _articleDal.CommentArticle( articleId, userId, message);
        }

        public IEnumerable<ArticleBll> GetAllArticle()
        {
            return _articleDal.GetAllArticle().Select(a => a.ArticleDalToArticleBll(_articleDal));
        }

        public IEnumerable<ArticleBll> GetArticleByUserId(int userId)
        {
            return _articleDal.GetArticleByUserId( userId).Select(a => a.ArticleDalToArticleBll(_articleDal));
        }

        public ArticleBll GetArticleById(int articleId)
        {
            return _articleDal.GetArticleById( articleId).ArticleDalToArticleBll(_articleDal);
        }

        public bool IsArticleBlock(int articleId)
        {
            return _articleDal.IsArticleBlock(articleId);
        }

        public bool IsSignalArticle(int articleId)
        {
            return _articleDal.IsSignalArticle( articleId);
        }

        public void UnBlockArticleAdmin(int articleId, int AdminId)
        {
            _articleDal.UnBlockArticleAdmin( articleId,  AdminId);
        }

        public bool IsSignalByUser(int articleId, int UserId)
        {
            return _articleDal.IsSignalByUser(articleId, UserId);
        }

        public void UnSignalArticle(int articleId, int UserId)
        {
             _articleDal.UnSignalArticle(articleId, UserId);
        }

        public void UnSignalArticleAdmin(int articleId, int UserId)
        {
            _articleDal.UnSignalArticleAdmin(articleId, UserId);
        }
    }
}
