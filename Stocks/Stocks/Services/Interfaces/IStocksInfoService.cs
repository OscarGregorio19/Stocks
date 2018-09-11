using Stocks.Models;
using System;
using System.Threading.Tasks;

namespace Stocks.Services.Interfaces
{
    public interface IStocksInfoService
    {
        Task<StocksInfo[]> GetStocksInfo(string symbol);
    }
}
