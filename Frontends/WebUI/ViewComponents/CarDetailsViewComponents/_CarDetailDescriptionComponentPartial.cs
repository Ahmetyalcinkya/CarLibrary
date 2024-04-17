using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
