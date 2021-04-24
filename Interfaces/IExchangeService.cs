using System.Collections.Generic;
using System.Threading.Tasks;
using OwlApp.Dtos;

namespace OwlApp.Interfaces
{
    public interface IExchangeService
    {
        public Task<ExchangeResponse> GetExchangeRates(string baseRate, IEnumerable<string> toRates);
    }
}