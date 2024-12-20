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
        public void Part1(int square, int expectedResult)
        {
            var day3 = new Day3();
            var actual = day3.CalculateDistance(square);
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void Part1Answer()
        {
            var day3 = new Day3();
            var actual = day3.CalculateDistance(0);
            Assert.Equal(475, actual);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(6, 10)]
        [InlineData(800, 806)]
        public void Part2(int valueBiggerThan, int expectedResult)
        {
            var day3 = new Day3();
            var actual = day3.FindFirstValueBiggerThan(valueBiggerThan);
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void Part2Answer()
        {
            var day3 = new Day3();
            var actual = day3.FindFirstValueBiggerThan(277678);
            Assert.Equal(279138,actual);
        }

    }
}
