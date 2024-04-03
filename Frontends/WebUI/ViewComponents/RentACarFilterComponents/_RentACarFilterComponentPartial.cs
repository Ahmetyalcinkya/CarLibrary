using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { 
            return View(); 
        }
    }
}
