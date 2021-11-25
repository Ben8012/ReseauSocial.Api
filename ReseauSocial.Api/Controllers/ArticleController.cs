using API.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReseauSocial.Api.Mappers;
using BLL.Models;
using ReseauSocial.Api.Models;
using Microsoft.AspNetCore.Authorization;

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


        [HttpPost("BlockArticleAdmin")]
        public IActionResult BlockArticleAdmin(ArticleBlocked form )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.BlockArticleAdmin( form.ArticleId, form.AdminId, form.Message);
            return Ok();
        }


        [HttpGet("UnBlockArticleAdmin/{articleId}/{AdminId}")]
        public IActionResult UnBlockArticleAdmin(int articleId, int AdminId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.UnBlockArticleAdmin(articleId, AdminId);
            return Ok();
        }

        [HttpGet("IsArticleBlock/{articleId}")]
        public IActionResult IsArticleBlock(int articleId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_articleBll.IsArticleBlock(articleId));
        }

        [HttpGet("IsSignalArticle/{articleId}")]
        public IActionResult IsSignalArticle(int articleId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_articleBll.IsSignalArticle(articleId));
        }

        [HttpGet("IsSignalByUser/{articleId}/{userId}")]
        public IActionResult IsSignalByUser(int articleId, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_articleBll.IsSignalByUser(articleId,userId));
        }

        [HttpGet("UnSignalArticle/{articleId}/{userId}")]
        public IActionResult UnSignalArticle(int articleId, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _articleBll.UnSignalArticle(articleId, userId);
            return Ok();
        }

        [HttpGet("UnSignalArticleAdmin/{articleId}/{userId}")]
        public IActionResult UnSignalArticleAdmin(int articleId, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _articleBll.UnSignalArticleAdmin(articleId, userId);
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

        [HttpDelete("Delete/{id}")]
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
        public IActionResult SignalArticle(SignalArticle article)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.SignalArticle( article.ArticleId, article.UserId);
            return Ok();
        }

        [HttpPost("Update/{id}")]
        public IActionResult Update(int id, AddArticle article)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _articleBll.Update(id, article.ArticleApiToArticleBll());
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("GetAllArticle")]
        public IActionResult GetAllArticle()
        {
            IEnumerable<ArticleBll> listArticles = _articleBll.GetAllArticle();
            return Ok(listArticles);
        }


        [HttpGet("GetArticleById/{id}")]
        public IActionResult GetArticleById(int id)
        {
            ArticleBll article = _articleBll.GetArticleById(id);
            return Ok(article);

        }

        [HttpGet("GetArticleByUserId/{id}")]
        public IActionResult GetArticleByUserId(int id)
        {
            IEnumerable<ArticleBll> listArticles = _articleBll.GetArticleByUserId(id);
            return Ok(listArticles);
        }

    }
}