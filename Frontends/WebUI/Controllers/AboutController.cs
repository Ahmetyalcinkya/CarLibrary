using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
