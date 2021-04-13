using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OwlApp.Models
{
    public class Asset
    {
        public int ID { get; set; }
        public string AssetName { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateTime { get; set; }
        public string Market { get; set; }
        public decimal RealStrike { get; set; }
    }
}
