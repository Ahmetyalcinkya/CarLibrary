using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailTabPaneComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
