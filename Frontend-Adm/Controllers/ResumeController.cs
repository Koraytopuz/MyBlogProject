using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using Newtonsoft.Json;

namespace Frontend_Adm.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ResumeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // About verilerini al
            var aboutResponse = await client.GetAsync("http://localhost:5276/api/About");
            var aboutList = new List<AboutDto>();
            if (aboutResponse.IsSuccessStatusCode)
            {
                var aboutJsonData = await aboutResponse.Content.ReadAsStringAsync();
                aboutList = JsonConvert.DeserializeObject<List<AboutDto>>(aboutJsonData);
            }
            return View(aboutList);
        }
        
    }
}