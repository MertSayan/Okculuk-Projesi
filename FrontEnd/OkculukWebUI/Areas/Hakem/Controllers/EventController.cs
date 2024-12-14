using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    }
}
