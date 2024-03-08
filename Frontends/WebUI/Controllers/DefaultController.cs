using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
