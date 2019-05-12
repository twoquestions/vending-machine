using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine.Vending_Machine_Tests
{
    [TestClass]
    public class SmallVendingMachineTests
    {
        SmallVendingMachine vendingMachine;

        [TestInitialize]
        public void Initialize()
        {
            vendingMachine = new SmallVendingMachine();
        }

        [TestMethod]
        public void DispensesCola()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dollar));

            var cola = vendingMachine.PushColaButton();
            var thanks = vendingMachine.CheckDisplay();
            var insertcoin = vendingMachine.CheckDisplay();

            Assert.AreEqual(cola, "Cola");
            Assert.AreEqual(vendingMachine.coinHandler.OrderAmount, 0);
            Assert.AreEqual(thanks, "THANK YOU");
            Assert.AreEqual(insertcoin, "INSERT COIN");
        }

        [TestMethod]
        public void NotEnoughMoney()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dime));

            var cola = vendingMachine.PushColaButton();
            var price = vendingMachine.CheckDisplay();
            var priceagain = vendingMachine.CheckDisplay();

            Assert.AreEqual(cola, "");
            Assert.AreEqual(vendingMachine.coinHandler.OrderAmount, .1);
            Assert.AreEqual(price, "PRICE: $1.00");
            Assert.AreEqual(priceagain, "PRICE: $1.00");
        }
    }
}
