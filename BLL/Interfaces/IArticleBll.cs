using BLL.Models;

namespace BLL.Interfaces
{
    public interface IArticleBll
    {
        void BlockArticle(int articleId, int AdminId, string message);
        void CommentArticle(int articleId, int userId, string message);
        void Delete(int id);
        void Insert(ArticleBll article);
        void SignalArticle(int articleId, int userId);
        void Update(int id, ArticleBll article);

    }
}