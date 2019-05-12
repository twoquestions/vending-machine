using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace vending_machine.vending_machine_tests
{
    [TestClass]
    public class CoinHandlerTests
    {
        CoinHandler handler;

        [TestInitialize]
        public void Initialize()
        {
            handler = new CoinHandler();
        }

        [TestMethod]
        public void AcceptsAQuarter()
        {
            var coin = new Coin(CoinType.Quarter);
            handler.AcceptCoin(coin);
            Assert.AreEqual(handler.OrderAmount, .25);
            Assert.AreEqual(handler.QuarterBin.Count, 1);
        }

        [TestMethod]
        public void AcceptsMultipleCoins()
        {
            var dime1 = new Coin(CoinType.Dime);
            var dime2 = new Coin(CoinType.Dime);
            var nickel = new Coin(CoinType.Nickel);
            handler.AcceptCoin(dime1);
            handler.AcceptCoin(dime2);
            handler.AcceptCoin(nickel);

            Assert.AreEqual(handler.OrderAmount, .25);
            Assert.AreEqual(handler.DimeBin.Count, 2);
            Assert.AreEqual(handler.NickelBin.Count, 1);
        }

        [TestMethod]
        public void RejectsBadCoins()
        {
            var counterfeitQuarter = new Coin() { diameter = 25, weight = 6 };
            handler.AcceptCoin(counterfeitQuarter);

            Assert.AreEqual(handler.OrderAmount, 0);
            Assert.AreEqual(handler.QuarterBin.Count, 0);
            Assert.AreEqual(handler.CoinReturn.Count, 1);
        }

        [TestMethod]
        public void ClearCoinReturn()
        {
            var counterfeitDime = new Coin() { diameter = 17, weight = 1.2 };
            handler.AcceptCoin(counterfeitDime);

            Assert.AreEqual(handler.CoinReturn.Count, 1);

            handler.ClearReturn();

            Assert.AreEqual(handler.CoinReturn.Count, 0);
        }
    }
}
