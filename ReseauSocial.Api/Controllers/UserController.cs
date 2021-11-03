using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReseauSocial.Api.Mappers;
using ReseauSocial.Api.Models;
using ReseauSocial.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("isConnected")]
    public class UserController : ControllerBase
    {
        private IUserBll _userBll;
        private ITokenManager _token;

        public UserController(IUserBll userBll, ITokenManager token)
        {
            _userBll = userBll;
            _token = token;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterUser form)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _userBll.Insert(form.UserApiToUserBll());
            return Ok();
        }


        //[Authorize("isConnected")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, RegisterUser form)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _userBll.Update(id, form.UserApiToUserBll());
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userBll.Delete(id);
            return Ok();
        }

        [HttpPost("ReactivateStatus")]
        public IActionResult ReactivateStatus(int ChangedUserId)
        {
            _userBll.ReactivateStatus( ChangedUserId);
            return Ok();
        }

        [HttpPost("DeactivateStatus")]
        public IActionResult DeactivateStatus(int ChangUserId)
        {
            _userBll.DeactivateStatus( ChangUserId);
            return Ok();
        }

        [HttpPost("BlockedStatus")]
        public IActionResult BlockedStatus(int ChangedUserId, int EditorUserId)
        {
            _userBll.BlockedStatus(ChangedUserId, EditorUserId);
            return Ok();
        }

        [HttpPost("DeleteStatus")]
        public IActionResult DeleteStatus(int ChangedUserId, int EditorUserId)
        {
            _userBll.DeleteStatus( ChangedUserId,  EditorUserId);
            return Ok();
        }

        [HttpPost("AskActivateStatus/{ChangedUserId}")]
        public IActionResult AskActivateStatus(int ChangedUserId)
        {
            _userBll.AskActivateStatus( ChangedUserId);
            return Ok();
        }

        [HttpPost("AskDeleteStatus/{ChangedUserId}")]
        public IActionResult AskDeleteStatus(int ChangedUserId)
        {
            _userBll.AskDeleteStatus( ChangedUserId);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("EmailExists")]
        public IActionResult EmailExists(string email)
        {
            return Ok(_userBll.EmailExists(email));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginUser loginUser)
        {
            UserBll user = _userBll.Login(loginUser.LoginUserBllToLoginUserDal());

            if(user is null)
            {
                return BadRequest("user is nul after login");
            }
            UserWithToken userWithToken = new UserWithToken()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Passwd = null,
                Token = _token.GenerateJWTUser(user)
            };
            return Ok(userWithToken);

        }



        [HttpGet("GetStatus/{userId}")]
        public IActionResult GetStatus(int userId)
        {
            return Ok(_userBll.GetStatus(userId)) ;
        }

        [AllowAnonymous]
        [HttpGet("GetUser/{userId}")]
        public IActionResult GetUser(int userId)
        {
            return Ok(_userBll.GetUser(userId));
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userBll.GetAllUsers());
        }

    }
}

