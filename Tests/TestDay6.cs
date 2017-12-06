using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay6
    {
        [Theory]
        [InlineData("0 2 7 0", "2 4 1 2")]
        [InlineData("2 4 1 2", "3 1 2 3")]
        [InlineData("3 1 2 3", "0 2 3 4")]
        [InlineData("0 2 3 4", "1 3 4 1")]
        [InlineData("1 3 4 1", "2 4 1 2")]
        public void Part1_NextIteration(string given, string expect)
        {
            var day6 = new Day6();
            var actual = day6.NextIteration(given);

            Assert.Equal(expect, actual);
        }

        [Theory]
        [InlineData("0 2 7 0", 5)]
        public void Part1(string given, int expect)
        {
            var day6 = new Day6();
            var actual = day6.RepeatsAfter(given);

            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day6 = new Day6();
            var actual = day6.RepeatsAfter(TEST_DATA);

            Assert.Equal(100, actual);
        }

        private const string TEST_DATA = @"14 0 15 12 11 11 3 5 1 6 8 4 9 1 8 4";
    }
}