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

        public int CreateMessage(MessageDal message)
        {
            Command command = new Command("BEN_SP_CreateMessage", true);
            command.AddParameter("Content", message.Content);
            command.AddParameter("UserSend", message.UserSend);
            command.AddParameter("UserGet", message.UserGet);

            return (int)_connection.ExecuteScalar(command);
        }

        public void UpdateMessage(MessageDal message)
        {
            Command command = new Command("BEN_SP_UpdateMessage", true);
            command.AddParameter("Content", message.Content);
            command.AddParameter("Id", message.Id);
            command.AddParameter("UserSend", message.UserSend);

            _connection.ExecuteNonQuery(command);
        }

        public void DeleteMessage(MessageDal message)
        {
            Command command = new Command("BEN_SP_DeleteMessage", true);
            command.AddParameter("Id", message.Id);
            command.AddParameter("UserSend", message.UserSend);

            _connection.ExecuteNonQuery(command);
        }

        public void ReciveMessage(int messageId, int userGetId)
        {
            Command command = new Command("BEN_SP_ReciveMessage", true);
            command.AddParameter("UserGet", userGetId);
            command.AddParameter("Id", messageId);

            _connection.ExecuteNonQuery(command);
        }

        public MessageDal GetMessageById(int messageId)
        {
            Command command = new Command("BEN_SP_GetMessageById", true);
            command.AddParameter("Id", messageId);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal()).SingleOrDefault();
        }

        public IEnumerable<MessageDal> GetMessageBetweenToUsers(int userId1, int userId2)
        {
            Command command = new Command("BEN_SP_GetMessageBetweenToUsers", true);
            command.AddParameter("UserId1", userId1);
            command.AddParameter("UserId2", userId2);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal());
        }

        public IEnumerable<MessageDal> GetMessageFromUser(int userSendId, int userGetId)
        {
            Command command = new Command("BEN_SP_GetMessageFromUser", true);
            command.AddParameter("UserSendId", userSendId);
            command.AddParameter("UserGetId", userGetId);

            return _connection.ExecuteReader(command, m => m.DBToMessageDal());
        }

    }
}
