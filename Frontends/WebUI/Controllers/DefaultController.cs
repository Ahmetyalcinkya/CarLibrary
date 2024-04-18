using Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebUI.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
            var token = User.Claims.FirstOrDefault(x => x.Type == "carlibrarytoken")?.Value;

			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var responseMessage = await client.GetAsync("https://localhost:7199/api/Locations");

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
				List<SelectListItem> ddvalues = (from x in values
												 select new SelectListItem
												 {
													 Text = x.Name,
													 Value = x.LocationID.ToString(),
												 }).ToList();
				ViewBag.ddvalues = ddvalues;
			}
			return View();
		}

		[HttpPost]
		public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, int locationID)
		{
			TempData["bookpickdate"] = book_pick_date;
			TempData["bookoffdate"] = book_off_date;
			TempData["timepick"] = time_pick;
			TempData["timeoff"] = time_off;
			TempData["locationID"] = locationID;
			return RedirectToAction("Index", "RentACarList");
		}
	}
}
