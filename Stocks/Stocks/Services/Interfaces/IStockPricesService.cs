using System;
namespace Stocks.Services.Interfaces
{
    public interface IStockPricesService
    {
        decimal[] GetPrices(string symbol);
    }
}
