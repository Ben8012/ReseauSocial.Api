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
    public class BlacklistController : ControllerBase
    {
        private IBlacklistBll _blacklistBll;

        public BlacklistController(IBlacklistBll blacklistBll)
        {
            _blacklistBll = blacklistBll;
        }

     

        [HttpGet("Blacklist/{blacklisterId}/{blacklistedId}")]
        public IActionResult Blacklist(int blacklisterId, int blacklistedId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _blacklistBll.Blacklist( blacklisterId, blacklistedId);
            return Ok();
        }


        [HttpGet("UnBlacklist/{blacklisterId}/{blacklistedId}")]
        public IActionResult UnBlacklist(int blacklisterId, int blacklistedId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _blacklistBll.UnBlacklist(blacklisterId, blacklistedId);
            return Ok();
        }

        [HttpGet("GetAllBlacklisted")]
        public IActionResult GetAllBlacklisted()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_blacklistBll.GetAllBlacklisted());
        }

        [HttpGet("GetAllBlacklister")]
        public IActionResult GetAllBlacklister()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_blacklistBll.GetAllBlacklister());
        }

        [HttpGet("GetAllBlacklistedOfOneUser/{blacklisterId}")]
        public IActionResult GetAllBlacklistedOfOneUser(int blacklisterId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_blacklistBll.GetAllBlacklistedOfOneUser( blacklisterId));
        }

        [HttpGet("GetAllBlacklisterOfOneUser/{blacklistedId}")]
        public IActionResult GetAllBlacklisterOfOneUser(int blacklistedId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_blacklistBll.GetAllBlacklisterOfOneUser( blacklistedId));
        }

        [HttpGet("IsUser1BlacklisterOfUser2/{blacklisterId}/{blacklistedId}")]
        public IActionResult IsUser1BlacklisterOfUser2(int blacklisterId, int blacklistedId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_blacklistBll.IsUser1BlacklisterOfUser2( blacklisterId, blacklistedId));
        }

    }
}