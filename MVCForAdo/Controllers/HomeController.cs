using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCForAdo.Models;

namespace MVCForAdo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IADOService _adoservice;

        public HomeController(IADOService adoservice)
        {
            _adoservice = adoservice;
        }

        public IActionResult Index()
        {
            var data = _adoservice.getqueryFromStoredProcedure(2, 5);
            return null;
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
