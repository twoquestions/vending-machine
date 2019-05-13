using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vending_Machine
{
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
                coinHandler.OrderAmount = 0;
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

        public object PushChipsButton()
        {
            return PushButton("Chips", .5, ref chipsCount);
        }

        public object PushColaButton()
        {
            return PushButton("Cola", 1, ref colaCount);
        }
    }
}
