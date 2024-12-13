﻿using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminLayout")]
    public class AdminLayoutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
