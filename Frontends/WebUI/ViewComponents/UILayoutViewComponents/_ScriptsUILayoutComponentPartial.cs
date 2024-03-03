using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptsUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
