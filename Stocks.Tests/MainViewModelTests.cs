using NUnit.Framework;
using Stocks.Tests.Mocks;
using Stocks.ViewModels;
using System;

namespace Stocks.Tests
{
    [TestFixture()]
    public class MainViewModelTests
    {
        [Test()]
        public void ShouldSucceed()
        {
            // Arrange
            var symbol = "MSFT";
            var mockStockPricesService = new MockStockPricesService();

            // Act
            var vm = new MainViewModel(mockStockPricesService);
            vm.Symbol = symbol;
            vm.ConsultarPreciosCommand.Execute(null);

            // Assert
            Assert.IsNotNull(vm.Prices);
        }
    }
}
