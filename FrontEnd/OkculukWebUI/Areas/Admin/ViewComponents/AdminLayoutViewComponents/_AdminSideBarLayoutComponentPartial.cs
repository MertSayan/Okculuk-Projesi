using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminSideBarLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
