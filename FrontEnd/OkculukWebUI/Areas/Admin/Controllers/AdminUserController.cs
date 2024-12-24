using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.UserDtos;
using System.Text;

namespace OkculukWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminUser")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 3)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Users/GetPagedUser?PageNumber={pageNumber}&PageSize={pageSize}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var users=JsonConvert.DeserializeObject<List<ResultPagedUser>>(jsonData);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                return View(users);
            }
            return View();
        }
        [HttpGet]
        [Route("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            ViewBag.UserId=id;
            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Users/ByIdForAdmin?id="+id);
            if(responseMessage.IsSuccessStatusCode )
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<AdminUpdateUser>(jsonData);
                return View(value);
            }

            return View();
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(AdminUpdateUser updateUser)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateUser);
            StringContent stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7082/api/Users/UpdateForAdmin",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminUser", new { area = "Admin" });
            }
            return View();
        }

        [Route("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7082/api/Users?id="+id);
            if(responseMessage.IsSuccessStatusCode )
            {
                return RedirectToAction("Index", "AdminUser", new { area = "Admin" });
            }
            return View();
        }
    }
}
