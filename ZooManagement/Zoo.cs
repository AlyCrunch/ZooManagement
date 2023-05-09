using System.Collections.Generic;
using System;
using System.Linq;
using System.Globalization;

namespace ZooManagement
{
    public class Zoo
    {
        public IEnumerable<Animal> Animals { get; set; }
        public Dictionary<string, Species> Species { get; set; }
        public Dictionary<string, double> Prices { get; set; }

        public Zoo(IDataSource ds)
        {
            Prices = ds.GetPrices();
            Species = ds.GetSpecies();
            Animals = ds.GetAnimals(Species);
        }

        public double GetDailyFood()
            => Animals.Sum(x => 
                x.GetDailyMeat() * Prices["Meat"] + 
                x.GetDailyFruit() * Prices["Fruit"]);
    }
}