using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<OwlApp.Models.Asset> Asset { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
