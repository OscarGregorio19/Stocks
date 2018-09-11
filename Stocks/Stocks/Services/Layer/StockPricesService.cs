using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stocks.Models;
using Stocks.Operations;
using Stocks.Services.Interfaces;

namespace Stocks.Services.Layer
{
    public class StockPricesService : IStocksInfoService
    {
        private readonly ILogger logger;

        public StockPricesService(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<StocksInfo[]> GetStocksInfo(string symbol)
        {
            var httpClient = default(HttpClient);
            var uriBuilder = new UriBuilder()
            {
                Scheme = "https",
                Host = "stockquoteprice.azurewebsites.net",
                Path = "api/price",
                Query = $"symbol={symbol}"
            };

            try
            {
                httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(3);

                var response = await httpClient.GetAsync(uriBuilder.Uri);
                var stocksInfo = default(StocksInfo[]);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    stocksInfo = JsonConvert.DeserializeObject<StocksInfo[]>(json);
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new InvalidOperationException();
                }

                return stocksInfo;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
            finally
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
        }
    }
}