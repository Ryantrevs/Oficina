using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OficinaTcc.MailService;
using OficinaTcc.Models;

namespace OficinaTcc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Envio mailService = new Envio();
            Envio.
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
