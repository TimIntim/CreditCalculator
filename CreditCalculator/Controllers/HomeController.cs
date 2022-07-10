using CreditCalculator.Data;
using CreditCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace CreditCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CreditCalculatorContext _db;

        public HomeController(ILogger<HomeController> logger, CreditCalculatorContext db)
        {
            _logger = logger;
            _db = db;
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

            try
            {
                model.CreateSchedule();
                _db.CreditCalculations.Add(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            
            {
                _logger.Log(LogLevel.Error, e.Message);
                _logger.Log(LogLevel.Error, e.InnerException?.Message);
                return View("Error");
            }

            return RedirectToAction(nameof(Privacy), routeValues: new {id = model.Id});
        }

        public IActionResult Privacy(int? id)
        {
            if (id == null)
                // return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            {
                return new BadRequestResult();
            }
            var calculation = _db.CreditCalculations
                .Include(c => c.Payments)
                .FirstOrDefault(c => c.Id == id);
            if (calculation == null)
            {
                return new NotFoundResult();
            }

            return View(calculation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}