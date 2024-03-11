using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudTagByBlogComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View(); 
        }
    }
}
