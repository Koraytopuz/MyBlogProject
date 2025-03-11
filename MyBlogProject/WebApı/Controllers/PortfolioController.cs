using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;

namespace MyBlogProject.WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _PortfolioService;

        public PortfolioController(IPortfolioService PortfolioService)
        {
            _PortfolioService = PortfolioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Portfolios = await _PortfolioService.GetAllAsync();
            return Ok(Portfolios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Portfolio = await _PortfolioService.GetPortfolioByIdAsync(id);
            if (Portfolio == null)
                return NotFound($"ID'si {id} olan Portfolyo bulunamadı.");

            return Ok(Portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResultPortfolioDto PortfolioDto)
        {
            if (PortfolioDto == null)
                return BadRequest("Geçersiz Portfolyo verisi.");

            var Portfolio = new Portfolio
            {
                Description = PortfolioDto.Description,
                ImageUrl = PortfolioDto.ImageUrl,
                PortfolioId = PortfolioDto.PortfolioId
            };

            await _PortfolioService.CreatePortfolioAsync(Portfolio);
            return Ok("Portfolyo başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResultPortfolioDto PortfolioDto)
        {
            if (PortfolioDto == null)
                return BadRequest("Geçersiz Portfolyo verisi.");

            var existingPortfolio = await _PortfolioService.GetPortfolioByIdAsync(id);
            if (existingPortfolio == null)
                return NotFound($"ID'si {id} olan Portfolyo bulunamadı.");

           existingPortfolio.Description = PortfolioDto.Description;
           existingPortfolio.ImageUrl = PortfolioDto.ImageUrl;


            await _PortfolioService.UpdatePortfolioAsync(existingPortfolio);
            return Ok("Portfolyo başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPortfolio = await _PortfolioService.GetPortfolioByIdAsync(id);
            if (existingPortfolio == null)
                return NotFound($"ID'si {id} olan Portfolyo bulunamadı.");

            await _PortfolioService.DeletePortfolioAsync(id);
            return Ok("Portfolyo başarıyla silindi.");
        }
    }
}
