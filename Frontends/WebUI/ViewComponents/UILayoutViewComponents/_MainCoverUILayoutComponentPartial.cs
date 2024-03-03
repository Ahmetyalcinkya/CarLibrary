using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutViewComponents
{
    public class _MainCoverUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
