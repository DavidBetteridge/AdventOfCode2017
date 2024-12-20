using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay2
    {
        [Fact]
        public void Part1()
        {
            var day2 = new Day2();
            var actualResult = day2.ComputeChecksum(@"5 1 9 5 
7 5 3 
2 4 6 8");
            Assert.Equal(18, actualResult);
        }

        [Fact]
        public void Part1Answer()
        {
            var day2 = new Day2();
            var actualResult = day2.ComputeChecksum(TEST_INPUT);
            Assert.Equal(51139, actualResult);
        }

        [Fact]
        public void Part2()
        {
            var day2 = new Day2();
            var actualResult = day2.ComputeChecksumPart2(@"5 9 2 8
9 4 7 3
3 8 6 5");
            Assert.Equal(9, actualResult);
        }

        [Fact]
        public void Part2Answer()
        {
            var day2 = new Day2();
            var actualResult = day2.ComputeChecksumPart2(TEST_INPUT);
            Assert.Equal(272, actualResult);
        }

        private const string TEST_INPUT = @"";
    }
}
