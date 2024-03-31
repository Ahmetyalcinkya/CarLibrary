using Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Route("Admin/AdminStatistics")]
    [Area("Admin")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region GetCarCount
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Statistics/GetCarCount");
            if(responseMessage.IsSuccessStatusCode) 
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.CarCount;
                ViewBag.carCountNumber = randomNum;
            }
            #endregion

            #region GetLocationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7199/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.locationCount = values.LocationCount;
                ViewBag.locationCountNumber = randomNum;
            }
            #endregion

            #region GetAuthorCount
            var responseMessage3 = await client.GetAsync("https://localhost:7199/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.authorCount = values.AuthorCount;
                ViewBag.authorCountNumber = randomNum;
            }
            #endregion

            #region GetBlogCount
            var responseMessage4 = await client.GetAsync("https://localhost:7199/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.blogCount = values.BlogCount;
                ViewBag.blogCountNumber = randomNum;
            }
            #endregion

            return View();
        }
    }
}
