using Application.Infastructure.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class CurrencyRateDbContext : DbContext, ICurrencyRateDbContext
    {
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public CurrencyRateDbContext(DbContextOptions<CurrencyRateDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Currency)
                .WithMany()
                .HasForeignKey(r => r.CurrencyId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
