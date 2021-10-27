using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDal
    {
        void Insert(UserDal User);

        void Update(int id, UserDal user);

        void Delete(int id);

        void ReactivateStatus(int ChangedUserId);
        void DeactivateStatus(int ChangUserId);
        void BlockedStatus(int ChangedUserId, int EditorUserId);
        void DeleteStatus(int ChangedUserId, int EditorUserId);
        void AskActivateStatus(int ChangedUserId);
        void AskDeleteStatus(int ChangedUserId);
        bool EmailExists(string email);
        UserDal Login(LoginUserDal loginUser);

        StatusDal GetStatus(int userId);

        UserDal GetUser(int userId);

        IEnumerable<UserDal> GetAllUsers();
    }
}
