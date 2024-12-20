using Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestDay7
    {
        [Fact]
        public void Part1()
        {
            var given = @"";

            var day7 = new Day7();
            var actual = day7.FindBase(given);

            Assert.Equal("tknk", actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day7 = new Day7();
            var actual = day7.FindBase(TEST_INPUT);

            Assert.Equal("vgzejbd", actual);
        }


        [Fact]
        public void Part2()
        {
            var given = @"";

            var day7 = new Day7();
            var actual = day7.FindIdealWeight(given);

            Assert.Equal(60, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day7 = new Day7();
            var actual = day7.FindIdealWeight(TEST_INPUT);

            Assert.Equal(1226, actual);
        }

    }
}
