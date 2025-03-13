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
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var portfolios = await _portfolioService.GetAllAsync();
            return Ok(portfolios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var portfolio = await _portfolioService.GetPortfolioByIdAsync(id);
            if (portfolio == null)
                return NotFound($"ID'si {id} olan Portfolyo bulunamadı.");

            return Ok(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResultPortfolioDto portfolioDto)
        {
            if (portfolioDto == null)
                return BadRequest("Geçersiz Portfolyo verisi.");

            var portfolio = new Portfolio
            {
                Description = portfolioDto.Description,
                ImageUrl = portfolioDto.ImageUrl,
                PortfolioId = portfolioDto.PortfolioId,
                // Diğer alanlar burada eklenebilir
            };

            await _portfolioService.CreatePortfolioAsync(portfolio);
            return Ok("Portfolyo başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResultPortfolioDto portfolioDto)
        {
            if (portfolioDto == null)
                return BadRequest("Geçersiz Portfolyo verisi.");

            var existingPortfolio = await _portfolioService.GetPortfolioByIdAsync(id);
            if (existingPortfolio == null)
                return NotFound($"ID'si {id} olan Portfolyo bulunamadı.");

            existingPortfolio.Description = portfolioDto.Description;
            existingPortfolio.ImageUrl = portfolioDto.ImageUrl;
            // Diğer alanlar burada güncellenebilir

            await _portfolioService.UpdatePortfolioAsync(existingPortfolio);
            return Ok("Portfolyo başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPortfolio = await _portfolioService.GetPortfolioByIdAsync(id);
            if (existingPortfolio == null)
                return NotFound($"ID'si {id} olan Portfolyo bulunamadı.");

            await _portfolioService.DeletePortfolioAsync(id);
            return Ok("Portfolyo başarıyla silindi.");
        }
    }
}

