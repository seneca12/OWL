using System;
using System.ComponentModel.DataAnnotations;

namespace OwlApp.Models
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public string Base { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string TargetCurrencyCode { get; set; }
        public decimal Rate { get; set; }
    }
}