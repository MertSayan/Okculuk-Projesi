using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;
using System.Text;

namespace OkculukWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminEvent")]
    public class AdminEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Events");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultAllEvent>>(jsonData);
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
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AdminCreateEvent createEvent)
        {
            //burası token işlemi yapıldıktan sonra halledilecek
            return View();
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
    }
}
