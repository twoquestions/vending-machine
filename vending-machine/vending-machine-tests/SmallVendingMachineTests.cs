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

            Assert.AreEqual("Cola", cola);
            Assert.AreEqual(0, vendingMachine.coinHandler.OrderAmount);
            Assert.AreEqual(0, vendingMachine.coinHandler.CoinReturn.Count);
            Assert.AreEqual("THANK YOU", thanks);
            Assert.AreEqual("INSERT COIN", insertcoin);
        }

        [TestMethod]
        public void DispensesChips()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dollar));

            var chips = vendingMachine.PushChipsButton();
            var thanks = vendingMachine.CheckDisplay();
            var insertcoin = vendingMachine.CheckDisplay();

            Assert.AreEqual("Chips", chips);
            Assert.AreEqual(0, vendingMachine.coinHandler.OrderAmount);

            //Should have 2 quarters
            Assert.AreEqual(1, vendingMachine.coinHandler.CoinReturn.Count);
            Assert.AreEqual(30.61, vendingMachine.coinHandler.CoinReturn[0].diameter);

            Assert.AreEqual("THANK YOU", thanks);
            Assert.AreEqual("INSERT COIN", insertcoin);
        }

        [TestMethod]
        public void DispensesCandy()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dollar));

            var candy = vendingMachine.PushCandyButton();
            var thanks = vendingMachine.CheckDisplay();
            var insertcoin = vendingMachine.CheckDisplay();

            Assert.AreEqual("Candy", candy);
            Assert.AreEqual(0, vendingMachine.coinHandler.OrderAmount);

            //We should have a quarter and a dime.
            Assert.AreEqual(2, vendingMachine.coinHandler.CoinReturn.Count);
            Assert.AreEqual(24.26, vendingMachine.coinHandler.CoinReturn[0].diameter);
            Assert.AreEqual(17.91, vendingMachine.coinHandler.CoinReturn[1].diameter);

            Assert.AreEqual(thanks, "THANK YOU");
            Assert.AreEqual(insertcoin, "INSERT COIN");
        }

        [TestMethod]
        public void NotEnoughMoney()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dime));

            var candy = vendingMachine.PushCandyButton();
            var price = vendingMachine.CheckDisplay();
            var priceagain = vendingMachine.CheckDisplay();

            Assert.AreEqual("", candy);
            Assert.AreEqual(.1, vendingMachine.coinHandler.OrderAmount);
            Assert.AreEqual("PRICE: $0.65", price);
            Assert.AreEqual("AMOUNT: $0.10", priceagain);
        }
    }
}
