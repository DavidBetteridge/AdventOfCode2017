using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay23
    {
        [Fact]
        public void Part1_Answer()
        {
            var day23 = new Day23();
            var actual = day23.Solve_Part1(PUZZLE_INPUT);
            Assert.Equal(5929, actual);
        }


        [Fact]
        public void Part2_Answer()
        {
            var day23 = new Day23();
            var actualH = day23.Solve_Part2(PUZZLE_INPUT);
            Assert.Equal(907, actualH);
        }

    }
}
