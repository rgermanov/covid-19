using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Germanov.Covid19.Website.Models;
using Germanov.Covid19.Website.Interfaces;

namespace Germanov.Covid19.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICovidDailyStatsService _covidService;

        public HomeController(ILogger<HomeController> logger, ICovidDailyStatsService covidDailyStatsService)
        {
            _logger = logger;
            _covidService = covidDailyStatsService;
        }

        public IActionResult Index()
        {            
            var stats = _covidService.GetStats().ToList();

            var viewModel = new HomePageViewMode()
            {
                CovidInfo = stats,
                GermanyLastUpdate = GetConfirmedCasesByCountry("Germany", stats),
                BulgariaLastUpdate = GetConfirmedCasesByCountry("Bulgaria", stats),
                BelgiumLastUpdate = GetConfirmedCasesByCountry("Belgium", stats)
            };
            
            return View(viewModel);
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

        private CovidInfoModel GetConfirmedCasesByCountry(string countryName, IEnumerable<CovidInfoModel> stats)
        {
            return stats
                        .Where(item => item.Country == countryName)
                        .OrderBy(item => item.Date)
                        .Last();
        }
    }
}
