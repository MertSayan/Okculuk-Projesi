using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;
using OkculukDto.VisibleEventDtos;
using System.Security.Claims;
using System.Text;

namespace OkculukWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminEvent")]
    [Authorize(Roles = "Admin")]
    public class AdminEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=10)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Events/GetPagedEvent?pageNumber={pageNumber}&pageSize={pageSize}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultPagedEvents>>(jsonData);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            ViewBag.EventId=id;
            return View();
        }


        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Events/ById?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<AdminUpdateEvent>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(AdminUpdateEvent updateEvent)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateEvent);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7082/api/Events", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminEvent", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var createEventUserClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.createEventUserId = createEventUserClaim.Value;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AdminCreateEvent createEvent)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createEvent);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/Events",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminEvent", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("CreateVisibleEvent/{regionName=null}")]
        public IActionResult CreateVisibleEvent(string regionName=null)
        {
            ViewBag.RegionName = regionName;
            return View();
        }
        [HttpPost]
        [Route("CreateVisibleEvent/{id=0}")]
        public async Task<IActionResult> CreateVisibleEvent(CreateVisibleEvent createVisibleEvent)
        {
            // UserId'leri içeren modeli API'ye gönderiyoruz
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createVisibleEvent);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7082/api/VisibleEvents", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminEvent", new { area = "Admin" });
            }

            // Eğer hata alırsak, View'e geri dönüyoruz
            return View(createVisibleEvent);
        }


        [HttpGet]
        [Route("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7082/api/Events?id="+id);
            if(responseMessage.IsSuccessStatusCode )
            {
                return RedirectToAction("Index", "AdminEvent", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("AcceptOrRejectEvent")]
        public async Task<IActionResult> AcceptOrRejectEvent()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Events/GetAllPendingEventForAdmin");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<AdminChangeEventUserStatus>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpPost]
        [Route("AcceptOrRejectEvent")]
        public async Task<IActionResult> AcceptOrRejectEvent(AdminChangeEventUserStatus statusChange)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(statusChange);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7082/api/EventUsers", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AcceptOrRejectEvent", "AdminEvent", new { area = "Admin" });
            }
            return View();

        }
    }
}
