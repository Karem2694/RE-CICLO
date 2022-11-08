using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecicloPortal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecicloPortal.Controllers
{
    public class ResgateController : Controller
    {
        private readonly ILogger<ResgateController> _logger;

        public ResgateController(ILogger<ResgateController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
