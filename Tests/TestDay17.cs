using Solutions;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestDay17
    {
        [Fact]
        public void Spin1()
        {
            var day17 = new Day17();
            var (newState, newPosition) = day17.Spin(new List<int>() { 0 }, 0, 3, 1);
            Assert.Equal(1, newPosition);
            Assert.Equal(new List<int>() { 0, 1 }, newState);
        }

        [Fact]
        public void Spin2()
        {
            var day17 = new Day17();
            var (newState, newPosition) = day17.Spin(new List<int>() { 0, 1 }, 1, 3, 2);
            Assert.Equal(1, newPosition);
            Assert.Equal(new List<int>() { 0, 2, 1 }, newState);
        }

        [Fact]
        public void Spin3()
        {
            var day17 = new Day17();
            var (newState, newPosition) = day17.Spin(new List<int>() { 0, 2, 1 }, 1, 3, 3);
            Assert.Equal(2, newPosition);
            Assert.Equal(new List<int>() { 0, 2, 3, 1 }, newState);
        }

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
    }
}
