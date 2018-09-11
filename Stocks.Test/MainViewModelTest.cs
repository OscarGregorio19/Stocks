using NUnit.Framework;
using Stocks.Test.Mocks;
using Stocks.Tests.Mocks;
using Stocks.ViewModels;

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
            var mockStocksInfoService = new MockStocksInfoService();
            var mockLogger = new MockLogger();

            // Act
            var vm = new MainViewModel(mockStocksInfoService, mockLogger);
            vm.Symbol = symbol;
            vm.ConsultarPreciosCommand.Execute(null);

            // Assert
            Assert.IsNotNull(vm.StocksInfo);
            Assert.AreEqual("Done!", vm.Status);
            Assert.IsTrue(mockStocksInfoService.GetStockInfonvoked);
        }

        [Test()]
        public void ShouldDisplayNotFoundWhenSymbolDoesNotExist()
        {
            // Arrange
            var symbol = "GOOG";
            var mockStocksInfoService = new MockStocksInfoService();
            var mockLogger = new MockLogger();

            // Act
            var vm = new MainViewModel(mockStocksInfoService, mockLogger);
            vm.Symbol = symbol;
            vm.ConsultarPreciosCommand.Execute(null);

            // Assert
            Assert.AreEqual($"Símbolo '{symbol}' no encontrado", vm.Status);
            Assert.IsTrue(mockStocksInfoService.GetStockInfonvoked);
        }

        [Test]
        public void ShouldDisplayServicioNoDisponibleCuandoElBackendSeChocolatee()
        {
            // Arrange
            var symbol = "ABCD";
            var mockStocksInfoService = new MockStocksInfoService();
            var mockLogger = new MockLogger();

            // Act
            var vm = new MainViewModel(mockStocksInfoService, mockLogger);
            vm.Symbol = symbol;
            vm.ConsultarPreciosCommand.Execute(null);

            // Assert
            Assert.AreEqual($"Servicio no disponible", vm.Status);
            Assert.IsTrue(mockStocksInfoService.GetStockInfonvoked);
            Assert.IsTrue(mockLogger.ErrorInvoked);
        }
    }
}