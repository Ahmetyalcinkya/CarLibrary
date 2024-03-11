using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCategoryViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
