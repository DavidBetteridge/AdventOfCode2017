using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay13
    {
        [Fact]
        public void Part1()
        {
            var day13 = new Day13();
            var actual = day13.Calculate(@"0: 3
1: 2
4: 4
6: 4");
            Assert.Equal(24, actual);
        }

        [Fact]
        public void Part2()
        {
            var day13 = new Day13();
            var actual = day13.Escape(@"0: 3
1: 2
4: 4
6: 4",6);
            Assert.Equal(10, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day13 = new Day13();
            var actual = day13.Calculate(PUZZLE_INPUT);
            Assert.Equal(1632, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day13 = new Day13();
            var actual = day13.Escape(PUZZLE_INPUT,98);
            Assert.Equal(3834136, actual);
        }


    }
}
