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

        #region Récupération de messages
        //Récupérer tous les messages du serveurs
        [HttpGet("GetAllMessages")]
        public IActionResult GetAllMessages()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetAllMessages());
        }


        // Récupérer tous les messages d'un utilisateur dont l'id  est userId
        [HttpGet("GetAllMessagesOfUser/{id}")]
        public IActionResult GetAllMessagesOfUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetAllMessagesOfUser(id));
        }


        // Récupérer tous les messages échangés entre deux utilisateurs userId1 et userId2
        [HttpPost("GetMessageBetweenToUsers")]
        public IActionResult GetMessageBetweenToUsers(MessageBeteweenUsers message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetMessageBetweenToUsers(message.UserId1, message.UserId2).ToList());
        }


        // Récupérer tous les messages envoyés par l'utilisateur userSendId à l'utilisateur userGetId
        [HttpPost("GetMessageFromUser")]
        public IActionResult GetMessageFromUser(MessageBeteweenUsers message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetMessageFromUser(message.UserId1, message.UserId2));
        }

        // Récupérer un message par son Id
        [HttpGet("GetMessageById/{id}")]
        public IActionResult GetMessageById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.GetMessageById(id));
        }

        #endregion


        #region Création /édition / suppression de message
        // Créer un message
        [HttpPost("CreateMessage")]
        public IActionResult CreateMessage(AddMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_messageBll.CreateMessage(message.MessageApiToMessageBll()));
        }


        // Mettre à jour un message
        [HttpPost("UpdateMessage")]
        public IActionResult UpdateMessage(UpdateMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _messageBll.UpdateMessage(
                new MessageBll
                {
                    Id = message.Id,
                    Content = message.Content,
                    UserSend = message.UserSend
                }); ;
            return Ok();
        }


        // Supprimer un message
        [HttpDelete("DeleteMessage")]
        public IActionResult DeleteMessage(DeleteMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _messageBll.DeleteMessage(message.Id, message.UserSend);
            return Ok();
        }

        #endregion


        #region Réception (lecture) d'un message

        // Recevoir un message (en mettant à jour la date de réception)
        [HttpPost("ReciveMessage")]
        public IActionResult ReciveMessage(ReciveMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _messageBll.ReciveMessage(message.MessageId, message.UserGetId);
            return Ok();
        }

        #endregion

    }
}