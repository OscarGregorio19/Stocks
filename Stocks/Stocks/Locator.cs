using GalaSoft.MvvmLight.Ioc;
using Stocks.Operations;
using Stocks.Services.Interfaces;
using Stocks.Services.Layer;
using Stocks.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks
{
    public class Locator
    {
        static Locator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IStocksInfoService, StockPricesService>();
            SimpleIoc.Default.Register<ILogger, DevelopmentLogger>();
        }

        public MainViewModel Main
        {
            get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
        }
    }
}
