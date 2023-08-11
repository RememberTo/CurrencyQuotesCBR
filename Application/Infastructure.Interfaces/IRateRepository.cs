using Application.Infastructure.Interfaces.Base;
using Domain.Entities;

namespace Application.Infastructure.Interfaces
{
    public interface IRateRepository : IRepository<Rate>
    {
        Task<IEnumerable<Rate>> GetRatesByDateAsync(DateTime date);
        Task<IEnumerable<Rate>> GetRatesByCurrencyIdAsync(int currencyId);
        Rate GetRateByCurrencyAndDate(int currencyId, DateTime date);
    }
}
