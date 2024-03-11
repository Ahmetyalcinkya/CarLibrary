using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
