using Frontend_Adm.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.PortfolioDetailDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;
using Newtonsoft.Json;

namespace Frontend_Adm.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PortfolioController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var portfolioDetailResponse = await client.GetAsync($"http://localhost:5276/api/PortfolioDetail/");
            var portfolioDetailList = new List<ResultPortfolioDetailDto>();

            if (portfolioDetailResponse.IsSuccessStatusCode)
            {
                var jsonData = await portfolioDetailResponse.Content.ReadAsStringAsync();
                portfolioDetailList = JsonConvert.DeserializeObject<List<ResultPortfolioDetailDto>>(jsonData);
            }

            var viewModel = new PortfolioViewModel
            {
                PortfolioDetailList = portfolioDetailList
            };

            return View(viewModel);
        }
        

        [HttpGet]
        public async Task<IActionResult> PortfolioDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var portfolioDetailResponse = await client.GetAsync($"http://localhost:5276/api/PortfolioDetail/{id}");
            var portfolioDetailList = new List<ResultPortfolioDetailDto>();

            if (portfolioDetailResponse.IsSuccessStatusCode)
            {
                var jsonData = await portfolioDetailResponse.Content.ReadAsStringAsync();
                portfolioDetailList = JsonConvert.DeserializeObject<List<ResultPortfolioDetailDto>>(jsonData);
            }

            var viewModel = new PortfolioViewModel
            {
                PortfolioDetailList = portfolioDetailList
            };

            return View(viewModel);
        }
    }
}


