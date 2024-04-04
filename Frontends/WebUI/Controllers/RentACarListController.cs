using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class RentACarListController : Controller
	{
		public IActionResult Index()
		{
			var pickDate = TempData["bookpickdate"];
			var offDate = TempData["bookoffdate"];
			var pickTime = TempData["timepick"];
			var offTime = TempData["timeoff"];
			var locationID = TempData["locationID"];

			ViewBag.pickDate = pickDate;
			ViewBag.offDate = offDate;
			ViewBag.pickTime = pickTime;
			ViewBag.offTime = offTime;
			ViewBag.locationID = locationID;
			return View();
		}
	}
}
