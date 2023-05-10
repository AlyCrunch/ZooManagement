using ZooManagement;

namespace ZooAPI.Models
{
    public class ZooModel
    {
        public decimal Daily { get; set; }
        private IEnumerable<Animal> Animals { get; set; }
        public int TotalPopulation { get => Animals.Count(); }
        public decimal MeatPrice { get; set; }
        public decimal FruitPrice { get; set; }

        public ZooModel(ZooManager zoo)
        {
            Daily = zoo.GetDailyFood();
            Animals = zoo.Animals;
            MeatPrice = zoo.Prices["Meat"];
            FruitPrice = zoo.Prices["Fruit"];
        }
    }
}
