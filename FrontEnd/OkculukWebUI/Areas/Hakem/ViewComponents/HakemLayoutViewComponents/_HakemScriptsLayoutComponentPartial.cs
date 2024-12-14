using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Areas.Hakem.ViewComponents.HakemLayoutViewComponents
{
    public class _HakemScriptsLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
