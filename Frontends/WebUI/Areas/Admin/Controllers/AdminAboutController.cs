using Dto.AboutDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/AdminAbout")]
    [Area("Admin")]
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAbout)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAbout);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Abouts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Abouts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAbout)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAbout);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7199/api/Abouts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveAbout/{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7199/api/Abouts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            return View();
        }
    }
}
