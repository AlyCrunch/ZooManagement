namespace ZooManagement
{
    public class Animal
    {
        public Species Species { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public Animal(Species species, string name, double weight)
        {
            Species = species;
            Name = name;
            Weight = weight;
        }

        public double GetDailyMeat()
            => Weight * Species.GetRateMeat();
        public double GetDailyFruit()
            => Weight * Species.GetRateFruit();
        public double GetDaily(double meatPrice, double fruitPrice)
            => GetDailyMeat() * meatPrice + GetDailyFruit() * fruitPrice;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var a = (Animal)obj;

            if (!a.Species.Equals(Species)) return false;
            if (a.Name != Name) return false;
            if (a.Weight != Weight) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
