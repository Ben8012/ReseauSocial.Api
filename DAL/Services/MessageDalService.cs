using ConnectionTool;
using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MessageDalService : IMessageDal
    {


        private readonly IConnection _connection;

        public MessageDalService(IConnection connection)
        {
            _connection = connection;
        }

        #region Récupération de messages
        //Récupérer tous les messages du serveurs
        public IEnumerable<MessageDal> GetAllMessages()
        {
            Command command = new Command("SELECT * FROM [Messages]", false);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal());
        }


        // Récupérer tous les messages d'un utilisateur dont l'id  est userId
        public IEnumerable<MessageDal> GetAllMessagesOfUser(int userId)
        {
            Command command = new Command("SELECT * FROM [Messages] WHERE UserSend = @UserId OR UserGet = @UserId", false);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal());
        }


        // Récupérer tous les messages échangés entre deux utilisateurs userId1 et userId2
        public IEnumerable<MessageDal> GetMessageBetweenToUsers(int userId1, int userId2)
        {
            Command command = new Command("BEN_SP_GetMessageBetweenToUsers", true);
            command.AddParameter("UserId1", userId1);
            command.AddParameter("UserId2", userId2);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal());
        }

        // Récupérer tous les messages envoyés par l'utilisateur userSendId à l'utilisateur userGetId
        public IEnumerable<MessageDal> GetMessageFromUser(int userSendId, int userGetId)
        {
            Command command = new Command("BEN_SP_GetMessageFromUser", true);
            command.AddParameter("UserSendId", userSendId);
            command.AddParameter("UserGetId", userGetId);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal());
        }

        // Récupérer un message par son Id
        public MessageDal GetMessageById(int messageId)
        {
            Command command = new Command("BEN_SP_GetMessageById", true);
            command.AddParameter("Id", messageId);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal()).SingleOrDefault();
        }

        #endregion

        #region Création /édition / suppression de message
        // Créer un message
        public int CreateMessage(MessageDal message)
        {
            Command command = new Command("BEN_SP_CreateMessage", true);
            command.AddParameter("Content", message.Content);
            command.AddParameter("UserSend", message.UserSend);
            command.AddParameter("UserGet", message.UserGet);

            return (int)_connection.ExecuteScalar(command);
        }


        // Mettre à jour un message
        public void UpdateMessage(MessageDal message)
        {
            Command command = new Command("BEN_SP_UpdateMessage", true);
            command.AddParameter("Content", message.Content);
            command.AddParameter("Id", message.Id);
            command.AddParameter("UserSend", message.UserSend);

            _connection.ExecuteNonQuery(command);
        }


        // Supprimer un message
        public void DeleteMessage(int messageId, int userSendId)
        {
            Command command = new Command("BEN_SP_DeleteMessage", true);
            command.AddParameter("Id", messageId);
            command.AddParameter("UserSend", userSendId);

            _connection.ExecuteNonQuery(command);
        }

        #endregion

        #region Réception (lecture) d'un message
        // Recevoir un message (en mettant à jour la date de réception)
        public void ReciveMessage(int messageId, int userGetId)
        {
            Command command = new Command("BEN_SP_ReciveMessage", true);
            command.AddParameter("UserGet", userGetId);
            command.AddParameter("Id", messageId);

            _connection.ExecuteNonQuery(command);
        }
        #endregion

    }
}
