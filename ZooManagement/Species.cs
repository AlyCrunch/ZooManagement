namespace ZooManagement
{
    public class Species
    {
        public string Name { get; set; }
        public float Rate { get; set; }
        public int Meat { get; set; } = 0;
        public int Fruit { get => 100 - Meat;}

        public Species(string name, float rate, string diet, int percent = 0)
        {
            Name = name;
            Rate = rate;
            if (diet == "meat") Meat = 100;
            if (diet == "fruit") Meat = 0;
            if (diet == "both") Meat = percent;
        }

        public float GetRateMeat()
            => Rate * Meat / 100;
        public float GetRateFruit()
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
