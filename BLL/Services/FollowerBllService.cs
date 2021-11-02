﻿using BLL.Interfaces;
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
    public class FollowerBllService : IFollowerBll
    {
        private readonly IFollowerDal _followerDal;

        public FollowerBllService(IFollowerDal followerDal)
        {
            _followerDal = followerDal;
        }

        public void Follow(int followerId, int followedId)
        {
            _followerDal.Follow(followerId, followedId);
        }

        public void UnFollow(int followerId, int followedId)
        {
            _followerDal.UnFollow( followerId, followedId);
        }

        public IEnumerable<UserBll> GetAllFollowed()
        {
            return _followerDal.GetAllFollowed().Select(u => u.DalUserToBllUser());
        }

        public IEnumerable<UserBll> GetAllFollowedOfOneUser(int followerId)
        {
            return _followerDal.GetAllFollowedOfOneUser(followerId).Select(u => u.DalUserToBllUser());
        }

        public IEnumerable<UserBll> GetAllFollower()
        {
            return _followerDal.GetAllFollower().Select(u => u.DalUserToBllUser());
        }

        public IEnumerable<UserBll> GetAllFollowersOfOneUser(int followedId)
        {
            return _followerDal.GetAllFollowersOfOneUser(followedId).Select(u => u.DalUserToBllUser());
        }

        
    }
}
