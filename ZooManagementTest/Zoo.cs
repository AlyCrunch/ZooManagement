using System;
using System.Collections.Generic;
using Xunit;

namespace ZooManagementTest
{
    public class Zoo
    {
        [Fact]
        public void PricesDictionary()
        {
            var expected = new Dictionary<string, double>()
            {
                { "Meat", 12.56 },
                { "Fruit", 5.60 }
            };

            var strFile = $@"Meat=12.56
Fruit=5.60";

            var result = ZooManagement.Zoo.PricesToDictionary(strFile);
            Assert.Equal(expected, result);
        }
    }
}
