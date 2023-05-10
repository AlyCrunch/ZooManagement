using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooManagement
{
    public class MockDataSource : IDataSource
    {
        public List<Animal> GetAnimals(Dictionary<string, Species> species)
            => new List<Animal>
            {
                new Animal(species["Lion"],"Simba", 160),
                new Animal(species["Lion"],"Nala", 172),
                new Animal(species["Lion"],"Mufasa", 190),

                new Animal(species["Giraffe"],"Hanna", 200),
                new Animal(species["Giraffe"],"Anna", 202),
                new Animal(species["Giraffe"],"Susanna", 199),

                new Animal(species["Tiger"],"Dante", 150),
                new Animal(species["Tiger"],"Asimov", 142),
                new Animal(species["Tiger"],"Tolkien", 139),

                new Animal(species["Zebra"],"Chip", 100),
                new Animal(species["Zebra"],"Dale", 62),

                new Animal(species["Wolf"],"Pin", 78),
                new Animal(species["Wolf"],"Pon", 69),

                new Animal(species["Piranha"],"Anastasia", 0.5f)
            };

        public Dictionary<string, decimal> GetPrices()
            => new Dictionary<string, decimal> { { "Meat", 12.56M }, { "Fruit", 5.60M } };

        public Dictionary<string, Species> GetSpecies()
        => new Dictionary<string, Species>{
                {"Lion" , new Species("Lion", 0.10f, "meat")},
                {"Tiger" ,new Species("Tiger", 0.09f, "meat")},
                {"Giraffe" ,new Species("Giraffe", 0.08f, "fruit")},
                {"Zebra" ,new Species("Zebra", 0.08f, "fruit")},
                {"Wolf" ,new Species("Wolf", 0.07f, "both", 90)},
                {"Piranha" ,new Species("Piranha", 0.5f, "both", 50)},
            };
    }
}
