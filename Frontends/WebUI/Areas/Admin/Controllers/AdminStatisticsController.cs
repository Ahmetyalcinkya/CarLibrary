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

            #region GetBrandCount
            var responseMessage5 = await client.GetAsync("https://localhost:7199/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.brandCount = values.BrandCount;
                ViewBag.brandCountNumber = randomNum;
            }
            #endregion

            #region GetCarsAverageHourlyPrice
            var responseMessage6 = await client.GetAsync("https://localhost:7199/api/Statistics/GetCarsAverageHourlyPrice");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.averageHourlyPrice = values.AverageHourlyPrice.ToString("0.##");
                ViewBag.averageHourlyPriceNumber = randomNum;
            }
            #endregion

            #region GetCarsAverageDailyPrice
            var responseMessage7 = await client.GetAsync("https://localhost:7199/api/Statistics/GetCarsAverageDailyPrice");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage7.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.averageDailyPrice = values.AverageDailyPrice.ToString("0.##");
                ViewBag.averageDailyPriceNumber = randomNum;
            }
            #endregion

            #region GetCarsAverageWeeklyPrice
            var responseMessage8 = await client.GetAsync("https://localhost:7199/api/Statistics/GetCarsAverageWeeklyPrice");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage8.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.averageWeeklyPrice = values.AverageWeeklyPrice.ToString("0.##");
                ViewBag.averageWeeklyPriceNumber = randomNum;
            }
            #endregion

            #region GetCarsAverageMonthlyPrice
            var responseMessage9 = await client.GetAsync("https://localhost:7199/api/Statistics/GetCarsAverageMonthlyPrice");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage9.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.averageMonthlyPrice = values.AverageMonthlyPrice.ToString("0.##");
                ViewBag.averageMonthlyPriceNumber = randomNum;
            }
            #endregion
            return View();
        }
    }
}
