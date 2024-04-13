using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardChartThreeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardChartThreeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
