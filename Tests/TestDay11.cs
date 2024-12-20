using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay11
    {
        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Part1(string route, int expected)
        {
            var day11 = new Day11();
            var (actual,_) = day11.Walk(route);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day11 = new Day11();
            var (actual, _) = day11.Walk(PUZZLE_INPUT);
            Assert.Equal(784, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day11 = new Day11();
            var (_, actual) = day11.Walk(PUZZLE_INPUT);
            Assert.Equal(1558, actual);
        }
  }
}
