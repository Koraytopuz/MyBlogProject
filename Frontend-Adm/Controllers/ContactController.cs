using Frontend_Adm.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.WebApı.Dtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;

namespace Frontend_Adm.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new AboutViewModel
            {
                ResultContacts = new List<ResultContactDto>
        {
            new ResultContactDto() // Form alanlarını göstermek için boş bir nesne ekleyin
        }
                // Diğer özellikleri de gerektiği gibi başlatın
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResultContactDto resultContactDto)
        {
            if (!ModelState.IsValid)
            {
                var model = new AboutViewModel
                {
                    ResultContacts = new List<ResultContactDto> { resultContactDto }
                    // Diğer özellikleri de gerektiği gibi başlatın
                };
                return View(model);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5276/api/Contact", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                ViewData["SuccessMessage"] = "Mesajınız Başarıyla Gönderildi.Teşekkürler!";
                var model = new AboutViewModel
                {
                    ResultContacts = new List<ResultContactDto>
            {
                new ResultContactDto() // Form alanlarını göstermek için boş bir nesne ekleyin
            }
                    // Diğer özellikleri de gerektiği gibi başlatın
                };
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Mesaj gönderilirken bir hata oluştu. Lütfen tekrar deneyin.");
            var errorModel = new AboutViewModel
            {
                ResultContacts = new List<ResultContactDto> { resultContactDto }
                // Diğer özellikleri de gerektiği gibi başlatın
            };
            return View(errorModel);
        }

    }
}
