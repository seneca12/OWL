using System.Collections.Generic;

namespace OwlApp.Dtos
{
    public class ExchangeSymbolsResponse
    {
        public bool Success { get; set; }
        public Dictionary<string, string> Symbols { get; set; }
        public ExchangeError Error { get; set; }
    }
}