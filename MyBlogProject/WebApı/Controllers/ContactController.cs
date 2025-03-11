using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.ContactDtos;

namespace MyBlogProject.WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Contacts = await _ContactService.GetAllAsync();
            return Ok(Contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Contact = await _ContactService.GetContactByIdAsync(id);
            if (Contact == null)
                return NotFound($"ID'si {id} olan İletişim bulunamadı.");

            return Ok(Contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResultContactDto ContactDto)
        {
            if (ContactDto == null)
                return BadRequest("Geçersiz İletişim verisi.");

            var Contact = new Contact
            {
               Id = ContactDto.Id,
               Name= ContactDto.Name,
               Message= ContactDto.Message,
               Email = ContactDto.Email,
                Subject = ContactDto.Subject    
            };

            await _ContactService.CreateContactAsync(Contact);
            return Ok("İletişim başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResultContactDto ContactDto)
        {
            if (ContactDto == null)
                return BadRequest("Geçersiz İletişim verisi.");

            var existingContact = await _ContactService.GetContactByIdAsync(id);
            if (existingContact == null)
                return NotFound($"ID'si {id} olan İletişim bulunamadı.");

           existingContact.Name = ContactDto.Name;
            existingContact.Message = ContactDto.Message;
            existingContact.Email = ContactDto.Email;
            existingContact.Subject = ContactDto.Subject;


            await _ContactService.UpdateContactAsync(existingContact);
            return Ok("İletişim başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingContact = await _ContactService.GetContactByIdAsync(id);
            if (existingContact == null)
                return NotFound($"ID'si {id} olan İletişim bulunamadı.");

            await _ContactService.DeleteContactAsync(id);
            return Ok("İletişim başarıyla silindi.");
        }
    }
}
