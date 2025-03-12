using Frontend_Adm.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using MyBlogProject.WebApı.Dtos.SkillDtos;
using Newtonsoft.Json; // Add this using directive
namespace Frontend_Adm.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
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

            // Skill verilerini al
            var skillResponse = await client.GetAsync("http://localhost:5276/api/Skill");
            var skillList = new List<ResultSkillDto>();
            if (skillResponse.IsSuccessStatusCode)
            {
                var skillJsonData = await skillResponse.Content.ReadAsStringAsync();
                skillList = JsonConvert.DeserializeObject<List<ResultSkillDto>>(skillJsonData);
            }

            // ViewModel oluştur ve verileri ekle
            AboutViewModel viewModel = new AboutViewModel
            {
                AboutList = aboutList,
                SkillList = skillList
            };

            return View(viewModel);
        }
    }
}
