using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OwlApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwlApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OwlAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OwlAppContext>>()))
            {
                // Look for any assets.
                if (context.Asset.Any())
                {
                    return;   // DB has been seeded
                }

                context.Asset.AddRange(
                    new Asset
                    {
                        AssetName = "LTC/USD",
                        UpdateTime = DateTime.Parse("2021-4-08"),
                        Market = "Crypto",
                        RealStrike = 1.2M
                    },

                    new Asset
                    {
                        AssetName = "XRP/USD",
                        UpdateTime = DateTime.Parse("2021-4-08"),
                        Market = "Crypto",
                        RealStrike= 1.2M
                    },

                    new Asset
                    {
                        AssetName = "XRP/USD",
                        UpdateTime = DateTime.Parse("2021-4-08"),
                        Market = "Index",
                        RealStrike = 8.8M
                    },

                    new Asset
                    {
                        AssetName = "Gold",
                        UpdateTime = DateTime.Parse("2021-4-08"),
                        Market= "Commodity",
                        RealStrike = 5.9M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
