using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAllAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            if (comment == null)
                return NotFound();
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Comment comment)
        {
            if (comment == null)
                return BadRequest("Comment is null");

            await _commentService.AddAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Comment comment)
        {
            if (id != comment.Id)
                return BadRequest("Comment ID mismatch");

            await _commentService.UpdateAsync(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetCommentsByPostId(int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCommentsByUserId(int userId)
        {
            var comments = await _commentService.GetCommentsByUserIdAsync(userId);
            return Ok(comments);
        }
    }
}