using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OwlApp.Data;
using OwlApp.Dtos;
using OwlApp.Interfaces;
using OwlApp.Models;

namespace OwlApp.Pages.Rate
{
    public class List : PageModel
    {
        private readonly IExchangeService _exchangeService;
        private readonly OwlAppContext context;

        public ExchangeResponse Exchange { get; set; }

        public List(IExchangeService exchangeService, OwlAppContext context)
        {
            _exchangeService = exchangeService;
            this.context = context;
        }
        
        public async Task OnGetAsync()
        {
            Exchange = await _exchangeService.GetExchangeRates("EUR", new[]
            {
                "EUR",
                "GBP",
                "USD",
                "JPY"
            });

            var rates = Exchange.Rates.Select(r =>
            {
                var x = new ExchangeRate
                {
                    Base = Exchange.Base,
                    Date = Exchange.Date,
                    TargetCurrencyCode = r.Key,
                    Rate = r.Value
                };

                return x;
            });

            context.AddRange(rates);
        }
    }
}