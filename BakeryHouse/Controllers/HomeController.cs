using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BakeryHouse.Models;
using System.Security.Claims;
using BakeryHouse.Data;
using BakeryHouse.ViewModels;

namespace BakeryHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BakeryHouseContext _context;

        public HomeController(ILogger<HomeController> logger, BakeryHouseContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            LoginPartialViewModel viewModel = new LoginPartialViewModel
            {
                klant = klant
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Taart()
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
