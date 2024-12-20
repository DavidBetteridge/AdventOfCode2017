using Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Solutions.Day20;

namespace Tests
{
    public class TestDay20
    {
        [Fact]
        public void Part1()
        {
            var given = @"p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>
p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>";

            var day20 = new Day20();
            var actual = day20.FindClosest(given);
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day20 = new Day20();
            var actual = day20.FindClosest(PUZZLE_INPUT);
            Assert.Equal(308, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day20 = new Day20();
            var actual = day20.FindRemaining(PUZZLE_INPUT);
            Assert.Equal(504, actual);
        }



    }
}

