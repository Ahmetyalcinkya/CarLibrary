using Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
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
			return View();
		}
	}
}
