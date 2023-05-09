namespace ZooManagement
{
    public class Species
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public int Meat { get; set; } = 0;
        public int Fruit { get; set; } = 0;

        public double GetRateMeat()
            => Rate * Meat / 100;
        public double GetRateFruit()
            => Rate * Fruit / 100;
    }
}
