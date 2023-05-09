namespace ZooManagement
{
    public class Species
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public int Meat { get; set; } = 0;
        public int Fruit { get; set; } = 0;

        public Species(string name, double rate, int meat, int fruit)
        {
            Name = name;
            Rate = rate;
            Meat = meat;
            Fruit = fruit;
        }
        public Species(string name, double rate, string diet, int percent = 0)
        {
            Name = name;
            Rate = rate;
            if (diet == "meat") Meat = 100;
            if (diet == "fruit") Fruit = 100;
            if (diet == "both")
            {
                Meat = percent;
                Fruit = 100 - percent;
            }
        }

        public double GetRateMeat()
            => Rate * Meat / 100;
        public double GetRateFruit()
            => Rate * Fruit / 100;

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var s = (Species)obj;

            if (s.Name != Name) return false;
            if (s.Rate != Rate) return false;
            if (s.Meat != Meat) return false;
            if (s.Fruit != Fruit) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
