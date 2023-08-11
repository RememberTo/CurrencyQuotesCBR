namespace Application.Interfaces
{
    public interface IRateService
    {
        Task<List<СurrencyRateModel>> GetRatesByDateAsync(DateTime selectedDate);
        Task<List<СurrencyRateModel>> GetRatesByCurrencyAsync(string charCode);
        IEnumerable<string> GetCurrencies();
    }
}
