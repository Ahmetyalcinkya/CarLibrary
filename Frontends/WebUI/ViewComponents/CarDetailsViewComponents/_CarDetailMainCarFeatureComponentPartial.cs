using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke() 
        {
            return View(); 
        }
    }
}
