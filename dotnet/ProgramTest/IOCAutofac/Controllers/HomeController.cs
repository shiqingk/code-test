using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IOCAutofac.Models;
using IOCAutofac.IServices;
using IOCAutofac.Services;

namespace IOCAutofac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseServices<User> _testServices1;
        private readonly ITestServices _testServices2;

        public HomeController(ILogger<HomeController> logger, IBaseServices<User> testServices, ITestServices testServices2)
        {
            _logger = logger;
            _testServices1 = testServices;
            _testServices2 = testServices2;
        }

        public IActionResult Index()
        {
            var t = _testServices1.Find("id");
            var aa = _testServices2.sum(100, 500);

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
