using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Areas.Hakem.Controllers
{
    [Area("Hakem")]
    [Route("Hakem/HakemLayout")]
    public class HakemLayoutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
