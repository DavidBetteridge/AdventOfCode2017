using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay10
    {

        [Fact]
        public void Part1()
        {
            var day10 = new Day10();
            var actual = day10.SolvePart1(5, "3,4,1,5");
            Assert.Equal(12, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day10 = new Day10();
            var actual = day10.SolvePart1(256, PUZZLE_INPUT);
            Assert.Equal(37230, actual);
        }

        [Theory]
        [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Part2(string given, string expect)
        {
            var day10 = new Day10();
            var actual = day10.CalculateHash(given);
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day10 = new Day10();
            var actual = day10.CalculateHash(PUZZLE_INPUT);
            Assert.Equal("70b856a24d586194331398c7fcfa0aaf", actual);
        }


    }
}
