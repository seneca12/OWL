using Microsoft.EntityFrameworkCore;
using OwlApp.Models;

namespace OwlApp.Data
{
    public class OwlAppContext : DbContext
    {
        public OwlAppContext (DbContextOptions<OwlAppContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Asset { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
