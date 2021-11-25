using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserBllService : IUserBll
    {
        private readonly IUserDal _userDal;

        public UserBllService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Insert(UserBll user)
        {
            _userDal.Insert(user.UserBllToUserDal());
        }

        public void Update(int id, UserBll user)
        {
            _userDal.Update(id, user.UserBllToUserDal());
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
        }

        public void ReactivateStatus(int ChangedUserId)
        {
            _userDal.ReactivateStatus( ChangedUserId);
        }

        public void DeactivateStatus(int ChangUserId)
        {
            _userDal.DeactivateStatus(ChangUserId);
        }

        public void BlockedStatusAdmin(int ChangedUserId, int EditorUserId)
        {
            _userDal.BlockedStatusAdmin(ChangedUserId, EditorUserId);
        }

        public void DeleteStatusAdmin(int ChangedUserId, int EditorUserId)
        {
            _userDal.DeleteStatusAdmin(ChangedUserId, EditorUserId);
        }

        public void AskActivateStatus(int ChangedUserId)
        {
            _userDal.AskActivateStatus( ChangedUserId);
        }

        public void AskDeleteStatus(int ChangedUserId)
        {
            _userDal.AskDeleteStatus( ChangedUserId);
        }

        public bool EmailExists(string email)
        {
           return _userDal.EmailExists( email);
        }

        public UserBll Login(LoginUserBll loginUser)
        {
            return _userDal.Login(loginUser.LoginUserBllToLoginUserDal()).DalUserToBllUser();
        }

        public StatusBll GetStatus(int userId)
        {
            return _userDal.GetStatus(userId).StatusDalToStatusBll();
        }

        public UserBll GetUser(int userId)
        {
            return _userDal.GetUser(userId).DalUserToBllUser();
        }

        public IEnumerable<UserBll> GetAllUsers()
        {
            return _userDal.GetAllUsers().Select(u => u.DalUserToBllUser());
        }

        public void UnBlockedStatusAdmin(int ChangedUserId, int EditorUserId)
        {

            _userDal.UnBlockedStatusAdmin(ChangedUserId, EditorUserId);
        }

        public void ReactivateStatusAdmin(int ChangedUserId, int EditorUserId)
        {
            _userDal.ReactivateStatusAdmin(ChangedUserId, EditorUserId);
        }
    }
}
