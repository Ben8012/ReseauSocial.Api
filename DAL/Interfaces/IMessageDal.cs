using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IMessageDal
    {
        int CreateMessage(MessageDal message);
        void DeleteMessage(MessageDal message);
        IEnumerable<MessageDal> GetMessageBetweenToUsers(int UserId1, int UserId2);
        MessageDal GetMessageById(int MessageId);
        IEnumerable<MessageDal> GetMessageFromUser(int UserSendId, int UserGetId);
        void ReciveMessage(int messageId, int UserGetId);
        void UpdateMessage(MessageDal message);
    }
}