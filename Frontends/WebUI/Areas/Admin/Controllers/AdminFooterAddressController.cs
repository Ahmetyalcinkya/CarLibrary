using Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/AdminFooterAddress")]
    [Area("Admin")]
    public class AdminFooterAddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminFooterAddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/FooterAddresses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateFooterAddress")]
        public IActionResult CreateFooterAddress()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddress)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFooterAddress);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/FooterAddresses", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/FooterAddresses/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddress)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFooterAddress);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7199/api/FooterAddresses/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveFooterAddress/{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7199/api/FooterAddresses?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
            }
            return View();
        }
    }
}
