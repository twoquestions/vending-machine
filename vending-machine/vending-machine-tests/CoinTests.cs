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
            Assert.AreEqual(24.26, quarter.diameter);
            Assert.AreEqual(5.67, quarter.weight);
        }
    }
}
