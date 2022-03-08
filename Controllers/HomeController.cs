using DropDownApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DropDownApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCountries()
        {
            var countries = dbContext.Countries.ToList();
            return Json(countries);
        }
        public IActionResult GetStates(int id)
        {
            var states = dbContext.States.Where(e => e.Country.Id == id);
            return Json(states);
        }
        public IActionResult GetCities(int id)
        {
            var cities = dbContext.Cities.Where(e => e.State.Id == id);
            return Json(cities);
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
