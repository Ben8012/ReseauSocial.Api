using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IArticleDal
    {
        void BlockArticleAdmin(int articleId, int AdminId, string message);
        void CommentArticle(int articleId, int userId, string message);
        void Delete(int id);
        void Insert(ArticleDal article);
        void SignalArticle(int articleId, int userId);
        void Update(int id, ArticleDal article);

        IEnumerable<ArticleDal> GetAllArticle();

        IEnumerable<ArticleDal> GetArticleByUserId(int userId);

        ArticleDal GetArticleById(int articleId);

        bool IsArticleBlock(int articleId);


        bool IsSignalArticle(int articleId);


        void UnBlockArticleAdmin(int articleId, int AdminId);

        bool IsSignalByUser(int articleId, int UserId);

        void UnSignalArticle(int articleId, int UserId);

        void UnSignalArticleAdmin(int articleId, int UserId);



    }
}