using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vending_Machine
{
    /// <summary>
    /// This vending machine will give out strings representing
    /// products, and display messages to the user about what they
    /// should do to get snacks or refreshment.
    /// </summary>
    public class SmallVendingMachine
    {
        public CoinHandler coinHandler;
        private int candyCount;
        private int chipsCount;
        private int colaCount;
        private string message;


        public SmallVendingMachine()
        {
            coinHandler = new CoinHandler();

            //Put some coins in the handler at the begining of the day.
            for (var i = 0; i < 10; i++)
            {
                coinHandler.NickelBin.Add(new Coin(CoinType.Nickel));
                coinHandler.DimeBin.Add(new Coin(CoinType.Dime));
                coinHandler.QuarterBin.Add(new Coin(CoinType.Quarter));
                coinHandler.HalfDollarBin.Add(new Coin(CoinType.HalfDollar));
                coinHandler.DollarBin.Add(new Coin(CoinType.Dollar));
            }

            candyCount = 10;
            chipsCount = 10;
            colaCount = 10;
            message = "";
        }

        public string CheckDisplay()
        {
            if (message != "")
            {
                var msg = message;
                message = "";
                return msg;
            }
            else if (coinHandler.OrderAmount != 0)
                return "AMOUNT: " + coinHandler.OrderAmount.ToString("C2");
            else
                return "INSERT COIN";
        }

        private string PushButton(string productName, double productPrice, ref int productCount)
        {
            if (coinHandler.OrderAmount >= productPrice &&
                candyCount > 0)
            {
                productCount -= 1;
                coinHandler.OrderAmount -= productPrice;
                coinHandler.ReturnCoins();
                message = "THANK YOU";
                return productName;
            } else if (coinHandler.OrderAmount < productPrice)
            {
                message = "PRICE: " + productPrice.ToString("C2");
            } else if (productCount == 0)
            {
                message = "SOLD OUT";
            }
            return "";
        }

        public string PushCandyButton()
        {
            return PushButton("Candy", .65, ref candyCount);
        }

        public string PushChipsButton()
        {
            return PushButton("Chips", .5, ref chipsCount);
        }

        public string PushColaButton()
        {
            return PushButton("Cola", 1, ref colaCount);
        }
    }
}
