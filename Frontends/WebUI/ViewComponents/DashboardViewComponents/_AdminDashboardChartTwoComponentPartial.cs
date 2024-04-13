using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardChartTwoComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardChartTwoComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
