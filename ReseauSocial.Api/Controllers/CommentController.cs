using BLL.Interfaces;
using BLL.Models;
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
    public class CommentController : ControllerBase
    {
        private readonly IArticleBll _articleService;
        private readonly ICommentBll _commentService;
        public CommentController(IArticleBll articleService, ICommentBll commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        [HttpGet("GetAllComment")]
        public IActionResult GetAllComment()
        {
            IEnumerable<CommentBll> comments = _commentService.GetAllComment();
            return Ok(comments);
        }

        [HttpGet("GetByArticleId/{id}")]
        public IActionResult GetByArticleId(int id)
        {
            IEnumerable<CommentBll> comments = _commentService.GetByArticleId(id);
            return Ok(comments);
        }
        [HttpGet("CountByArticleId/{id}")]
        public IActionResult CountByArticleId(int id)
        {
            int count = _commentService.CountByArticleId(id);
            return Ok(count);
        }
        [HttpGet("GetByUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            IEnumerable<CommentBll> comments = _commentService.GetByUserId(id);
            return Ok(comments);
        }
        [HttpGet("CountByUserId/{id}")]
        public IActionResult CountByUserId(int id)
        {
            int count = _commentService.CountByUserId(id);
            return Ok(count);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            CommentBll comment = _commentService.GetById(id);
            return Ok(comment);
        }
        [HttpPost("AddComment")]
        public IActionResult AddComment(AddCommentForm entity)
        {
            return Ok(_commentService.AddComment(new CommentBll
            {
                Message = entity.Message,
                UserId = entity.UserId,
                ArticleId = entity.ArticleId
            }));
        }
    }
}
