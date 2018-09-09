using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Stocks.Services.Interfaces;

namespace Stocks.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private readonly IStockPricesService stockPricesService;

        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set
            {
                Set(nameof(Symbol), ref symbol, value);
            }
        }

        private decimal[] prices;
        public decimal[] Prices
        {
            get { return prices; }
            set
            {
                Set(nameof(Prices), ref prices, value);
            }
        }

        public RelayCommand ConsultarPreciosCommand
        {
            get;
            set;
        }

        public MainViewModel(IStockPricesService stockPricesService)
        {
            this.stockPricesService = stockPricesService;
            ConsultarPreciosCommand = new RelayCommand(ConsultarPrecios);
        }

        private void ConsultarPrecios()
        {
            Prices = stockPricesService.GetPrices(Symbol);
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
