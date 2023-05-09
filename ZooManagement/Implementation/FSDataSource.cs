using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ZooManagement
{
    public class FSDataSource : IDataSource
    {
        public List<Animal> GetAnimals(Dictionary<string, Species> species)
        {
            XElement zoo = XElement.Load(@"Resources\zoo.xml");            
            return zoo.Descendants()
                .Where(x => x.Attribute("name") != null)
                .Select(x => new Animal( 
                    species[x.Name.ToString()],
                    x.Attribute("name").Value,
                    TryGetDouble(x.Attribute("kg").Value)))
                .ToList();
        }

        public Dictionary<string, double> GetPrices()
        {
            var file = File.ReadAllLines(@"Resources\prices.txt");
            return file.Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
                       .ToLookup(x => x[0], y => TryGetDouble(y[1]))
                       .ToDictionary(x => x.Key, y => y.First());
        }

        public Dictionary<string, Species> GetSpecies()
        {
            var file = File.ReadAllLines(@"Resources\animals.csv");

            return file.Select(x => x.Split(';', StringSplitOptions.RemoveEmptyEntries))
                       .Select(x => ArrayToSpecies(x))
                       .ToLookup(x => x.Name)
                       .ToDictionary(x => x.Key, y => y.First());
        }

        public Species ArrayToSpecies(string[] arr)
        {
            return new Species(
                arr[0],
                TryGetDouble(arr[1]),
                arr[2],
                (arr[2] == "both") ? int.Parse(arr[3][..^1]) : 0);
        }

        public double TryGetDouble(string str)
        {
            bool success = double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture , out double d);
            return success ? d : throw new Exception("Double parsing failed");
        }

    }
}
