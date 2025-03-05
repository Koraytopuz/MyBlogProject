using Microsoft.AspNetCore.Mvc;

namespace Admin.ViewComponents.AdminComponents
{
    public class _AdminScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
