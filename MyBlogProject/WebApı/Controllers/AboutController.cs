using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using MyBlogProject.WebApı.Dtos.SocialMediaDtos;

namespace MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var abouts = await _aboutService.GetAllAsync();
            return Ok(_mapper.Map<List<AboutDto>>(abouts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var about = await _aboutService.GetAboutByIdAsync(id);
            if (about == null)
                return NotFound();
            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AboutDto aboutDto)
        {
            if (aboutDto == null)
                return BadRequest();

            var about = _mapper.Map<About>(aboutDto);
            await _aboutService.CreateAboutAsync(about);

            return Ok("About Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AboutDto aboutDto)
        {
            if (id != aboutDto.AboutId)
                return BadRequest("About ID mismatch");

            var about = _mapper.Map<About>(aboutDto);
            await _aboutService.UpdateAboutAsync(about);
            return Ok("About Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("About Deleted Successfully");
        }
    }
}

