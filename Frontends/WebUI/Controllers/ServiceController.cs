﻿using Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
