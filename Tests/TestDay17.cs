using Solutions;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestDay17
    {
        [Fact]
        public void Part1()
        {
            var day17 = new Day17();
            var actual = day17.Part1(3);
            Assert.Equal(638, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day17 = new Day17();
            var actual = day17.Part1(329);
            Assert.Equal(725, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day17 = new Day17();
            var actual = day17.Part2(329);
            Assert.Equal(27361412, actual);
        }
    }
}
