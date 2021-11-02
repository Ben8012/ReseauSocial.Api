using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private IFollowerBll _followerBll;

        public FollowerController(IFollowerBll followerBll)
        {
            _followerBll = followerBll;
        }

        [HttpGet("Follow/{followerId}/{followedId}")]
        public IActionResult Follow(int followerId, int followedId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _followerBll.Follow( followerId, followedId);
            return Ok();
        }

        [HttpGet("UnFollow/{followerId}/{followedId}")]
        public IActionResult UnFollow(int followerId, int followedId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _followerBll.UnFollow(followerId, followedId);
            return Ok();
        }


        [HttpGet("GetAllFollower")]
        public IActionResult GetAllFollower()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_followerBll.GetAllFollower());
        }

        [HttpGet("GetAllFollowed")]
        public IActionResult GetAllFollowed()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_followerBll.GetAllFollowed());
        }

        [HttpGet("GetAllFollowersOfOneUser/{followedId}")]
        public IActionResult GetAllFollowersOfOneUser(int followedId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_followerBll.GetAllFollowersOfOneUser(followedId));
        }

        [HttpGet("GetAllFollowedOfOneUser/{followerId}")]
        public IActionResult GetAllFollowedOfOneUser(int followerId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return Ok(_followerBll.GetAllFollowedOfOneUser(followerId));
        }
    }
}