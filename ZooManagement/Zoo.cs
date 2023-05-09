using System.Collections.Generic;
using System;
using System.Linq;
using System.Globalization;

namespace ZooManagement
{
    public class Zoo
    {
        public IEnumerable<Animal> Animals { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public double MeatPrice { get; set; }
        public double FruitPrice { get; set; }

        public Zoo(string prices, string types, string animals)
        {
            SetPrices(prices);
        }

        public void SetPrices(string prices)
        {
            var formattedPrices = PricesToDictionary(prices);
            
            MeatPrice = formattedPrices["Meat"];
            FruitPrice = formattedPrices["Fruit"];
        }

        public static Dictionary<string, double> PricesToDictionary(string txt)
            => txt.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(part => part.Split('='))
                  .ToDictionary(split => split[0], split => Convert.ToDouble(split[1], CultureInfo.InvariantCulture));

        public double GetDailyFood()
            => Animals.Sum(x => 
                x.GetDailyMeat() * MeatPrice + 
                x.GetDailyFruit() * FruitPrice);
    }
}
