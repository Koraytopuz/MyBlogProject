using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;
using Newtonsoft.Json;
using System.Text;

namespace Frontend_Adm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPortfolioController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPortfolioController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5276/api/Portfolio");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPortfolioDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5276/api/Portfolio/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultPortfolioDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(ResultPortfolioDto PortfolioDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(PortfolioDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"http://localhost:5276/api/Portfolio/{PortfolioDto.PortfolioId}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(PortfolioDto);
        }

        public async Task<IActionResult> CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolio(ResultPortfolioDto PortfolioDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(PortfolioDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5276/api/Portfolio", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(PortfolioDto);
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5276/api/Portfolio/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}