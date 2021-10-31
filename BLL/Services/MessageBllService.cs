using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Services
{
    public class MessageBllService : IMessageBll
    {
        private readonly IMessageDal _messageDal;

        public MessageBllService(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public int CreateMessage(MessageBll message)
        {
           return _messageDal.CreateMessage(message.MessageBllToMessageDal());
        }

        public void DeleteMessage(MessageBll message)
        {
            _messageDal.DeleteMessage( message.MessageBllToMessageDal());
        }

        public IEnumerable<MessageBll> GetMessageBetweenToUsers(int userId1, int userId2)
        {
            return _messageDal.GetMessageBetweenToUsers( userId1, userId2).Select(m =>m.MessageDalToMessageBll());
        }

        public MessageBll GetMessageById(int messageId)
        {
            return _messageDal.GetMessageById(messageId).MessageDalToMessageBll();
        }

        public IEnumerable<MessageBll> GetMessageFromUser(int userSendId, int userGetId)
        {
            return _messageDal.GetMessageFromUser(userSendId, userGetId).Select(m => m.MessageDalToMessageBll());

        }

        public void ReciveMessage(int messageId, int userGetId)
        {
            _messageDal.ReciveMessage(messageId, userGetId);
        }

        public void UpdateMessage(MessageBll message)
        {
            _messageDal.UpdateMessage(message.MessageBllToMessageDal());
        }
    }
}
