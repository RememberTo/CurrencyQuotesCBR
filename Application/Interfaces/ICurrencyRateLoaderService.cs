namespace Application.Interfaces
{
    public interface ICurrencyRateLoaderService
    {
        void SaveAvailableCurrencyRate(DateTime? startDate, DateTime? endDate);
    }
}
