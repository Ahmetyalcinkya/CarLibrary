using Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region GetCarCount
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
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

            #region GetCarsAverageDailyPrice
            var responseMessage4 = await client.GetAsync("https://localhost:7199/api/Statistics/GetCarsAverageDailyPrice");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int randomNum = random.Next(0, 101);
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.averageDailyPrice = values.AverageDailyPrice.ToString("0.##");
                ViewBag.averageDailyPriceNumber = randomNum;
            }
            #endregion

            return View();
        }
    }
}
