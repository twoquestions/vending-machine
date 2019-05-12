using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    public class SmallVendingMachine
    {
        public CoinHandler coinHandler;

        public SmallVendingMachine()
        {
            coinHandler = new CoinHandler();
        }

        public string PushColaButton()
        {
            throw new NotImplementedException();
        }

        public object CheckDisplay()
        {
            throw new NotImplementedException();
        }
    }
}
