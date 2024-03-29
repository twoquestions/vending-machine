﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        /// <summary>
        /// Return OrderAmount to the user in the proper
        /// coinage in the Coin Return.
        /// </summary>
        public void ReturnCoins()
        {
            while (OrderAmount > 0)
            {
                Coin coin = null;
                //Because floats aren't precise...
                OrderAmount = Math.Round(OrderAmount, 2);

                if (OrderAmount - 1 >= 0)
                {
                    coin = DollarBin.First();
                    DollarBin.Remove(coin);
                    OrderAmount -= 1;
                    CoinReturn.Add(coin);
                    continue;
                }
                if (OrderAmount - .5 >= 0)
                {
                    coin = HalfDollarBin.First();
                    HalfDollarBin.Remove(coin);
                    OrderAmount -= .5;
                    CoinReturn.Add(coin);
                    continue;
                }
                if (OrderAmount - .25 >= 0)
                {
                    coin = QuarterBin.First();
                    QuarterBin.Remove(coin);
                    OrderAmount -= .25;
                    CoinReturn.Add(coin);
                    continue;
                }
                if (OrderAmount - .1 >= 0)
                {
                    coin = DimeBin.First();
                    DimeBin.Remove(coin);
                    OrderAmount -= .1;
                    CoinReturn.Add(coin);
                    continue;
                }
                if (OrderAmount - .05 >= 0)
                {
                    coin = NickelBin.First();
                    NickelBin.Remove(coin);
                    OrderAmount -= .05;
                    CoinReturn.Add(coin);
                    continue;
                }

            }
        }

        public void ClearReturn()
        {
            CoinReturn.Clear();
        }
    }
}
