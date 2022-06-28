using CreditCalculator.Data;
using CreditCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreditCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CreditCalculatorContext _context;

        public HomeController(ILogger<HomeController> logger, CreditCalculatorContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreditCalculation model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.CreateSchedule();
            _context.CreditCalculations.Add(model);

            return RedirectToAction(nameof(Privacy));
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