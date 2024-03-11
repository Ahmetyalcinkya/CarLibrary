using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.CommentViewComponents
{
    public class _AddCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
