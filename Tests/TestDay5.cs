using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay5
    {
        [Fact]
        public void Part1()
        {
            var day5 = new Day5();
            var actual = day5.ExecuteToEnd("0 3 0 1 -3", 0, x => ++x);

            Assert.Equal(5, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day5 = new Day5();
            var actual = day5.ExecuteToEnd(TEST_INPUT, 0, x => ++x);

            Assert.Equal(355965, actual);
        }


        [Fact]
        public void Part2()
        {
            var day5 = new Day5();
            var actual = day5.ExecuteToEnd("0 3 0 1 -3", 0, x => (x >= 3 ? --x : ++x));

            Assert.Equal(10, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day5 = new Day5();
            var actual = day5.ExecuteToEnd(TEST_INPUT, 0, x => (x >= 3 ? --x : ++x));

            Assert.Equal(26948068, actual);
        }

    }
}
