using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}