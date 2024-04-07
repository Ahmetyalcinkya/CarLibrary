using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Pricings";
            ViewBag.v2 = "Choose a Car Pricing";
            return View();
        }
    }
}
