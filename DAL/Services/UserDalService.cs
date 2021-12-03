using ConnectionTool;
using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cryptography.Hash;

namespace DAL.Services
{
    public class UserDalService : IUserDal
    {

        private readonly IConnection _connection;
        public UserDalService(IConnection connection)
        {
            _connection = connection;
        }

        public void Insert(UserDal user)
        {
            /*byte[] passwd = Encoding.Unicode.GetBytes(user.Passwd);
            HashTool hashTool = new HashTool();
            byte[] hashPasswd = hashTool.Hash(passwd);*/

            Command command = new Command("BEN_SP_RegisterUser", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("IsAdmin", user.IsAdmin);
            command.AddParameter("Passwd", user.Passwd);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, UserDal user)
        {/*
            byte[] passwd = Encoding.Unicode.GetBytes(user.Passwd);
            HashTool hashTool = new HashTool();
            byte[] hashPasswd = hashTool.Hash(passwd);*/

            Command command = new Command("BEN_SP_UpdateUser", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            /*command.AddParameter("Email", user.Email);
            command.AddParameter("IsAdmin", user.IsAdmin);
            command.AddParameter("Passwd", user.Passwd);*/

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("BEN_SP_DeleteUser", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

        public void ReactivateStatus( int ChangedUserId)
        {
            Command command = new Command("BEN_SP_ReactivateStatus", true);
            command.AddParameter("ChangedUserId", ChangedUserId);
            _connection.ExecuteNonQuery(command);
        }

        public void DeactivateStatus(int ChangUserId)
        {

            Command command = new Command("BEN_SP_DeactivateStatus", true);
            command.AddParameter("ChangedUserId", ChangUserId);
            _connection.ExecuteNonQuery(command);
        }

       

     

        public void AskActivateStatus(int ChangedUserId)
        {
            Command command = new Command("BEN_SP_AskActivateStatus", true);
            command.AddParameter("ChangedUserId", ChangedUserId);
            _connection.ExecuteNonQuery(command);
        } 

         public void AskDeleteStatus(int ChangedUserId)
        {
            Command command = new Command("BEN_SP_AskDeleteStatus", true);
            command.AddParameter("ChangedUserId", ChangedUserId);
            _connection.ExecuteNonQuery(command);
        }

        public bool EmailExists(string email)
        {
            Command command = new Command("Select Count(*) FROM [Users] WHERE Email = @Email;");
            command.AddParameter("Email", email);

            int count = (int)_connection.ExecuteScalar(command);

            return count == 1;
        }

        public UserDal Login(LoginUserDal loginUser)
        {
            Command command = new Command("BEN_SP_LoginUser", true);
            command.AddParameter("Email", loginUser.Email);
            command.AddParameter("Passwd", loginUser.Passwd);
            UserDal user = _connection.ExecuteReader(command, dr => dr.DBToUserDal()).SingleOrDefault();
            return user;
        }

        public StatusDal GetStatus(int userId)
        {
            Command command = new Command("BEN_SP_Status", true);
            command.AddParameter("UserId", userId);
         
            return _connection.ExecuteReader(command, dr => dr.DBToStatusDal()).SingleOrDefault();
        }

        public UserDal GetUser(int userId)
        {
            Command command = new Command("SELECT * FROM [View_Users] WHERE Id = @Id");
            command.AddParameter("Id", userId);

            return _connection.ExecuteReader(command, dr => dr.DBToUserDal()).SingleOrDefault();
        }

        public IEnumerable<UserDal> GetAllUsers()
        {
            Command command = new Command("SELECT * FROM [View_Users]");

            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

        //admin

        public void BlockedStatusAdmin(int ChangedUserId, int EditorUserId)
        {

            Command command = new Command("BEN_SP_BlockedStatusAdmin", true);
            command.AddParameter("ChangedUserId", ChangedUserId);
            command.AddParameter("EditorUserId", EditorUserId);
            _connection.ExecuteNonQuery(command);
        }

        public void UnBlockedStatusAdmin(int ChangedUserId, int EditorUserId)
        {

            Command command = new Command("BEN_SP_UnBlockedStatusAdmin", true);
            command.AddParameter("ChangedUserId", ChangedUserId);
            command.AddParameter("EditorUserId", EditorUserId);
            _connection.ExecuteNonQuery(command);
        }

        public void ReactivateStatusAdmin(int ChangedUserId, int EditorUserId)
        {
            Command command = new Command("BEN_SP_ReactivateStatusAdmin", true);
            command.AddParameter("ChangedUserId", ChangedUserId);
            command.AddParameter("EditorUserId", EditorUserId);
            _connection.ExecuteNonQuery(command);
        }

        public void DeleteStatusAdmin(int ChangedUserId, int EditorUserId)
        {
            Command command = new Command("BEN_SP_DeleteStatusAdmin", true);
            command.AddParameter("ChangedUserId", ChangedUserId);
            command.AddParameter("EditorUserId", EditorUserId);
            _connection.ExecuteNonQuery(command);
        }


    }
}
