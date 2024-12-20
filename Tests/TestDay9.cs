using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay9
    {

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 3)]
        [InlineData("{{},{}}", 3)]
        [InlineData("{{{},{},{{}}}}", 6)]
        [InlineData("{<{},{},{{}}>}", 1)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<a>},{<a>},{<a>},{<a>}}", 5)]
        [InlineData("{{<!>},{<!>},{<!>},{<a>}}", 2)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 5)]
        public void Part1_CountGroups(string stream, int expected)
        {
            var day9 = new Day9();
            var actual = day9.CountGroups(stream);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Part1(string stream, int expected)
        {
            var day9 = new Day9();
            var actual = day9.ScoreGroups(stream);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("{}", 0)]
        [InlineData("{<random characters>}", 17)]
        [InlineData("{<<<<>}", 3)]
        [InlineData("{<{!>}>}", 2)]
        [InlineData("{<!!>}", 0)]
        [InlineData("{<!!!>>}", 0)]
        [InlineData(@"{<{o""i!a,<{i<a>}", 10)]
        public void Part2(string stream, int expected)
        {
            var day9 = new Day9();
            var actual = day9.CountGarbage(stream);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Part1_Answer()
        {
            var day9 = new Day9();
            var actual = day9.ScoreGroups(PUZZLE_INPUT);
            Assert.Equal(7640, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day9 = new Day9();
            var actual = day9.CountGarbage(PUZZLE_INPUT);
            Assert.Equal(4368, actual);
        }

    }
}
