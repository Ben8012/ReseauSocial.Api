using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBll
    {
        
        void Insert(UserBll User);

        void Update(int id, UserBll user);

        void Delete(int id);

        void ReactivateStatus(int ChangedUserId);
        void DeactivateStatus(int ChangUserId);
        void BlockedStatusAdmin(int ChangedUserId, int EditorUserId);
        void DeleteStatusAdmin(int ChangedUserId, int EditorUserId);

        void UnBlockedStatusAdmin(int ChangedUserId, int EditorUserId);


        void ReactivateStatusAdmin(int ChangedUserId, int EditorUserId);
      

        void AskActivateStatus(int ChangedUserId);
        void AskDeleteStatus(int ChangedUserId);
        bool EmailExists(string email);
        UserBll Login(LoginUserBll loginUser);

        StatusBll GetStatus(int userId);

        UserBll GetUser(int userId);

        IEnumerable<UserBll> GetAllUsers();
    }
}
