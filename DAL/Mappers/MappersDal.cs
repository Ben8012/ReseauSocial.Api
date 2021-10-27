using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class MappersDal
    {
        internal static UserDal DBToUserDal(this IDataRecord dataRecord)
        {
            return new UserDal()
            {
                Id = (int)dataRecord["Id"],
                LastName = dataRecord["LastName"].ToString(),
                FirstName = dataRecord["FirstName"].ToString(),
                IsAdmin = (bool)dataRecord["IsAdmin"],
                Email = dataRecord["Email"].ToString(),
            };
        }

        internal static StatusDal DBToStatusDal(this IDataRecord dataRecord)
        {
            return new StatusDal()
            {
                Id = (int)dataRecord["Id"],
                Name = dataRecord["Name"].ToString()
            };
        }

        #region Message

        internal static MessageDal DBToMessageDal(this IDataRecord dataRecord)
        {
            return new MessageDal()
            {
                Id = (int)dataRecord["Id"],
                Content = dataRecord["Content"].ToString(),
                UserSend = (int)dataRecord["UserSend"],
                UserGet = (int)dataRecord["UserGet"],
                RecieveDate = dataRecord["RecieveDate"] is DBNull?null:(DateTime?)dataRecord["RecieveDate"],
                SendDate = (DateTime)dataRecord["SendDate"],
            };
        }
        
        #endregion
    }
}
