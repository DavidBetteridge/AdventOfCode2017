using Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestDay14
    {
        [Fact]
        public void CalculateHash()
        {
            var day14 = new Day14();
            var hash = day14.CalculateHash("flqrgnkx-0");
        }

        [Fact]
        public void HashToBinary()
        {
            var day14 = new Day14();
            var hash = day14.HashToBinary("a0c2017");
            Assert.True(hash.StartsWith("1010000011000010000000010111"));
        }

        [Fact]
        public void Part1()
        {
            var day14 = new Day14();
            var actual = day14.CountUsedSquares("flqrgnkx");
            Assert.Equal(8108, actual);

        }

        [Fact]
        public void Part1_Answer()
        {
            var day14 = new Day14();
            var actual = day14.CountUsedSquares("jzgqcdpd");
            Assert.Equal(8074, actual);

        }
    }
}
