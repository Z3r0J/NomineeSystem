﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Controllers
{
    public class PayrollsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}