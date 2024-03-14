using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
