namespace ZooManagement
{
    public class Animal
    {
        public Species Species { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public double GetDailyMeat()
            => Weight * Species.GetRateMeat();
        public double GetDailyFruit()
            => Weight * Species.GetRateFruit();
    }
}
