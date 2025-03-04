using Microsoft.AspNetCore.Mvc;

namespace Admin.ViewComponents.AdminComponents
{
    public class _AdminFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
