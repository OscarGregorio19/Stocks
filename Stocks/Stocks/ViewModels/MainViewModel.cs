using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Stocks.Models;
using Stocks.Operations;
using Stocks.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Stocks.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private readonly IStockInfoService stockInfoService;
        private readonly ILogger logger;

        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set
            {
                Set(nameof(Symbol), ref symbol, value);
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                Set(nameof(Status), ref status, value);
            }
        }

        private StocksInfo[] stocksInfo;
        public StocksInfo[] StocksInfo
        {
            get { return stocksInfo; }
            set
            {
                Set(nameof(StocksInfo), ref stocksInfo, value);
            }
        }

        public RelayCommand ConsultarPreciosCommand
        {
            get;
            set;
        }

        public MainViewModel(IStockInfoService stockInfoService, ILogger logger)
        {
            this.stockInfoService = stockInfoService;
            this.logger = logger;
            ConsultarPreciosCommand = new RelayCommand(async () => await ConsultarPreciosAsync());
        }

        private async Task ConsultarPreciosAsync()
        {
            Status = "Operacion en progreso ...";
            try
            {
                StocksInfo = await stockInfoService.GetStocksInfo(Symbol);
                Status = "Done!";
            } catch(Exception ex)
            {
                //Minimo hay que hacer logging
                Status = "Ooops!";
                logger.Error(ex);
            }
            
        }

        /*public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }*/
    }
}
