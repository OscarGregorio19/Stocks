using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Stocks.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private string symbol;
        public MainViewModel()
        {
            Symbol = "Obligame perro xD";
            ConsultarPreciosCommand = new RelayCommand(() =>
            {
                System.Diagnostics.Debug.WriteLine("Symbol = " + Symbol);
                Symbol = "Oscar Gregorio";
                prices = InvokeWebService();
            });
        }

        private decimal[] InvokeWebService()
        {
            return null;
        }

        public string Symbol{
            get { return symbol; }
            set
            {
                Set(nameof(Symbol), ref symbol, value);
            }
        }

        public decimal[] prices;
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
