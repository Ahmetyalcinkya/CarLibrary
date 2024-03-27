using Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Route("Admin/AdminBlog")]
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Blogs/GetAllBlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateBlog")]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlog)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBlog);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Blogs", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateBlog/{id}")]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateBlog/{id}")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlog)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlog);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7199/api/Blogs/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7199/api/Blogs?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return View();
        }
    }
}
