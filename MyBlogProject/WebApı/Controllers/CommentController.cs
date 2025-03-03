using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Services;
using MyBlogProject.WebApı.Dtos.CommentDtos;

namespace MyBlogProject.WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Tüm yorumları getirir.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        /// <summary>
        /// ID'ye göre yorum getirir.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            return comment == null ? NotFound() : Ok(comment);
        }

        /// <summary>
        /// Yeni bir yorum oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentDto commentDto)
        {
            await _commentService.CreateCommentAsync(commentDto);
            return StatusCode(201);  // Created
        }

        /// <summary>
        /// Yorum günceller.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CommentDto commentDto)
        {
            await _commentService.UpdateCommentAsync(commentDto);
            return Ok(commentDto);
        }

        /// <summary>
        /// Yorum siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();  // 204 No Content
        }

        /// <summary>
        /// Belirli bir postun yorumlarını getirir.
        /// </summary>
        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetByPostId(int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }
    }
}

