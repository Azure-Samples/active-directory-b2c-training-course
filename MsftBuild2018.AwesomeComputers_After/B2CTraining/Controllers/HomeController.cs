﻿using Microsoft.AspNetCore.Mvc;

namespace B2CTraining.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
