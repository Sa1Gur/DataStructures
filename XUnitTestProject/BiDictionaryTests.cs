using System.Linq;
using DataStructures;
using Xunit;

namespace XUnitTestProject
{
    public class BiDictionaryTests
    {
        private BiDictionary<string, int> typesMap;

        public BiDictionaryTests()
        {
            typesMap = new BiDictionary<string, int>
            {
                {"0", 0},
                {"1", 1},
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"9", 9}
            };
        }

        [Theory]
        [InlineData("1", 1)]
        public void ShouldConverStringToInt(string stringNumber, int number) =>
            Assert.Equal(stringNumber, typesMap[number].First());

        [Theory]
        [InlineData(1, "1")]
        public void ShouldConvertIntToString(int number, string stringNumber) =>
            Assert.Equal(number, typesMap[stringNumber].First());
    }
}