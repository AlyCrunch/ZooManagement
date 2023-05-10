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
        readonly string _path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public List<Animal> GetAnimals(Dictionary<string, Species> species)
        {
            XElement zoo = XElement.Load(_path + @"\Resources\zoo.xml");            
            return zoo.Descendants()
                .Where(x => x.Attribute("name") != null)
                .Select(x => new Animal( 
                    species[x.Name.ToString()],
                    x.Attribute("name").Value,
                    float.Parse(x.Attribute("kg").Value, CultureInfo.InvariantCulture)))
                .ToList();
        }

        public Dictionary<string, decimal> GetPrices()
        {
            var file = File.ReadAllLines(_path + @"\Resources\prices.txt");
            return file.Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
                       .ToLookup(x => x[0], y => decimal.Parse(y[1],CultureInfo.InvariantCulture))
                       .ToDictionary(x => x.Key, y => y.First());
        }

        public Dictionary<string, Species> GetSpecies()
        {
            var file = File.ReadAllLines(_path + @"\Resources\animals.csv");

            return file.Select(x => x.Split(';', StringSplitOptions.RemoveEmptyEntries))
                       .Select(x => ArrayToSpecies(x))
                       .ToLookup(x => x.Name)
                       .ToDictionary(x => x.Key, y => y.First());
        }

        public Species ArrayToSpecies(string[] arr)
        {
            return new Species(
                arr[0],
                float.Parse(arr[1], CultureInfo.InvariantCulture),
                arr[2],
                (arr[2] == "both") ? int.Parse(arr[3][..^1]) : 0);
        }

    }
}
