using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IArticleBll
    {
        void BlockArticleAdmin(int articleId, int AdminId, string message);
        void CommentArticle(int articleId, int userId, string message);
        void Delete(int id);
        void Insert(ArticleBll article);
        void SignalArticle(int articleId, int userId);
        void Update(int id, ArticleBll article);

        IEnumerable<ArticleBll> GetAllArticle();

        IEnumerable<ArticleBll> GetArticleByUserId(int userId);

        ArticleBll GetArticleById(int articleId);

        bool IsArticleBlock(int articleId);


        bool IsSignalArticle(int articleId);


        void UnBlockArticleAdmin(int articleId, int AdminId);

        bool IsSignalByUser(int articleId, int UserId);

        void UnSignalArticle(int articleId, int UserId);

        void UnSignalArticleAdmin(int articleId, int UserId);

    }
}