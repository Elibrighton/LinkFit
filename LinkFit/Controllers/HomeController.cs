using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkFit.Models;
//using Microsoft.Extensions.Options;
//using LinkFit.Services;

namespace LinkFit.Controllers
{
    public class HomeController : Controller
    {
        //private readonly AuthMessageSenderOptions _optionsAccessor;

        //public HomeController(IOptions<AuthMessageSenderOptions> optionsAccessor)
        //{
        //    _optionsAccessor = optionsAccessor.Value;
        //}

        public IActionResult Index()
        {
            //var sendGridKey = _optionsAccessor.SendGridKey;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
