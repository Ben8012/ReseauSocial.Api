using BLL.Interfaces;
using BLL.Models;
using ReseauSocial.Api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReseauSocial.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageBll _messageBll;

        public MessageController(IMessageBll messageBll)
        {
            _messageBll = messageBll;
        }

        [HttpPost("CreateMessage")]
        public IActionResult CreateMessage(AddMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _messageBll.CreateMessage(message.MessageApiToMessageBll());
            return Ok();
        }

        [HttpPost("ReciveMessage")]
        public IActionResult ReciveMessage(ReciveMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _messageBll.ReciveMessage( message.MessageId,  message.UserGetId);
            return Ok();
        }


        [HttpPost("UpdateMessage")]
        public IActionResult UpdateMessage(UpdateMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _messageBll.UpdateMessage(
                new MessageBll { 
                    Id = message.Id,
                    Content = message.Content,
                    UserSend = message.UserSend
                });;
            return Ok();
        }


        [HttpDelete("DeleteMessage")]
        public IActionResult DeleteMessage(DeleteMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

                _messageBll.DeleteMessage(
                    new MessageBll{ 
                    Id = message.Id,
                    UserSend = message.UserSend
                    });
            return Ok();
        }

        [HttpPost("GetMessageBetweenToUsers")]
        public IActionResult GetMessageBetweenToUsers(MessageBeteweenUsers message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetMessageBetweenToUsers(message.UserId1, message.UserId2));
        }

        [HttpPost("GetMessageById/{MessageId}")]
        public IActionResult GetMessageById(int MessageId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetMessageById(MessageId));
        }

        [HttpPost("GetMessageFromUser")]
        public IActionResult GetMessageFromUser(MessageBeteweenUsers message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetMessageFromUser(message.UserId1, message.UserId2));
        }
    }
}