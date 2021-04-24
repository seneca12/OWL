using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OwlApp.Dtos;
using OwlApp.Interfaces;

namespace OwlApp.Pages.Rate
{
    public class List : PageModel
    {
        private readonly IExchangeService _exchangeService;
        public ExchangeResponse Exchange { get; set; }

        public List(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }
        
        public async Task OnGetAsync()
        {
            Exchange = await _exchangeService.GetExchangeRates("USD", new[]
            {
                "EUR",
                "GBP"
            });
        }
    }
}