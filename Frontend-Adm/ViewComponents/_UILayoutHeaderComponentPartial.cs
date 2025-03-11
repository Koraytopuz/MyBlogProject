using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.ViewComponents
{
    public class _UILayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
