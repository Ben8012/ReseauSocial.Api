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
    public class BlacklistDalService : IBlacklistDal
    {
        private readonly IConnection _connection;

        public BlacklistDalService(IConnection connection)
        {
            _connection = connection;
        }

        public void Blacklist(int blacklisterId, int blacklistedId)
        {
            Command command = new Command("BEN_SP_Blacklist", true);
            command.AddParameter("BlacklisterId", blacklisterId);
            command.AddParameter("BlacklistedId", blacklistedId);

            _connection.ExecuteNonQuery(command);
        }

        public void UnBlacklist(int blacklisterId, int blacklistedId)
        {
            Command command = new Command("BEN_SP_UnBlacklist", true);
            command.AddParameter("BlacklisterId", blacklisterId);
            command.AddParameter("BlacklistedId", blacklistedId);

            _connection.ExecuteNonQuery(command);
        }

        public IEnumerable<UserDal> GetAllBlacklisted()
        {
            Command command = new Command("SELECT * FROM [View_Blacklisted]", false);

            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

        public IEnumerable<UserDal> GetAllBlacklister()
        {
            Command command = new Command("SELECT * FROM [View_Blacklister]", false);

            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

        public IEnumerable<UserDal> GetAllBlacklistedOfOneUser(int blacklisterId)
        {
            Command command = new Command("SELECT * FROM [View_Blacklisted] WHERE BlacklisterId= @BlacklisterId", false);
            command.AddParameter("BlacklisterId", blacklisterId);
            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

       

        public IEnumerable<UserDal> GetAllBlacklisterOfOneUser(int blacklistedId)
        {
            Command command = new Command("SELECT * FROM [View_Blacklister] WHERE BlacklistedId= @BlacklistedId", false);
            command.AddParameter("BlacklistedId", blacklistedId);
            return _connection.ExecuteReader(command, dr => dr.DBToUserDal());
        }

        public bool IsUser1BlacklisterOfUser2(int blacklisterId, int blacklistedId)
        {
            Command command = new Command("SELECT COUNT(*) FROM [Blacklist] WHERE BlacklistedId= @BlacklistedId AND BlacklisterId= @BlacklisterId", false);
            command.AddParameter("BlacklistedId", blacklistedId);
            command.AddParameter("BlacklisterId", blacklisterId);
            // si le nombre de blacklisterId et blacklistedId est egal 1 en renvois
            return ((int)_connection.ExecuteScalar(command) == 1);
        }

       
    }
}
