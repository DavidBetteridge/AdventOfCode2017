using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay21
    {
        [Fact]
        public void VFlipPattern()
        {
            var day21 = new Day21();
            var actual = day21.ArrayToString(day21.VFlip(day21.StringToArray(@".#./..#/###")));
            Assert.Equal(@".#./#../###", actual);
        }

        [Fact]
        public void HFlipPattern()
        {
            var day21 = new Day21();
            var actual = day21.ArrayToString(day21.HFlip(day21.StringToArray(@".#./..#/###")));
            Assert.Equal(@"###/..#/.#.", actual);
        }

        [Fact]
        public void RotateClockwise()
        {
            var day21 = new Day21();
            var actual = day21.ArrayToString(day21.RotateClockwise(day21.StringToArray(@".#./..#/###")));
            Assert.Equal(@"#../#.#/##.", actual);
        }

        [Fact]
        public void ExpandPattern()
        {
            var day21 = new Day21();
            var actual = day21.ExpandPattern(@".#./..#/###");
            Assert.Equal(6, actual.Count);
        }

        [Fact]
        public void ExpandPatterns()
        {
            var day21 = new Day21();
            var actual = day21.ExpandPatterns(@"../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#");
            Assert.Equal(10, actual.Count);
        }

        [Fact]
        public void Part1()
        {
            var day21 = new Day21();
            var input = ".#./..#/###";
            var patterns = @"../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#";
            var actual = day21.Part1(input, patterns);
            Assert.Equal(4, actual);
        }

        //[Fact]
        //public void SplitUpGrid()
        //{
        //    var day21 = new Day21();
        //    var input = @"##.##./#..#../....../##.##./#..#../......";
        //    var actual = day21.SplitUpGrid(input);
        //    Assert.Equal(4, actual.Count);
        //}
    }

}

