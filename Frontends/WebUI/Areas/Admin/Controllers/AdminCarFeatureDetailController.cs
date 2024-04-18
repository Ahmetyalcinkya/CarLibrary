using Dto.CarFeatureDtos;
using Dto.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> dtos)
        {
            foreach (var item in dtos)
            {
                if (item.isAvailable)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7199/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);

                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7199/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [Route("CreateFeatureByCarID")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarID()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
