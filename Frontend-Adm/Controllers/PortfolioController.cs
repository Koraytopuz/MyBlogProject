using Frontend_Adm.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

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
            var portfolioResponse = await client.GetAsync("http://localhost:5276/api/Portfolio");
            var portfolioList = new List<ResultPortfolioDto>();

            if (portfolioResponse.IsSuccessStatusCode)
            {
                var jsonData = await portfolioResponse.Content.ReadAsStringAsync();
                portfolioList = JsonConvert.DeserializeObject<List<ResultPortfolioDto>>(jsonData);
            }

            var viewModel = new PortfolioViewModel
            {
                PortfolioList = portfolioList
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5276/api/Portfolio/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var portfolio = JsonConvert.DeserializeObject<ResultPortfolioDto>(jsonData);

            return View(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResultPortfolioDto portfolio)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolio);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(portfolio);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5276/api/Portfolio/{portfolio.PortfolioId}", content);

            if (!response.IsSuccessStatusCode)
            {
                return View(portfolio);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

