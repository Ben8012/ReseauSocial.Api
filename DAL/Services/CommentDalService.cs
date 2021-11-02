using ConnectionTool;
using DAL.Interfaces;
using DAL.Models;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CommentDalService : ICommentDal
    {
        private readonly IConnection _connection;

        public CommentDalService(IConnection connection)
        {
            _connection = connection;
        }

        public int AddComment(CommentDal entity)
        {
            Command command = new Command("BEN_SP_AddComment", true);
            command.AddParameter("Message", entity.Message);
            command.AddParameter("ArticleId", entity.ArticleId);
            command.AddParameter("UserId", entity.UserId);
            return (int)_connection.ExecuteScalar(command);
        }

        public int CountByArticleId(int id)
        {
            Command command = new Command("SELECT COUNT(*) FROM [CommentArticle] WHERE ArticleId = @Id", false);
            command.AddParameter("Id", id);
            return (int)_connection.ExecuteScalar(command);
        }

        public int CountByUserId(int id)
        {
            Command command = new Command("SELECT COUNT(*) FROM [CommentArticle] WHERE UserId = @Id", false);
            command.AddParameter("Id", id);
            return (int)_connection.ExecuteScalar(command);
        }

        public IEnumerable<CommentDal> GetAllComment()
        {
            Command command = new Command("SELECT * FROM [CommentArticle]", false);
         
            return _connection.ExecuteReader(command, dr => dr.DBToCommentDal());
        }

        public IEnumerable<CommentDal> GetByArticleId(int id)
        {
            Command command = new Command("SELECT * FROM [CommentArticle] WHERE ArticleId = @Id", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.DBToCommentDal());
        }

        public CommentDal GetById(int id)
        {
            Command command = new Command("SELECT * FROM [CommentArticle] WHERE Id = @Id", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.DBToCommentDal()).SingleOrDefault();
        }

        public IEnumerable<CommentDal> GetByUserId(int id)
        {
            Command command = new Command("SELECT * FROM [CommentArticle] WHERE UserId = @Id", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.DBToCommentDal());
        }
    }
}
