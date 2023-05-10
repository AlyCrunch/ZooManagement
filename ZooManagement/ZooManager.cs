using System.Collections.Generic;
using System;
using System.Linq;
using System.Globalization;

namespace ZooManagement
{
    public class ZooManager
    {
        public IEnumerable<Animal> Animals { get; set; }
        public Dictionary<string, Species> Species { get; set; }
        public Dictionary<string, decimal> Prices { get; set; }

        public ZooManager(IDataSource ds)
        {
            Prices = ds.GetPrices();
            Species = ds.GetSpecies();
            Animals = ds.GetAnimals(Species);
        }

        public decimal GetDailyFood()
            => Animals.Sum(x => x.GetDaily(Prices["Meat"], Prices["Fruit"]));
    }
}