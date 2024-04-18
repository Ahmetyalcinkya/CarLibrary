using Dto.BrandDtos;
using Dto.CarDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Cars/GetCarsWithBrandName");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brandValues =  (from value in values
                                                 select new SelectListItem
                                                 {
                                                     Text = value.Name,
                                                     Value = value.BrandID.ToString()
                                                 }).ToList();
            ViewBag.BrandValues = brandValues;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var getResponseMessage = await client.GetAsync("https://localhost:7199/api/Brands");
            var getJsonData = await getResponseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(getJsonData);
            List<SelectListItem> brandValues = (from value in values
                                                select new SelectListItem
                                                {
                                                    Text = value.Name,
                                                    Value = value.BrandID.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;

            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Cars/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCar) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCar);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Cars", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCar)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCar);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7199/api/Cars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7199/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
