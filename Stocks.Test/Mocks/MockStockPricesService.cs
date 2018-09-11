using Stocks.Models;
using Stocks.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Stocks.Tests.Mocks
{
    public class MockStockPricesService : IStockInfoService
    {
        public bool GetStockRefactor
        {
            get;
            private set;
        }

        public Task<StocksInfo[]> GetStocksInfo(string symbol)
        {
            GetStockRefactor = true;

            if (symbol == "MSFT")
            {
                var stocksInfo = new StocksInfo[5];
                return Task.FromResult(stocksInfo);
            } else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
