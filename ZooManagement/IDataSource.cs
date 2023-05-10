using System;
using System.Collections.Generic;
using System.Text;

namespace ZooManagement
{
    public interface IDataSource
    {
        Dictionary<string, Species> GetSpecies(); 
        List<Animal> GetAnimals(Dictionary<string, Species> species);
        Dictionary<string, decimal> GetPrices();
    }
}
