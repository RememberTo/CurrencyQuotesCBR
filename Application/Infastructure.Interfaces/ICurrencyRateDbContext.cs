using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Infastructure.Interfaces
{
    public interface ICurrencyRateDbContext
    {
        DbSet<Currency> Currency { get; set; }
        DbSet<Rate> Rate { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
