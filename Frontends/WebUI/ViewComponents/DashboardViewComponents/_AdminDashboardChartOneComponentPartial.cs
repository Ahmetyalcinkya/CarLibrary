using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardChartOneComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardChartOneComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
