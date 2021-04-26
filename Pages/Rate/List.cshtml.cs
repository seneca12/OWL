using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OwlApp.Data;
using OwlApp.Interfaces;
using OwlApp.Models;
using OwlApp.Services;

namespace OwlApp.Pages.Rate
{
    public class List : PageModel
    {
        private readonly IExchangeService _exchangeService;
        private readonly OwlAppContext context;

        public List<Currency> Currencies = new List<Currency>();
        public List<ExchangeRate> Rates = new List<ExchangeRate>();

        public List(IExchangeService exchangeService, OwlAppContext context)
        {
            _exchangeService = exchangeService;
            this.context = context;
        }
        
        public async Task OnGetAsync()
        {
            await RefreshData();
        }

        private async Task RefreshData()
        {
            Rates = await context.ExchangeRates.AsQueryable()
                .ToListAsync();

            Currencies = await context.Currencies.AsQueryable()
                .ToListAsync();
        }

        public async Task OnPostRefreshRatesAsync()
        {
            var exchange = await _exchangeService.GetExchangeRates("EUR",
                context.Currencies
                    .Where(x => x.Enabled)
                    .Select(x => x.Code)
                    .ToArray()); 

            var rates = exchange.Rates.Select(r =>
            {
                var (key, value) = r;
                var x = new ExchangeRate
                {
                    Base = exchange.Base,
                    Date = exchange.Date,
                    TargetCurrencyCode = key,
                    Rate = value
                };

                return x;
            });

            await context.AddRangeAsync(rates);
            await context.SaveChangesAsync();
            await RefreshData();
        }

        public async Task OnPostRefreshSymbolsAsync()
        {
            var symbols = await _exchangeService.GetExchangeSymbols();

            if (!symbols.Success)
            {
                throw new Exception(symbols.Error?.Info);
            }

            var currencies = symbols.Symbols.Select(c => new Currency
            {
                Name = c.Value,
                Code = c.Key,
                Enabled = false
            });
            
            await context.AddRangeAsync(currencies);
            await context.SaveChangesAsync();
            await RefreshData();
        }

        public async Task<FileContentResult> OnPostExportRatesAsync()
        {
            var csvContent = (await context.ExchangeRates
                    .ToListAsync()).RatesToCsv();
            
            return File(Encoding.UTF8.GetBytes(csvContent), "text/csv", $"rates-{DateTime.Today}.csv");
        }
    }
}