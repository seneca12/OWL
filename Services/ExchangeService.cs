using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OwlApp.Dtos;
using OwlApp.Interfaces;

namespace OwlApp.Services
{
    public class ExchangeService: IExchangeService
    {
        private readonly IConfiguration _configuration;
        private const string ApiEndpoint = "http://api.exchangeratesapi.io/v1";
        private readonly string _accessKey;
        private readonly HttpClient _client;
        
        public ExchangeService(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            _client = new HttpClient();
            _accessKey = configuration["ApiKeys:ExchangeService"];
        }
        
        
        public async Task<ExchangeResponse> GetExchangeRates(string baseRate, IEnumerable<string> toRates)
        {
            var requestUri =
                $"{ApiEndpoint}/latest?access_key={_accessKey}&base={baseRate}&symbols={string.Join(',', toRates)}";
            
            var response = await _client.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var exchangeResponse =
                JsonConvert
                    .DeserializeObject<ExchangeResponse>(
                        await response.Content.ReadAsStringAsync()
                    );
            
            return exchangeResponse;
        }

        public async Task<ExchangeSymbolsResponse> GetExchangeSymbols()
        {
            var requestUri = $"{ApiEndpoint}/symbols?access_key={_accessKey}";
            
            var response = await _client.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var exchangeResponse =
                JsonConvert
                    .DeserializeObject<ExchangeSymbolsResponse>(
                        await response.Content.ReadAsStringAsync()
                    );
            
            return exchangeResponse;
        }
    }
}