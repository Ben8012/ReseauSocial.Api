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
    public class FollowerDalService : IFollowerDal
    {
        private readonly IConnection _connection;
        public FollowerDalService(IConnection connection)
        {
            _connection = connection;
        }

        public void Follow(int followerId, int followedId)
        {
            Command command = new Command("BEN_SP_Follow", true);
            command.AddParameter("FollowedId", followedId);
            command.AddParameter("FollowerId", followerId);

            _connection.ExecuteNonQuery(command);
        }

        public void UnFollow(int followerId, int followedId)
        {
            Command command = new Command("BEN_SP_UnFollow", true);
            command.AddParameter("FollowedId", followedId);
            command.AddParameter("FollowerId", followerId);

            _connection.ExecuteNonQuery(command);
        }

        // liste de tout les utilisateur qui suivent 
        public IEnumerable<UserDal> GetAllFollower()
        {
            Command command = new Command("SELECT * FROM [View_Followers]", false);

            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

        //liste de tout les utilisateurs qui sont suivit 
        public IEnumerable<UserDal> GetAllFollowed()
        {
            Command command = new Command("SELECT * FROM [View_Followed]", false);

            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

        //liste des utilisateurs qui suivent l'utilisateur en cours
        public IEnumerable<UserDal> GetAllFollowersOfOneUser(int followedId)
        {
            Command command = new Command("SELECT * FROM [View_Followers] WHERE FollowedId= @FollowedId", false);
            command.AddParameter("FollowedId", followedId);
            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

        // liste des utilisateurs qui sont suivit par l'utilisateur en cours
        public IEnumerable<UserDal> GetAllFollowedOfOneUser(int followerId)
        {
            Command command = new Command("SELECT * FROM [View_Followed] WHERE FollowerId= @FollowerId", false);
            command.AddParameter("FollowerId", followerId);
            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }
    }
}
