using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class RatesController : Controller
    {
        private readonly IRateService _rateService;

        public RatesController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> RatesByDate(DateTime selectedDate)
        {
            if(selectedDate == default(DateTime)) return View();

            var rates = await _rateService.GetRatesByDateAsync(selectedDate);
            return View(new RatesByDateViewModel { SelectedDate = selectedDate, Rates = rates});
        }

        [HttpGet]
        public async Task<IActionResult> RatesByCurrency(string selectedCurrency)
        {
            var currencies = _rateService.GetCurrencies().ToList();

            if (!string.IsNullOrEmpty(selectedCurrency))
            {
                var rates = await _rateService.GetRatesByCurrencyAsync(selectedCurrency);
                return View(new RatesByCurrencyViewModel
                {
                    SelectedCurrency = selectedCurrency,
                    Currencies = currencies,
                    Rates = rates
                });
            }
            
            return View(new RatesByCurrencyViewModel { Currencies = currencies});
        }
    }
}
