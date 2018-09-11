using System;
using System.Threading.Tasks;

using Stocks.Models;
using Stocks.Services.Interfaces;

namespace Stocks.Tests.Mocks
{
    public class MockStocksInfoService : IStocksInfoService
    {
        public bool GetStockInfonvoked
        {
            get;
            private set;
        }

        public Task<StocksInfo[]> GetStocksInfo(string symbol)
        {
            GetStockInfonvoked = true;

            if (symbol == "MSFT")
            {
                var stocksInfo = new StocksInfo[5];
                return Task.FromResult(stocksInfo);
            }
            else if (symbol == "GOOG")
            {
                return Task.FromResult<StocksInfo[]>(null);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}