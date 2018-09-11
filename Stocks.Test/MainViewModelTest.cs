using NUnit.Framework;
using Stocks.Test.Mocks;
using Stocks.Tests.Mocks;
using Stocks.ViewModels;

namespace Stock.Tests
{
    [TestFixture]
    public class MainViewModelService
    {
        [Test]
        public void ShouldSucceed()
        {
            //Arrange
            var symbol = "MSFT";
            var mockStockInfoService = new MockStockPricesService();
            var mockLogger = new MockLogger();

            //Act
            var vm = new MainViewModel(mockStockInfoService, mockLogger);
            vm.Symbol = symbol;
            vm.ConsultarPreciosCommand.Execute(null);

            //Assert
            Assert.IsNotNull(vm.StocksInfo);
            Assert.AreEqual("Done!", vm.Status);
        }

        [Test]
        public void ShouldLogErrorWhenStockPricesServiceFails()
        {
            //Arrange
            var symbol = "Hola culeros!";
            var mockStockInfoService = new MockStockPricesService();
            var mockLogger = new MockLogger();

            //Act
            var vm = new MainViewModel(mockStockInfoService, mockLogger);
            vm.Symbol = symbol;
            vm.ConsultarPreciosCommand.Execute(null);

            //Assert
            Assert.AreEqual("Ooops!", vm.Status);
            Assert.IsTrue(mockStockInfoService.GetStockRefactor);
            Assert.IsTrue(mockLogger.ErrorInvoked);
        }
    }
}
