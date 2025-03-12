using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;
using OkculukDto.GoogleFormDtos;
using System.Text;

namespace OkculukWebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/AdminMain")]
    [Authorize(Roles = "Admin")]
    public class AdminMainController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMainController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View();
        }


        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(CreateGoogleFormDto createGoogleFormDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGoogleFormDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/GoogleForms",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminMain", new { area = "Admin" });
            }
            return View();
        }

        [Route("Deneme")]
        [HttpPost]
        public async Task<IActionResult> Deneme(AdminChangeEventUserStatus statusChange)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(statusChange);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/EventUsers", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminMain", new { area = "Admin" });
            }
            return View();
        }



        //[Route("Index")]
        //[HttpPost]
        //public async Task<IActionResult> Index(CreateGoogleFormDto createGoogleFormDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createGoogleFormDto);
        //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7082/api/GoogleForms");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "AdminMain", new { area = "Admin" });
        //    }
        //    return View();
        //}
    }
}
