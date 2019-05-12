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
            diameter = 0;
            weight = 0;
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
