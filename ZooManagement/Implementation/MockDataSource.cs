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

                new Animal(species["Piranha"],"Anastasia", 0.5)
            };

        public Dictionary<string, double> GetPrices()
            => new Dictionary<string, double> { { "Meat", 12.56 }, { "Fruit", 5.60 } };

        public Dictionary<string, Species> GetSpecies()
        => new Dictionary<string, Species>{
                {"Lion" , new Species("Lion", 0.10, "meat")},
                {"Tiger" ,new Species("Tiger", 0.09, "meat")},
                {"Giraffe" ,new Species("Giraffe", 0.08, "fruit")},
                {"Zebra" ,new Species("Zebra", 0.08, "fruit")},
                {"Wolf" ,new Species("Wolf", 0.07, "both", 90)},
                {"Piranha" ,new Species("Piranha", 0.5, "both", 50)},
            };
    }
}
