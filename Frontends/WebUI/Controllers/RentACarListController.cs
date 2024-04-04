using Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace WebUI.Controllers
{
	public class RentACarListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public RentACarListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(FilterRentACarDto dto)
		{
			var pickDate = TempData["bookpickdate"];
			var offDate = TempData["bookoffdate"];
			var pickTime = TempData["timepick"];
			var offTime = TempData["timeoff"];
			var locationID = TempData["locationID"];

			dto.LocationID = int.Parse(locationID.ToString());
			dto.isAvailable = true;

			ViewBag.pickDate = pickDate;
			ViewBag.offDate = offDate;
			ViewBag.pickTime = pickTime;
			ViewBag.offTime = offTime;
			ViewBag.locationID = locationID;

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7199/api/RentACars?locationID={dto.LocationID}&isAvailable={dto.isAvailable}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFilterRentACarDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
