using ZooManagement;
using System.Linq;

namespace ZooAPI.Models
{
    public static class SpeciesHelper
    {
        public static IEnumerable<string> GetListSpecies (ZooManager zoo, string? diet = "")
        {
            return diet switch
            {
                "carnivore" => zoo.Species.Values.Where(x => x.Meat == 100).Select(x => x.Name),
                "herbivore" => zoo.Species.Values.Where(x => x.Fruit == 100).Select(x => x.Name),
                "omnivore" => zoo.Species.Values.Where(x => x.Fruit != 100 && x.Meat != 100).Select(x => x.Name),
                _ => zoo.Species.Values.Select(x => x.Name)
            };
        }

        public static IEnumerable<string> GetListAnimalsBySpecies(ZooManager zoo, string species = "")
            => zoo.Animals.Where(x => species.Equals(x.Species.Name, StringComparison.OrdinalIgnoreCase))
                          .Select(x => x.Name);
    }
}
