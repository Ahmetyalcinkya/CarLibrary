using Dto.AuthorDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/AdminAuthor")]
    [Area("Admin")]
    public class AdminAuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminAuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Authors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateAuthor")]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthor)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAuthor);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Authors", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Authors/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthor)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAuthor);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7199/api/Authors/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7199/api/Authors?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            return View();
        }
    }
}
