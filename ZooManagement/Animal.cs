namespace ZooManagement
{
    public class Animal
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public double GetDailyMeat()
            => Weight * Type.GetRatioMeat();
        public double GetDailyFruit()
            => Weight * Type.GetRatioFruit();
    }
}
