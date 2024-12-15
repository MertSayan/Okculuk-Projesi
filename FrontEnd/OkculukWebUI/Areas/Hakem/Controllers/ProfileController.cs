using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OkculukWebUI.Areas.Hakem.Controllers
{
    [Area("Hakem")]
    [Route("Hakem/Profile")]
    public class ProfileController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.UserId = userIdClaim.Value;

            return View();
        }
    }
}
