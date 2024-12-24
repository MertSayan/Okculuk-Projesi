using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OkculukWebUI.Controllers
{
    public class DenemeController : Controller
    {
        private readonly HttpClient _httpClient;

        public DenemeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 3)
        {
            string apiUrl = $"https://localhost:7082/api/Users/GetPagedUser?PageNumber={pageNumber}&PageSize={pageSize}";

            var response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Veriler alınırken bir hata oluştu.";
                return View();
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserDto>>(jsonData);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;

            return View(users);
        }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string RegionName { get; set; }
        public string InstitutionName { get; set; }
    }
}
