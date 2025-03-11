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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResultContactDto resultContactDto)
        {
            if (!ModelState.IsValid)
            {
                return View(resultContactDto);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5276/api/Contact", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                ViewData["SuccessMessage"] = "Mesajınız Başarıyla Gönderildi.Teşekkürler!";
                return View();
            }

            ModelState.AddModelError(string.Empty, "Mesaj gönderilirken bir hata oluştu. Lütfen tekrar deneyin.");
            return View(resultContactDto);
        }
    }
}
