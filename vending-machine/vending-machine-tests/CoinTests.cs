using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine.Vending_Machine_Tests
{
    [TestClass]
    public class CoinTests
    {
        [TestMethod]
        public void CreatesProperQuarter()
        {
            var quarter = new Coin(CoinType.Quarter);
            Assert.AreEqual(quarter.diameter, 24.26);
            Assert.AreEqual(quarter.weight, 5.67);
        }
    }
}
