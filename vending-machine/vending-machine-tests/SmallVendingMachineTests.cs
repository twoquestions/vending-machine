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
            Assert.AreEqual(vendingMachine.coinHandler.CoinReturn.Count, 0);
            Assert.AreEqual(thanks, "THANK YOU");
            Assert.AreEqual(insertcoin, "INSERT COIN");
        }

        [TestMethod]
        public void DispensesChips()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dollar));

            var cola = vendingMachine.PushChipsButton();
            var thanks = vendingMachine.CheckDisplay();
            var insertcoin = vendingMachine.CheckDisplay();

            Assert.AreEqual(cola, "Chips");
            Assert.AreEqual(vendingMachine.coinHandler.OrderAmount, 0);

            //Should have 2 quarters
            Assert.AreEqual(vendingMachine.coinHandler.CoinReturn.Count, 2);
            Assert.AreEqual(vendingMachine.coinHandler.CoinReturn[0].diameter, 24.26);

            Assert.AreEqual(thanks, "THANK YOU");
            Assert.AreEqual(insertcoin, "INSERT COIN");
        }

        [TestMethod]
        public void DispensesCandy()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dollar));

            var cola = vendingMachine.PushCandyButton();
            var thanks = vendingMachine.CheckDisplay();
            var insertcoin = vendingMachine.CheckDisplay();

            Assert.AreEqual(cola, "Candy");
            Assert.AreEqual(vendingMachine.coinHandler.OrderAmount, 0);

            //We should have a quarter and a dime.
            Assert.AreEqual(vendingMachine.coinHandler.CoinReturn.Count, 2);
            Assert.AreEqual(vendingMachine.coinHandler.CoinReturn[0].diameter, 24.26);
            Assert.AreEqual(vendingMachine.coinHandler.CoinReturn[1].diameter, 17.91);

            Assert.AreEqual(thanks, "THANK YOU");
            Assert.AreEqual(insertcoin, "INSERT COIN");
        }

        [TestMethod]
        public void NotEnoughMoney()
        {
            vendingMachine.coinHandler.AcceptCoin(new Coin(CoinType.Dime));

            var cola = vendingMachine.PushCandyButton();
            var price = vendingMachine.CheckDisplay();
            var priceagain = vendingMachine.CheckDisplay();

            Assert.AreEqual(cola, "");
            Assert.AreEqual(vendingMachine.coinHandler.OrderAmount, .1);
            Assert.AreEqual(price, "PRICE: $0.65");
            Assert.AreEqual(priceagain, "AMOUNT: $0.10");
        }
    }
}
