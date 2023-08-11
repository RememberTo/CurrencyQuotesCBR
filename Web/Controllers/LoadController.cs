using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LoadController : Controller
    {
        private readonly ICurrencyRateLoaderService _currencyRateService;

        public LoadController(ICurrencyRateLoaderService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoadQuotes(DateRangeModel dateModel)
        {
            try
            {
                _currencyRateService.SaveAvailableCurrencyRate(dateModel.StartDate, dateModel.EndDate);

                TempData["SuccessMessage"] = "Котировки успешно загружены";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Произошла ошибка при загрузке котировок";
            }

            return RedirectToAction("Index");
        }
    }
}