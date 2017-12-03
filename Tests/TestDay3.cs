using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay3
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void ChecksAnswersToPartA(int square, int expectedResult)
        {
            var day3 = new Day3();
            var actual = day3.CalculateDistance(square);
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void SolvePartA()
        {
            var day3 = new Day3();
            var actual = day3.CalculateDistance(277678);
            Assert.True(true);
        }

    }
}
