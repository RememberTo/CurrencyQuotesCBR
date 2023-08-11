using Application.Infastructure.Interfaces.Base;
using Domain.Entities;

namespace Application.Infastructure.Interfaces
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        IEnumerable<Currency> GetAllCurrency();
        Task<Currency> GetCurrencyByCharCode(string charCode);
        Task<Currency> GetCurrencyByIdAsync(int id);

    }
}
