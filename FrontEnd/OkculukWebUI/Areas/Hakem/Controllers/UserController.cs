using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Areas.Hakem.Controllers
{
    [Area("Hakem")]
    [Route("Hakem/User")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
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
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("");

            return View();
        }
    }
}
