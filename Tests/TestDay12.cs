using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay12
    {
        [Fact]
        public void Part1()
        {
            var given = @"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5";
            var day12 = new Day12();
            var actual = day12.CountConnections(given);
            Assert.Equal(6, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day12 = new Day12();
            var actual = day12.CountConnections(PUZZLE_INPUT);
            Assert.Equal(175, actual);
        }


        [Fact]
        public void Part2()
        {
            var given = @"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5";
            var day12 = new Day12();
            var actual = day12.CountGroups(given);
            Assert.Equal(2, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day12 = new Day12();
            var actual = day12.CountGroups(PUZZLE_INPUT);
            Assert.Equal(213, actual);
        }

    }
}
