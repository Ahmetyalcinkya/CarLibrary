using Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Route("Admin/AdminLocation")]
    [Area("Admin")]
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateLocation")]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocation)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocation);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Locations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Locations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocation)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocation);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7199/api/Locations/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7199/api/Locations?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
    }
}
