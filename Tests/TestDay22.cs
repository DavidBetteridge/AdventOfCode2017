using Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Solutions.Day22_Part1;

namespace Tests
{
    public class TestDay22
    {
        [Fact]
        public void Part1()
        {
            var day22 = new Day22_Part1();
            var map = day22.LoadMap(@"..#
#..
...");
            var actual = day22.Part1(map, 70);
            Assert.Equal(41,actual);
        }

        [Fact]
        public void Part1b()
        {
            var day22 = new Day22_Part1();
            var map = day22.LoadMap(@"..#
#..
...");
            var actual = day22.Part1(map, 10000);
            Assert.Equal(5587, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day22 = new Day22_Part1();
            var map = day22.LoadMap(PUZZLE_INPUT);
            var actual = day22.Part1(map, 10000);
            Assert.Equal(5450, actual);
        }


        [Fact]
        public void Part2()
        {
            var day22 = new Day22_Part2();
            var map = day22.LoadMap(@"..#
#..
...");
            var actual = day22.Part2(map, 100);
            Assert.Equal(26, actual);
        }

        [Fact]
        public void Part2b()
        {
            var day22 = new Day22_Part2();
            var map = day22.LoadMap(@"..#
#..
...");
            var actual = day22.Part2(map, 10000000);
            Assert.Equal(2511944, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day22 = new Day22_Part2();
            var map = day22.LoadMap(PUZZLE_INPUT);
            var actual = day22.Part2(map, 10000000);
            Assert.Equal(2511957, actual);
        }

    }
}
