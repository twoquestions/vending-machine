using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine.Vending_Machine_Tests
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
            Assert.AreEqual(.25, handler.OrderAmount);
            Assert.AreEqual(1, handler.QuarterBin.Count);
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

            Assert.AreEqual(.25, handler.OrderAmount);
            Assert.AreEqual(2, handler.DimeBin.Count);
            Assert.AreEqual(1, handler.NickelBin.Count);
        }

        [TestMethod]
        public void RejectsBadCoins()
        {
            var counterfeitQuarter = new Coin() { diameter = 25, weight = 6 };
            handler.AcceptCoin(counterfeitQuarter);

            Assert.AreEqual(0, handler.OrderAmount);
            Assert.AreEqual(0, handler.QuarterBin.Count);
            Assert.AreEqual(1, handler.CoinReturn.Count);
        }

        [TestMethod]
        public void ClearCoinReturn()
        {
            var counterfeitDime = new Coin() { diameter = 17, weight = 1.2 };
            handler.AcceptCoin(counterfeitDime);

            Assert.AreEqual(1, handler.CoinReturn.Count);

            handler.ClearReturn();

            Assert.AreEqual(0, handler.CoinReturn.Count);
        }

        [TestMethod]
        public void ReturnCoinsTest()
        {
            var quarter = new Coin(CoinType.Quarter);
            var dime = new Coin(CoinType.Dime);

            handler.AcceptCoin(quarter);
            handler.AcceptCoin(dime);

            handler.ReturnCoins();

            Assert.AreEqual(2, handler.CoinReturn.Count);
        }
    }
}
