using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Interfaces;
using AutoMapper;
using MyBlogProject.Entities;
using MyBlogProject.Business.Services;
using MyBlogProject.WebApı.Dtos.PostDtos;

namespace MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm postları getirir.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPostsAsync();
            var postsDTO = _mapper.Map<List<PostDto>>(posts); // Post verisini PostDTO'ya dönüştür
            return Ok(postsDTO);
        }

        /// <summary>
        /// ID'ye göre postu getirir.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
                return NotFound();

            var postDTO = _mapper.Map<PostDto>(post); // Post verisini PostDTO'ya dönüştür
            return Ok(postDTO);
        }

        /// <summary>
        /// Yeni bir post oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDto postDto)
        {
            if (postDto == null)
                return BadRequest();

            var post = _mapper.Map<Post>(postDto); // PostDTO'yu Post modeline dönüştür
            await _postService.CreatePostAsync(post);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Bir postu günceller.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PostDto postDto)
        {
            if (postDto == null || postDto.Id != id)
                return BadRequest();

            var post = _mapper.Map<Post>(postDto); // PostDTO'yu Post modeline dönüştür
            await _postService.UpdatePostAsync(post);

            return Ok(post);
        }

        /// <summary>
        /// Bir postu siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeletePostAsync(id);
            return Ok();
        }


    }
}
