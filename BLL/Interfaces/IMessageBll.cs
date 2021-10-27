using BLL.Models;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IMessageBll
    {
        void CreateMessage(MessageBll message);
        void DeleteMessage(MessageBll message);
        IEnumerable<MessageBll> GetMessageBetweenToUsers(int UserId1, int UserId2);
        MessageBll GetMessageById(int MessageId);
        IEnumerable<MessageBll> GetMessageFromUser(int UserSendId, int UserGetId);
        void ReciveMessage(int messageId, int UserGetId);
        void UpdateMessage(MessageBll message);
    }
}