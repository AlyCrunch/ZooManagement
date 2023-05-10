using Xunit;
using ZooManagement;
using System.Linq;

namespace ZooManagementTest
{
    public class FoodRate
    {
        public static ZooManager _ZooMock = new ZooManager(new MockDataSource());
        public static ZooManager _ZooFS = new ZooManager(new FSDataSource());

        [Fact]
        public void Carnivore()
        {
            // Mufasa is 100kg and as lion eat 10% of his bodyweight in meat
            // with meat as 12,56 : 
            var result = 238.64M;

            var MufasaMock = _ZooFS.Animals.First(x => x.Name == "Mufasa");
            Assert.Equal(result, MufasaMock.GetDaily(_ZooMock.Prices["Meat"], _ZooMock.Prices["Fruit"]));

            var MufasaFS = _ZooFS.Animals.First(x => x.Name == "Mufasa");
            Assert.Equal(result, MufasaFS.GetDaily(_ZooFS.Prices["Meat"], _ZooFS.Prices["Fruit"]));
        }

        [Fact]
        public void Herbivore()
        {
            // Chip is 100kg and as zebra eat 8% of his bodyweight in fruit
            // with fruit as 5,6 : 
            var result = 44.8M;

            var ChipMock = _ZooFS.Animals.First(x => x.Name == "Chip");
            Assert.Equal(result, ChipMock.GetDaily(_ZooMock.Prices["Meat"], _ZooMock.Prices["Fruit"]));

            var ChipFS = _ZooFS.Animals.First(x => x.Name == "Chip");
            Assert.Equal(result, ChipFS.GetDaily(_ZooFS.Prices["Meat"], _ZooFS.Prices["Fruit"]));
        }

        [Fact]
        public void OmnivoreWolf()
        {
            // Pon is 69kg and as wolf eat 7% of his bodyweight,
            // 90% in meat, 10% in fruit
            // with fruit as 5,6 & meat as 12,56 : 
            var result = 57.30312M;

            var PonMock = _ZooFS.Animals.First(x => x.Name == "Pon");
            Assert.Equal(result, PonMock.GetDaily(_ZooMock.Prices["Meat"], _ZooMock.Prices["Fruit"]));

            var PonFS = _ZooFS.Animals.First(x => x.Name == "Pon");
            Assert.Equal(result, PonFS.GetDaily(_ZooFS.Prices["Meat"], _ZooFS.Prices["Fruit"]));
        }

        [Fact]
        public void OmnivorePiranha()
        {
            // Anastasia is 0,5kg and as piranha eat 50% of his bodyweight,
            // 50% in meat, 50% in fruit
            // with fruit as 5,6 & meat as 12,56 : 
            var result = 2.27M;

            var AnastasiaMock = _ZooFS.Animals.First(x => x.Name == "Anastasia");
            Assert.Equal(result, AnastasiaMock.GetDaily(_ZooMock.Prices["Meat"], _ZooMock.Prices["Fruit"]));

            var AnastasiaFS = _ZooFS.Animals.First(x => x.Name == "Anastasia");
            Assert.Equal(result, AnastasiaFS.GetDaily(_ZooFS.Prices["Meat"], _ZooFS.Prices["Fruit"]));
        }


    }
}
