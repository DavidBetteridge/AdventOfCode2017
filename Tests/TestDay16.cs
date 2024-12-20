using Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestDay16
    {
        [Fact]
        public void Spin_1()
        {
            var day16 = new Day16();
            var programs = new[] { 'a', 'b', 'c', 'd', 'e' };
            var actual = day16.Spin(programs, 1);
            Assert.Equal(new[] { 'e', 'a', 'b', 'c', 'd' }, actual);
        }

        [Fact]
        public void Spin_3()
        {
            var day16 = new Day16();
            var programs = new[] { 'a', 'b', 'c', 'd', 'e' };
            var actual = day16.Spin(programs, 3);
            Assert.Equal(new[] { 'c', 'd', 'e', 'a', 'b' }, actual);
        }

        [Fact]
        public void Exchange()
        {
            var day16 = new Day16();
            var programs = new[] { 'e', 'a', 'b', 'c', 'd' };
            var actual = day16.Exchange(programs, 3, 4);
            Assert.Equal(new[] { 'e', 'a', 'b', 'd', 'c' }, actual);
        }

        [Fact]
        public void Partner()
        {
            var day16 = new Day16();
            var programs = new[] { 'e', 'a', 'b', 'd', 'c' };
            var actual = day16.Partner(programs, 'e', 'b');
            Assert.Equal(new[] { 'b', 'a', 'e', 'd', 'c' }, actual);
        }

        [Fact]
        public void Part1()
        {
            var day16 = new Day16();
            var programs = new[] { 'a', 'b', 'c', 'd', 'e' };
            var moves = "s1,x3/4,pe/b";
            var actual = day16.Dance(programs, moves,1);
            var actualString = string.Join("", actual);
            Assert.Equal("baedc", actualString);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day16 = new Day16();
            var programs = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
            var actual = day16.Dance(programs, PUZZLE_INPUT, 1);
            var actualString = string.Join("", actual);
            Assert.Equal("ociedpjbmfnkhlga", actualString);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day16 = new Day16();
            var programs = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
            var actual = day16.Dance(programs, PUZZLE_INPUT, 1000000000);
            var actualString = string.Join("", actual);
            Assert.Equal("gnflbkojhicpmead", actualString);
        }

    }
}
