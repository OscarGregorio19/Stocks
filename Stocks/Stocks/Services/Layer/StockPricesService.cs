using Newtonsoft.Json;
using Stocks.Models;
using Stocks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Services.Layer
{
    public class StockPricesService : IStockInfoService
    {
        public async Task<StocksInfo[]> GetStocksInfo(string symbol)
        {
            var httpClient = default(HttpClient);
            var uriBuilder = new UriBuilder()
            {
                Scheme = "https",
                Host = "stockquoteprice.azurewebsites.net",
                Path = "api/price",
                Query = $"symbol={symbol}" //string interpolation
            };
           
            try
            {
                httpClient = new HttpClient();
                var response = await httpClient.GetAsync(uriBuilder.Uri);
                var json = await response.Content.ReadAsStringAsync();
                var stocksInfo = JsonConvert.DeserializeObject<StocksInfo[]>(json);

                return stocksInfo;
            }
            finally
            {
                if(httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
        }
    }
}
