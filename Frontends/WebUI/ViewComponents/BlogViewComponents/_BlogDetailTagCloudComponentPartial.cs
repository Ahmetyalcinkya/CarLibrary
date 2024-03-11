using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailTagCloudComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
