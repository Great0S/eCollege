﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;

namespace eCollege.Controllers
{
    public class HomeController : Controller
    {
    private readonly IHostingEnvironment _hostEnvironment;
    public HomeController(IHostingEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Event()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Report()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult GetReport()
        {
            var reportpath = _hostEnvironment.WebRootPath + "\\wwwroot\reports";
            return StiNetCoreDesigner.GetReportResult(this, reportpath);
        }
        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }

        public IActionResult Error()
        {
            return View();
        }

        
    }
}
