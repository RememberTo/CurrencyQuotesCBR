using Application.Infastructure.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ICurrencyRateDbContext _context;

        public CurrencyRepository(ICurrencyRateDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Currency> GetAllCurrency()
        {
            return _context.Currency.ToList();
        }

        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            return await _context.Currency.FindAsync(id);
        }

        public void Add(Currency currency)
        {
            _context.Currency.Add(currency);
            _context.SaveChanges();
        }

        public void Update(Currency entity)
        {
            _context.Currency.Update(entity);
            _context.SaveChanges();
        }

        public async Task<Currency> GetCurrencyByCharCode(string charCode)
        {
            return await _context.Currency.FirstOrDefaultAsync(c => c.CharCode == charCode);
        }
    }
}
