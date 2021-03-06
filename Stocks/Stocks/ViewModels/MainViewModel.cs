﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Stocks.Models;
using Stocks.Operations;
using Stocks.Services.Interfaces;

namespace Stocks.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IStocksInfoService stocksInfoService;
        private readonly ILogger logger;

        public bool IsBusy
        {
            get;
            set;
        }

        public bool HasError
        {
            get;
            set;
        }

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


        private ObservableCollection<StocksInfo> stocksInfo;
        public ObservableCollection<StocksInfo> StocksInfo
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

        public MainViewModel(IStocksInfoService stocksInfoService, ILogger logger)
        {
            this.stocksInfoService = stocksInfoService;
            this.logger = logger;

            ConsultarPreciosCommand = new RelayCommand(async () => await ConsultarPrecios());
        }

        private async Task ConsultarPrecios()
        {
            Status = "Operación en progreso...";

            try
            {
                var results = await stocksInfoService.GetStocksInfo(Symbol);
                
                if (results != null)
                {
                    StocksInfo = new ObservableCollection<StocksInfo>(results);
                    Status = "Done!";
                }
                else
                {
                    StocksInfo = null;
                    Status = $"Símbolo '{Symbol}' no encontrado";
                }
            }
            catch (Exception ex)
            {
                Status = "Servicio no disponible";
                logger.Error(ex);
            }
        }
    }
}