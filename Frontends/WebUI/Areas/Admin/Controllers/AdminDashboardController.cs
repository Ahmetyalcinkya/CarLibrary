using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/AdminDashboard")]
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
