using System;
using System.Collections.Generic;
using System.Text;

namespace vending_machine
{
    public enum CoinType { Nickel, Dime, Quarter, HalfDollar, Dollar };
    /// <summary>
    /// Coins only have a diameter and weight, the CoinType is only used
    /// for a shorthand in creating Coin objects.
    /// If we know the weight and diameter, we can counterfeit with the 
    /// parameterless constructor.
    /// Coin specifications from: 
    ///     https://www.usmint.gov/learn/coin-and-medal-programs/coin-specifications
    /// </summary>
    public class Coin
    {
        public Coin()
        {
            diameter = 0;
            weight = 0;
        }
        public Coin(CoinType coinType)
        {
            switch (coinType)
            {
                case CoinType.Nickel:
                    diameter = 21.21;
                    weight = 5;
                    break;
                case CoinType.Dime:
                    diameter = 17.91;
                    weight = 1.35;
                    break;
                case CoinType.Quarter:
                    diameter = 24.26;
                    weight = 5.67;
                    break;
                case CoinType.HalfDollar:
                    diameter = 30.61;
                    weight = 11.34;
                    break;
                case CoinType.Dollar:
                    diameter = 26.49;
                    weight = 8.1;
                    break;
            }
        }
        /// <summary>
        /// Diameter in millimeters
        /// </summary>
        public double diameter { get; set; }
        /// <summary>
        /// Weight in grams
        /// </summary>
        public double weight { get; set; }
    }
}
