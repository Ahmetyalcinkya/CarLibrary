using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Rent the Car";
            ViewBag.v2 = "Reservation form for the Car Rental";
            return View();
        }
    }
}
