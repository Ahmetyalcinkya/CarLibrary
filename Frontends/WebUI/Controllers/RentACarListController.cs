using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class RentACarListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
