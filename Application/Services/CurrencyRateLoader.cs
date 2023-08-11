using Application.Common;
using Application.Infastructure.Interfaces;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class CurrencyRateLoader : ICurrencyRateLoaderService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IRateRepository _rateRepository;
        private readonly HttpClient _httpClient;

        public CurrencyRateLoader(ICurrencyRepository currencyRepository, IRateRepository rateRepository)
        {
            _currencyRepository = currencyRepository;
            _rateRepository = rateRepository;
            _httpClient = new HttpClient();
        }

        public void SaveAvailableCurrencyRate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null || startDate > endDate)
                throw new ArgumentException("Invalid startDate or endDate");

            var existingCurrencies = _currencyRepository.GetAllCurrency().ToList();
            var availableCurrencies = GetAvailableCurrency();

            var missingCurrencies = availableCurrencies.Except(existingCurrencies, new CurrencyComparer()).ToList();

            foreach (var currency in missingCurrencies)
            {
                _currencyRepository.Add(currency);
            }

            var сurrencies = _currencyRepository.GetAllCurrency();

            foreach (var currency in сurrencies)
            {
                LoadExchangeRatesForCurrency(currency, startDate, endDate);
            }
        }

        private IEnumerable<Currency> GetAvailableCurrency()
        {
            var availableCurrencies = new List<Currency>();

            var apiUrl = $"http://www.cbr.ru/scripts/XML_valFull.asp";

            HttpResponseMessage response = _httpClient.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                availableCurrencies = XMLParser.ParseAvailableCurrencyFromXml(content).ToList();
            }

            return availableCurrencies;
        }
        private void LoadExchangeRatesForCurrency(Currency currency, DateTime? startDate, DateTime? endDate)
        {
            var apiUrl = $"http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1={startDate:dd/MM/yyyy}&date_req2={endDate:dd/MM/yyyy}&VAL_NM_RQ={currency.ID}";
            HttpResponseMessage response = _httpClient.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var exchangeRates = XMLParser.ParseCurrencyRatesFromXml(content);

                foreach (var rate in exchangeRates)
                {
                    var existingRate = _rateRepository.GetRateByCurrencyAndDate(currency.CurrencyId, rate.Date);

                    if (existingRate != null)
                    {
                        existingRate.Nominal = rate.Nominal;
                        existingRate.Value = rate.Value;
                        _rateRepository.Update(existingRate);
                    }
                    else
                    {
                        rate.CurrencyId = currency.CurrencyId;
                        _rateRepository.Add(rate);
                    }
                }
            }
        }

    }
}
