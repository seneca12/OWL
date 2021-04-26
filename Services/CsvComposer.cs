using System.Collections.Generic;
using System.Linq;
using OwlApp.Models;


namespace OwlApp.Services
{
    public static class CsvComposer
    {
        public static string RatesToCsv(this List<ExchangeRate> rates)
        {
            var columns = "Base, Target, Rate";
            var result = $"{columns}\n";

            if (rates != default && rates.Any())
            {
                rates.ForEach(r =>
                {
                    result += $"{r.Base}, {r.TargetCurrencyCode}, {r.Rate}\n";
                });
            }
            
            return result;
        }
    }
}