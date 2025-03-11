using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.ViewComponents
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
