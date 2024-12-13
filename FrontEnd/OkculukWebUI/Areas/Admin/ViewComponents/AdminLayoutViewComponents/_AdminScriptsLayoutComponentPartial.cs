using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminScriptsLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
