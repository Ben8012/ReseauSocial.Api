using DAL.Models;

namespace DAL.Interfaces
{
    public interface IArticleDal
    {
        void BlockArticle(int articleId, int AdminId, string message);
        void CommentArticle(int articleId, int userId, string message);
        void Delete(int id);
        void Insert(ArticleDal article);
        void SignalArticle(int articleId, int userId);
        void Update(int id, ArticleDal article);

        
    }
}