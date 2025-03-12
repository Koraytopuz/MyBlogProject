using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.Controllers
{
    public class HeroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
