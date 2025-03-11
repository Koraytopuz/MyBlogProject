using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Services;
using MyBlogProject.WebApı.Dtos.PortfolioDetailDtos;

namespace MyBlogProject.WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioDetailController : ControllerBase
    {
        private readonly IPortfolioDetailService _PortfolioDetailService;

        public PortfolioDetailController(IPortfolioDetailService PortfolioDetailService)
        {
            _PortfolioDetailService = PortfolioDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PortfolioDetails = await _PortfolioDetailService.GetAllAsync();
            return Ok(PortfolioDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var PortfolioDetail = await _PortfolioDetailService.GetPortfolioDetailByIdAsync(id);
            if (PortfolioDetail == null)
                return NotFound($"ID'si {id} olan Portfolyo Detayları bulunamadı.");

            return Ok(PortfolioDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResultPortfolioDetailDto PortfolioDetailDto)
        {
            if (PortfolioDetailDto == null)
                return BadRequest("Geçersiz Portfolyo Detayları verisi.");

            var PortfolioDetail = new Entities.PortfolioDetail
            {
                BigImageUrl = PortfolioDetailDto.BigImageUrl,
                Description = PortfolioDetailDto.Description,
                Detail = PortfolioDetailDto.Detail,
                ProjectTitle = PortfolioDetailDto.ProjectTitle,
                ProjectUrl = PortfolioDetailDto.ProjectUrl,
                Title = PortfolioDetailDto.Title
                
            };

            await _PortfolioDetailService.CreatePortfolioDetailAsync(PortfolioDetail);
            return Ok("Portfolyo Detayları başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResultPortfolioDetailDto PortfolioDetailDto)
        {
            if (PortfolioDetailDto == null)
                return BadRequest("Geçersiz Portfolyo Detayları verisi.");

            var existingPortfolioDetail = await _PortfolioDetailService.GetPortfolioDetailByIdAsync(id);
            if (existingPortfolioDetail == null)
                return NotFound($"ID'si {id} olan Portfolyo Detayları bulunamadı.");

            existingPortfolioDetail.BigImageUrl = PortfolioDetailDto.BigImageUrl;
            existingPortfolioDetail.Description = PortfolioDetailDto.Description;
            existingPortfolioDetail.Detail = PortfolioDetailDto.Detail;
            existingPortfolioDetail.ProjectTitle = PortfolioDetailDto.ProjectTitle;
            existingPortfolioDetail.ProjectUrl = PortfolioDetailDto.ProjectUrl;
            existingPortfolioDetail.Title = PortfolioDetailDto.Title;



            await _PortfolioDetailService.UpdatePortfolioDetailAsync(existingPortfolioDetail);
            return Ok("Portfolyo Detayları başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPortfolioDetail = await _PortfolioDetailService.GetPortfolioDetailByIdAsync(id);
            if (existingPortfolioDetail == null)
                return NotFound($"ID'si {id} olan Portfolyo Detayları bulunamadı.");

            await _PortfolioDetailService.DeletePortfolioDetailAsync(id);
            return Ok("Portfolyo Detayları başarıyla silindi.");
        }
    }
}
