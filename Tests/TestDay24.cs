using Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestDay24
    {
        [Fact]
        public void Part1()
        {
            var day24 = new Day24();
            var actual = day24.SolvePart1(@"0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10");
            Assert.Equal(31, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day24 = new Day24();
            var actual = day24.SolvePart1(PUZZLE_INPUT);
            Assert.Equal(1868, actual);
        }


        [Fact]
        public void Part2()
        {
            var day24 = new Day24();
            var actual = day24.SolvePart2(@"0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10");
            Assert.Equal(19, actual);
        }


        [Fact]
        public void Part2_Answer()
        {
            var day24 = new Day24();
            var actual = day24.SolvePart2(PUZZLE_INPUT);
            Assert.Equal(1841, actual);
        }


    }
}
