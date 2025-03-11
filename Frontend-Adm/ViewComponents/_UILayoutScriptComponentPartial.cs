using Microsoft.AspNetCore.Mvc;

namespace Frontend_Adm.ViewComponents
{
    public class _UILayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
