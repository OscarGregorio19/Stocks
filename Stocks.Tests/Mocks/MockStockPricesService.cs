using System;
using Stocks.Services.Interfaces;

namespace Stocks.Tests.Mocks
{
    public class MockStockPricesService : IStockPricesService
    {
        public decimal[] GetPrices(string symbol)
        {
            return new[] { 1.1m, 2.2m, 3.3m };
        }
    }
}
