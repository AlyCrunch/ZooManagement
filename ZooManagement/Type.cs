namespace ZooManagement
{
    public class Type
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public int Meat { get; set; } = 0;
        public int Fruit { get; set; } = 0;

        public double GetRatioMeat()
            => Rate * Meat / 100;
        public double GetRatioFruit()
            => Rate * Fruit / 100;
    }
}
