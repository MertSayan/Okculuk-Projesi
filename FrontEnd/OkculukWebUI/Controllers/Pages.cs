using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Controllers
{
    public class Pages : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
