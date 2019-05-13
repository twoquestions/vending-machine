using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var vending = new SmallVendingMachine();
            Console.WriteLine("Let's get a drink!");
            Console.WriteLine(vending.CheckDisplay());
            vending.coinHandler.AcceptCoin(new Coin(CoinType.Dollar));
            Console.WriteLine("And push the button....");
            var drink = vending.PushColaButton();
            Console.WriteLine(vending.CheckDisplay());
            Console.WriteLine($"We have a {drink}!");

            Console.WriteLine("Now for some candy...");
            vending.coinHandler.AcceptCoin(new Coin(CoinType.Quarter));
            vending.coinHandler.AcceptCoin(new Coin(CoinType.Quarter));
            var candy = vending.PushCandyButton();
            Console.WriteLine($"Now we have {candy}... wait a minute.");
            Console.WriteLine(vending.CheckDisplay());
            Console.WriteLine(vending.CheckDisplay());


            Console.WriteLine("Oh right, need a bit more");
            vending.coinHandler.AcceptCoin(new Coin(CoinType.Quarter));
            Console.WriteLine("Let's try that again...");
            candy = vending.PushCandyButton();
            Console.WriteLine($"Now we have {candy}!");


            Console.WriteLine(vending.CheckDisplay());
            Console.WriteLine(vending.CheckDisplay());
            Console.WriteLine("Let's get our change...");
            vending.coinHandler.ClearReturn();
            Console.WriteLine(vending.CheckDisplay());
        }
    }
}
