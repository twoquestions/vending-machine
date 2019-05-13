using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    /// <summary>
    /// This class keeps track of how much money we have for an
    /// order at one time, and of how many coins and of what type
    /// we have.
    /// It also sorts coins into the proper bin, and rejects 
    /// invalid coins.
    /// </summary>
    public class CoinHandler
    {
        public CoinHandler()
        {
            OrderAmount = 0;
            NickelBin = new List<Coin>();
            DimeBin = new List<Coin>();
            QuarterBin = new List<Coin>();
            HalfDollarBin = new List<Coin>();
            DollarBin = new List<Coin>();
            CoinReturn = new List<Coin>();
        }

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
            if (coin.diameter == 21.21 &&
                coin.weight == 5)
            {   //Nickel
                NickelBin.Add(coin);
                OrderAmount += .05;
            }
            else if (coin.diameter == 17.91 &&
                      coin.weight == 1.35)
            {   //Dime
                DimeBin.Add(coin);
                OrderAmount += .1;
            }
            else if (coin.diameter == 24.26 &&
                    coin.weight == 5.67)
            {   //Quarter
                QuarterBin.Add(coin);
                OrderAmount += .25;
            }
            else if (coin.diameter == 30.61 &&
                    coin.weight == 11.34)
            {   //Half Dollar
                HalfDollarBin.Add(coin);
                OrderAmount += .5;
            }
            else if (coin.diameter == 26.49 &&
                    coin.weight == 8.1)
            {   //Dollar
                DollarBin.Add(coin);
                OrderAmount += 1;
            }
            else
            {
                CoinReturn.Add(coin);
            }
        }

        public void ReturnCoins()
        {
            throw new NotImplementedException();
        }

        public void ClearReturn()
        {
            CoinReturn.Clear();
        }
    }
}
