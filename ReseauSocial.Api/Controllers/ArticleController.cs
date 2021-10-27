using API.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReseauSocial.Api.Mappers;

namespace ReseauSocial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleBll _articleBll;

        public ArticleController(IArticleBll articleBll)
        {
            _articleBll = articleBll;
        }


        [HttpPost("BlockArticle")]
        public IActionResult BlockArticle(int articleId, int AdminId, string message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.BlockArticle( articleId, AdminId, message);
            return Ok();
        }

        [HttpPost("CommentArticle")]
        public IActionResult CommentArticle(int articleId, int userId, string message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.CommentArticle( articleId, userId, message);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.Delete( id);
            return Ok();
        }


        [HttpPost("Insert")]
        public IActionResult Insert(AddArticle article)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.Insert(article.ArticleApiToArticleBll());
            return Ok();
        }

        [HttpPost("SignalArticle")]
        public IActionResult SignalArticle(int articleId, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.SignalArticle( articleId, userId);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Update(int id, AddArticle article)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.Update(id, article.ArticleApiToArticleBll());
            return Ok();
        }

    }
}