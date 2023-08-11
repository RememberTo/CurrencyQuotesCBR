using Application.Infastructure.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly ICurrencyRateDbContext _context;

        public RateRepository(ICurrencyRateDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rate>> GetRatesByDateAsync(DateTime date)
        {
            return await _context.Rate
                .Include(r => r.Currency)
                .Where(r => r.Date == date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Rate>> GetRatesByCurrencyIdAsync(int currencyId)
        {
            return await _context.Rate
                .Include(r => r.Currency)
                .Where(r => r.CurrencyId == currencyId)
                .ToListAsync();
        }

        public Rate GetRateByCurrencyAndDate(int currencyId, DateTime date)
        {
            return _context.Rate
                .FirstOrDefault(rate => rate.CurrencyId == currencyId && rate.Date == date);
        }

        public void Add(Rate rate)
        {
            _context.Rate.Add(rate);
            _context.SaveChanges();
        }

        public void Update(Rate entity)
        {
            _context.Rate.Update(entity);
            _context.SaveChanges();
        }
    }
}
