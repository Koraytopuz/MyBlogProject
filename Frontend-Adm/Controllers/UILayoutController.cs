using Frontend_Adm.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using MyBlogProject.WebApı.Dtos.CommentDtos;
using MyBlogProject.WebApı.Dtos.ContactDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDetailDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;
using MyBlogProject.WebApı.Dtos.PostDtos;
using MyBlogProject.WebApı.Dtos.SkillDtos;
using MyBlogProject.WebApı.Dtos.SocialMediaDtos;
using MyBlogProject.WebApı.Dtos.ToDoListDtos;
using MyBlogProject.WebApı.Dtos.UserDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace Frontend_Adm.Controllers
{
    public class UILayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UILayoutController(IHttpClientFactory httpClientFactory)
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
                SkillList = skillList,
                ToDoLists = new List<ToDoListDto>(),
                Users = new List<UserDto>(),
                Comments = new List<CommentDto>(),
                Posts = new List<PostDto>(),
                PortfolioDetailList = new List<ResultPortfolioDetailDto>(),
                PortfolioList = new List<ResultPortfolioDto>(),
                ResultContacts = new List<ResultContactDto>(),
                SocialMedias = new List<SocialMediaDto>(),
            };

            return View(viewModel);
        }
    }
}