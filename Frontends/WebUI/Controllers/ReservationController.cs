using Dto.LocationDtos;
using Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Rent the Car";
            ViewBag.v2 = "Reservation form for the Car Rental";
            ViewBag.v3 = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> ddvalues = (from x in values
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.LocationID.ToString(),
                                             }).ToList();
            ViewBag.ddvalues = ddvalues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservation)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservation);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Reservations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // Kullanıcıya email gönderildiğine dair bir mesaj ekranı eklenebilir!!! İlerleyen dönemde kontrol et!
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
