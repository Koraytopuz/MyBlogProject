using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.PortfolioDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace Frontend_Adm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPortfolioDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPortfolioDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5276/api/PortfolioDetail");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPortfolioDetailDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePortfolioDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5276/api/PortfolioDetail/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultPortfolioDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePortfolioDetail(ResultPortfolioDetailDto PortfolioDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(PortfolioDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"http://localhost:5276/api/PortfolioDetail/{PortfolioDetailDto.Id}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(PortfolioDetailDto);
        }

        public async Task<IActionResult> CreatePortfolioDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolioDetail(ResultPortfolioDetailDto PortfolioDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(PortfolioDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5276/api/PortfolioDetail", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(PortfolioDetailDto);
        }

        public async Task<IActionResult> DeletePortfolioDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5276/api/PortfolioDetail/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
