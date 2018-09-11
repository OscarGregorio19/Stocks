using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Models
{
    public class StocksInfo
    {
        public DateTime Timestamp { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public int Volume { get; set; }
    }
}
