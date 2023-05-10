using Xunit;
using ZooManagement;

namespace ZooManagementTest
{
    public class DataSource
    {
        public static FSDataSource _fs = new FSDataSource();
        public static MockDataSource _mock = new MockDataSource();

        [Fact]
        public void XMLParsing()
        {
            var mockSpecies = _mock.GetSpecies();

            var mockAnimals = _mock.GetAnimals(mockSpecies);
            var fsAnimals = _fs.GetAnimals(mockSpecies);

            Assert.Equal(mockAnimals, fsAnimals);
        }        

        [Fact]
        public void CSVLineParsing()
        {
            var lion = new Species("Lion", 0.10f, "meat");
            var wolf = new Species("Wolf", 0.09f, "both", 90);

            var lionFS = _fs.ArrayToSpecies(new string[] { "Lion", "0.10", "meat" });
            Assert.Equal(lion, lionFS);
            
            var wolfFS = _fs.ArrayToSpecies(new string[] { "Wolf", "0.09", "both", "90%" });
            Assert.Equal(wolf, wolfFS);
        }

        [Fact]
        public void CSVFileParsing()
        {
            var speciesFS = _fs.GetSpecies();
            var speciesMock = _mock.GetSpecies();

            Assert.Equal(speciesMock, speciesFS);
        }

        [Fact]
        public void TextFileParsing()
        {
            var pricesFS = _fs.GetPrices();
            var pricesMock = _mock.GetPrices();

            Assert.Equal(pricesMock, pricesFS);
        }
    }
}
