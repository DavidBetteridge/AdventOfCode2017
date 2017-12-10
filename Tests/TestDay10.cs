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
            var actual = day10.Solve(5, "3,4,1,5");
            Assert.Equal(12, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day10 = new Day10();
            var actual = day10.Solve(256, PUZZLE_INPUT);
            Assert.Equal(12, actual);
        }


        private const string PUZZLE_INPUT = "147,37,249,1,31,2,226,0,161,71,254,243,183,255,30,70";

    }
}
