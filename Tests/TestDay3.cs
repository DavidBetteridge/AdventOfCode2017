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

        [Theory]
        [InlineData(3, 4)]
        [InlineData(6, 10)]
        [InlineData(800, 806)]
        public void CheckAnswersForPartB(int valueBiggerThan, int expectedResult)
        {
            var day3 = new Day3();
            var actual = day3.FindFirstValueBiggerThan(valueBiggerThan);
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void SolvePartB()
        {
            var day3 = new Day3();
            var actual = day3.FindFirstValueBiggerThan(277678);
            Assert.True(true);
        }

    }
}
