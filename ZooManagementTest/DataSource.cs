using Xunit;
using ZooManagement;

namespace ZooManagementTest
{
    public class DataSource
    {
        public static FSDataSource fs = new FSDataSource();
        public static MockDataSource mock = new MockDataSource();

        [Fact]
        public void XMLParsing()
        {
            var mockSpecies = mock.GetSpecies();

            var mockAnimals = mock.GetAnimals(mockSpecies);
            var fsAnimals = fs.GetAnimals(mockSpecies);

            Assert.Equal(mockAnimals, fsAnimals);
        }        

        [Fact]
        public void CSVLineParsing()
        {
            var lion = new Species("Lion", 0.10, "meat");
            var wolf = new Species("Wolf", 0.09, "both", 90);

            var lionFS = fs.ArrayToSpecies(new string[] { "Lion", "0.10", "meat" });
            Assert.Equal(lion, lionFS);
            
            var wolfFS = fs.ArrayToSpecies(new string[] { "Wolf", "0.09", "both", "90%" });
            Assert.Equal(wolf, wolfFS);
        }

        [Fact]
        public void CSVFileParsing()
        {
            var speciesFS = fs.GetSpecies();
            var speciesMock = mock.GetSpecies();

            Assert.Equal(speciesMock, speciesFS);
        }

        [Fact]
        public void TextFileParsing()
        {
            var pricesFS = fs.GetPrices();
            var pricesMock = mock.GetPrices();

            Assert.Equal(pricesMock, pricesFS);
        }
    }
}
