using Microsoft.AspNetCore.Mvc;

namespace Admin.ViewComponents.AdminComponents
{
    public class _AdminHomePageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
