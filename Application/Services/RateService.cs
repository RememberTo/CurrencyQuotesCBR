using Application.Infastructure.Interfaces;
using Application.Interfaces;

namespace Application.Services
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public RateService(IRateRepository rateRepository, ICurrencyRepository currencyRepository)
        {
            _rateRepository = rateRepository;
            _currencyRepository = currencyRepository;
        }

        public async Task<List<СurrencyRateModel>> GetRatesByDateAsync(DateTime selectedDate)
        {
            var rates = await _rateRepository.GetRatesByDateAsync(selectedDate);

            var quoteViewModels = rates.Select(rate => new СurrencyRateModel
            {
                CurrencyCharCode = rate.Currency.CharCode,
                Value = rate.Value,
                Nominal = rate.Nominal
            }).ToList();

            return quoteViewModels;
        }

        public async Task<List<СurrencyRateModel>> GetRatesByCurrencyAsync(string charCode)
        {
            var currencyByCharCode = await _currencyRepository.GetCurrencyByCharCode(charCode);
            if (currencyByCharCode == null) return new List<СurrencyRateModel>();

            var rates = await _rateRepository.GetRatesByCurrencyIdAsync(currencyByCharCode.CurrencyId);
            if (rates == null) return new List<СurrencyRateModel>();

            var quoteViewModels = rates
                .OrderBy(rate => rate.Date)
                .Select(rate => new СurrencyRateModel
                {
                    CurrencyCharCode = rate.Currency.CharCode,
                    Value = rate.Value,
                    Date = rate.Date,
                    Nominal = rate.Nominal
                }).ToList();

            return quoteViewModels;
        }

        public IEnumerable<string> GetCurrencies()
        {
            var currencies = _currencyRepository.GetAllCurrency()
                .Select(x => x.CharCode).ToList();

            return currencies;
        }
    }
}
