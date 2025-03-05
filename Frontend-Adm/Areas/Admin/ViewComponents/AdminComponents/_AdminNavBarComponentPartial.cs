using Microsoft.AspNetCore.Mvc;

namespace Admin.ViewComponents.AdminComponents
{
    public class _AdminNavBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
