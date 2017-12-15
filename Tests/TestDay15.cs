using Solutions;
using System.Linq;
using Xunit;

namespace Tests
{
    public class TestDay15
    {
        [Theory]
        [InlineData(65, 1092455)]
        [InlineData(1092455, 1181022009)]
        [InlineData(1181022009, 245556042)]
        [InlineData(245556042, 1744312007)]
        [InlineData(1744312007, 1352636452)]
        public void NextValue_A(long previous, long expected)
        {
            var day15 = new Day15();
            var actual = day15.NextValue(previous, 16807);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get5th()
        {
            var day15 = new Day15();
            var actual = day15.GeneratorA(65).Where(a => a % 4 == 0).Take(5).Last();
            Assert.Equal(740335192, actual);
        }

        [Theory]
        [InlineData(1092455,430625591,false)]
        [InlineData(1181022009,1233683848, false)]
        [InlineData(245556042,1431495498, true)]
        public void CompareValues(long lhs, long rhs, bool expected)
        {
            var day15 = new Day15();
            var actual = day15.Compare(lhs, rhs);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part1()
        {
            var day15 = new Day15();
            var actual = day15.CountMatches(65, 8921);
            Assert.Equal(588, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day15 = new Day15();
            var actual = day15.CountMatches(591, 393);
            Assert.Equal(619, actual);
        }

        [Fact]
        public void Part2()
        {
            var day15 = new Day15();
            var actual = day15.CountMatches2(65, 8921);
            Assert.Equal(309, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day15 = new Day15();
            var actual = day15.CountMatches2(591, 393);
            Assert.Equal(290, actual);
        }
    }
}
