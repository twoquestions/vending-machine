using System;
using System.Collections.Generic;
using System.Text;

namespace vending_machine
{
    public class CoinHandler
    {

        public double OrderAmount { get; set; }

        public List<Coin> NickelBin { get; set; }
        public List<Coin> DimeBin { get; set; }
        public List<Coin> QuarterBin { get; set; }
        public List<Coin> HalfDollarBin { get; set; }
        public List<Coin> DollarBin { get; set; }
        public List<Coin> CoinReturn { get; set; }

        /// <summary>
        /// Funnels valid coins into the appropriate bin,
        /// puts invalid coins into the coin return.
        /// </summary>
        /// <param name="coin"></param>
        public void AcceptCoin(Coin coin)
        {

        }
    }
}
