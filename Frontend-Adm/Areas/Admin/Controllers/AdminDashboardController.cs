using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

    }
}
