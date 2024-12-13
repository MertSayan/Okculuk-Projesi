﻿using Microsoft.AspNetCore.Mvc;

namespace OkculukWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminMain")]
    public class AdminMainController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
