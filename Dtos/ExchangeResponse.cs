using System;
using System.Collections.Generic;

namespace OwlApp.Dtos
{
    public class ExchangeResponse
    {
        public bool Success { get; set; }
        public string Timestamp { get; set; }
        public string Base { get; set; }
        public DateTime Date { get; set; }
        // public List<RateDto> Rates { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
        public ExchangeError Error { get; set; }
    }
}