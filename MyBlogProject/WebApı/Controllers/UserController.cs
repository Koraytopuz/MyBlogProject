using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Entities;
using MyBlogProject.Business.Services;
using MyBlogProject.WebApı.Dtos.UserDtos;

namespace MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Tüm kullanıcıları getirir.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();

            if (users == null || !users.Any())
                return NotFound("Kullanıcı bulunamadı.");

            var userDtos = users.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Mail = u.Mail
            }).ToList();

            return Ok(userDtos);
        }

    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound($"ID'si {id} olan kullanıcı bulunamadı.");

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail
            };

            return Ok(userDto);
        }

     
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("Geçersiz kullanıcı verisi.");

            var user = new User
            {
                UserName = userDto.UserName,
                Mail = userDto.Mail
            };

            await _userService.CreateUserAsync(user);
            return StatusCode(StatusCodes.Status201Created, "Kullanıcı başarıyla oluşturuldu.");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("Geçersiz kullanıcı verisi.");

            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound($"ID'si {id} olan kullanıcı bulunamadı.");

            existingUser.UserName = userDto.UserName;
            existingUser.Mail = userDto.Mail;

            await _userService.UpdateUserAsync(existingUser);
            return Ok("Kullanıcı başarıyla güncellendi.");
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound($"ID'si {id} olan kullanıcı bulunamadı.");

            await _userService.DeleteUserAsync(id);
            return Ok("Kullanıcı başarıyla silindi.");
        }
        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            return Ok(user);
        }
    }
}