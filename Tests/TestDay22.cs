using Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Solutions.Day22;

namespace Tests
{
    public class TestDay22
    {
        [Fact]
        public void Part1()
        {
            var day22 = new Day22();
            var map = day22.LoadMap(@"..#
#..
...");
            var actual = day22.Part1(map, 70);
            Assert.Equal(41,actual);
        }

        [Fact]
        public void Part1b()
        {
            var day22 = new Day22();
            var map = day22.LoadMap(@"..#
#..
...");
            var actual = day22.Part1(map, 10000);
            Assert.Equal(5587, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day22 = new Day22();
            var map = day22.LoadMap(PUZZLE_INPUT);
            var actual = day22.Part1(map, 10000);
            Assert.Equal(5450, actual);
        }

        private const string PUZZLE_INPUT = @"#.....##.####.#.#########
.###..#..#..####.##....#.
..#########...###...####.
.##.#.##..#.#..#.#....###
...##....###..#.#..#.###.
###..#...######.####.#.#.
#..###..###..###.###.##..
.#.#.###.#.#...####..#...
##........##.####..##...#
.#.##..#.#....##.##.##..#
###......#..##.####.###.#
....#..###..#######.#...#
#####.....#.##.#..#..####
.#.###.#.###..##.#..####.
..#..##.###...#######....
.#.##.#.#.#.#...###.#.#..
##.###.#.#.###.#......#..
###..##.#...#....#..####.
.#.#.....#..#....##..#..#
#####.#.##..#...##..#....
##..#.#.#.####.#.##...##.
..#..#.#.####...#........
###.###.##.#..#.##.....#.
.##..##.##...#..#..#.#..#
#...####.#.##...#..#.#.##";
    }
}
