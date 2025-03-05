using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
