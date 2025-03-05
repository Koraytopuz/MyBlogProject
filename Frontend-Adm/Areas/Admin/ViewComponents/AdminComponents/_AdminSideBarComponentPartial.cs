using Microsoft.AspNetCore.Mvc;

namespace Admin.ViewComponents.AdminComponents
{
    public class _AdminSideBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
