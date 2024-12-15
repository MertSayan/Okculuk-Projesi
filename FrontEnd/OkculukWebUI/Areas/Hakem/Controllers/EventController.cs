using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;
using OkculukDto.UserEventDtos;
using System.Security.Claims;
using System.Text;

namespace OkculukWebUI.Areas.Hakem.Controllers
{
    [Area("Hakem")]
    [Route("Hakem/Event")]
    public class EventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Events")]
        public async Task<IActionResult> Events()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.UserId = userIdClaim.Value;
            return View();
        }

 
        [Route("EventDetails/{id}")]
        [HttpGet]
        public async Task<IActionResult> EventDetails(int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.UserId = userIdClaim.Value;
            var userid=userIdClaim.Value;
            ViewBag.EventId = id;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Events/GetAvailableEventsByUserId?userId="+userid);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var availableEvents=JsonConvert.DeserializeObject<List<ResultAvailableEventsForUser>>(jsonData);

                // Eğer kullanıcı etkinlik için istekte bulunmamışsa true dönüyoruz
                bool isAlreadyRequested =!availableEvents.Any(x=>x.EventId == id);

                ViewBag.IsAlreadyRequested = isAlreadyRequested; //true döndük
            }
            else
            {
                ViewBag.IsAlreadyRequested = false;
            }



            return View();
        }
        [Route("EventDetails/{id}")]
        [HttpPost]
        public async Task<IActionResult> EventDetails(CreateUserEvent createUserEvent)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createUserEvent);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/EventUsers", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Events", "Event", new { area = "Hakem" });
            }
            
            return View();
        }

        [Route("PendingEvents")]
        [HttpGet]
        public async Task<IActionResult> PendingEvents()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var id = userIdClaim.Value;

            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Events/GetEventsByUserIdStatus?userId={id}&status=Pending");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEventsByStatusForUser>>(jsonData);
                return View(values);
            }

            return View();
        }

    }
}
