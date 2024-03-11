using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
