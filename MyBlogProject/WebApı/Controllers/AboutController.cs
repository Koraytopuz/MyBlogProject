using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.AboutDtos;

namespace MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var abouts = await _aboutService.GetAllAsync();
            return Ok(abouts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var about = await _aboutService.GetAboutByIdAsync(id);
            if (about == null)
                return NotFound($"ID'si {id} olan Hakkımda bulunamadı.");

            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AboutDto aboutDto)
        {
            if (aboutDto == null)
                return BadRequest("Geçersiz Hakkımda verisi.");

            var about = new About
            {
                Title = aboutDto.Title,
                Description = aboutDto.Description,
                Details = aboutDto.Details,
                Status = aboutDto.Status,
                ImageUrl = aboutDto.ImageUrl,
                Birthday = aboutDto.Birthday,
                Age = aboutDto.Age,
                Degree = aboutDto.Degree,
                WebUrl = aboutDto.WebUrl,
                Email = aboutDto.Email,
                Location = aboutDto.Location,
                Phone = aboutDto.Phone

            };

            await _aboutService.CreateAboutAsync(about);
            return Ok("Hakkımda başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AboutDto aboutDto)
        {
            if (aboutDto == null)
                return BadRequest("Geçersiz Hakkımda verisi.");

            var existingAbout = await _aboutService.GetAboutByIdAsync(id);
            if (existingAbout == null)
                return NotFound($"ID'si {id} olan Hakkımda bulunamadı.");

            existingAbout.Title = aboutDto.Title;
            existingAbout.Description = aboutDto.Description;
            existingAbout.Details = aboutDto.Details;
            existingAbout.Status = aboutDto.Status;
            existingAbout.ImageUrl = aboutDto.ImageUrl;
            existingAbout.Birthday = aboutDto.Birthday;
            existingAbout.Age = aboutDto.Age;
            existingAbout.Degree = aboutDto.Degree;
            existingAbout.WebUrl = aboutDto.WebUrl;
            existingAbout.Email = aboutDto.Email;
            existingAbout.Location = aboutDto.Location;
            existingAbout.Phone = aboutDto.Phone;

            await _aboutService.UpdateAboutAsync(existingAbout);
            return Ok("Hakkımda başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingAbout = await _aboutService.GetAboutByIdAsync(id);
            if (existingAbout == null)
                return NotFound($"ID'si {id} olan Hakkımda bulunamadı.");

            await _aboutService.DeleteAboutAsync(id);
            return Ok("Hakkımda başarıyla silindi.");
        }
    }
}

