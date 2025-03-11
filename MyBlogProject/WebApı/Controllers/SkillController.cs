using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.SkillDtos;

namespace MyBlogProject.WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _SkillService;

        public SkillController(ISkillService SkillService)
        {
            _SkillService = SkillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Skills = await _SkillService.GetAllAsync();
            return Ok(Skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Skill = await _SkillService.GetSkillByIdAsync(id);
            if (Skill == null)
                return NotFound($"ID'si {id} olan Yetenek bulunamadı.");

            return Ok(Skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResultSkillDto SkillDto)
        {
            if (SkillDto == null)
                return BadRequest("Geçersiz Yetenek verisi.");

            var Skill = new Skill
            {
                Id = SkillDto.Id,
                SkillName = SkillDto.SkillName,
                Value = SkillDto.Value

            };

            await _SkillService.CreateSkillAsync(Skill);
            return Ok("Yetenek başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResultSkillDto SkillDto)
        {
            if (SkillDto == null)
                return BadRequest("Geçersiz Yetenek verisi.");

            var existingSkill = await _SkillService.GetSkillByIdAsync(id);
            if (existingSkill == null)
                return NotFound($"ID'si {id} olan Yetenek bulunamadı.");

           existingSkill.SkillName = SkillDto.SkillName;
            existingSkill.Value = SkillDto.Value;


            await _SkillService.UpdateSkillAsync(existingSkill);
            return Ok("Yetenek başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSkill = await _SkillService.GetSkillByIdAsync(id);
            if (existingSkill == null)
                return NotFound($"ID'si {id} olan Yetenek bulunamadı.");

            await _SkillService.DeleteSkillAsync(id);
            return Ok("Yetenek başarıyla silindi.");
        }
    }
}
