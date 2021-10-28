using ConnectionTool;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using DAL.Mappers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ArticleDalService : IArticleDal
    {

        private readonly IConnection _connection;
        public ArticleDalService(IConnection connection)
        {
            _connection = connection;
        }

        public void Insert(ArticleDal article)
        {

            Command command = new Command("BEN_SP_CreateArticle", true);
            command.AddParameter("Title", article.Title);
            command.AddParameter("Content", article.Content);
            command.AddParameter("CommentOk", article.CommentOk);
            command.AddParameter("OnLigne", article.OnLigne);
            command.AddParameter("UserId", article.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, ArticleDal article)
        {
            Command command = new Command("BEN_SP_UpdateArticle", true);
            command.AddParameter("Id", id);

            command.AddParameter("Title", article.Title);
            command.AddParameter("Content", article.Content);
            command.AddParameter("CommentOk", article.CommentOk);
            command.AddParameter("OnLigne", article.OnLigne);
            command.AddParameter("UserId", article.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("BEN_SP_DeleteArticle", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

        public void SignalArticle(int articleId, int userId)
        {
            Command command = new Command("BEN_SP_SignalArticle", true);
            command.AddParameter("ArticleId", articleId);
            command.AddParameter("UserId", userId);

            _connection.ExecuteNonQuery(command);
        }

        public void BlockArticle(int articleId, int AdminId, string message)
        {
            Command command = new Command("BEN_SP_BlockArticle", true);
            command.AddParameter("ArticleId", articleId);
            command.AddParameter("AdminId", AdminId);
            command.AddParameter("Message", message);

            _connection.ExecuteNonQuery(command);
        }

        public void CommentArticle(int articleId, int userId, string message)
        {
            Command command = new Command("BEN_SP_CommentArticle", true);
            command.AddParameter("ArticleId", articleId);
            command.AddParameter("UserId", userId);
            command.AddParameter("Message", message);

            _connection.ExecuteNonQuery(command);
        }

        public IEnumerable<ArticleDal> GetAllArticle()
        {
            Command command = new Command("SELECT * FROM [Articles]", false);
            return _connection.ExecuteReader(command,DR => DR.DBToArticleDal());
        }

        public IEnumerable<ArticleDal> GetArticleByUserId(int userId)
        {

            Command command = new Command("SELECT * FROM [Articles] WHERE UserId = @UserId", false);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, DR => DR.DBToArticleDal());
        }

        public ArticleDal GetArticleById(int articleId)
        {

            Command command = new Command("SELECT * FROM [Articles] WHERE Id = @Id", false);
            command.AddParameter("Id", articleId);

            return _connection.ExecuteReader(command, DR => DR.DBToArticleDal()).SingleOrDefault();
        }
    }
}
