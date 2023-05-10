using ZooManagement;

namespace ZooAPI.Models
{
    public class AnimalModel
    {
        public string? Name { get; set; }
        public float? Weight { get; set; }
        public AnimalModel(ZooManager zoo, string species, string name)
        {
            var animal = zoo.Animals.First(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                           && x.Species.Name.Equals(species, StringComparison.OrdinalIgnoreCase));

            if (animal == null) return;

            Name = animal.Name;
            Weight = animal.Weight;
        }
    }
}
