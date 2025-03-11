using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.ViewComponents
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
