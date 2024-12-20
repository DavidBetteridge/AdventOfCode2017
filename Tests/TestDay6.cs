using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay6
    {
        [Theory]
        [InlineData("0 2 7 0", "2 4 1 2")]
        [InlineData("2 4 1 2", "3 1 2 3")]
        [InlineData("3 1 2 3", "0 2 3 4")]
        [InlineData("0 2 3 4", "1 3 4 1")]
        [InlineData("1 3 4 1", "2 4 1 2")]
        public void Part1_NextIteration(string given, string expect)
        {
            var day6 = new Day6();
            var actual = day6.NextIteration(given);

            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Part1()
        {
            var day6 = new Day6();
            var (repeatsAfter, _) = day6.FindLoop("0 2 7 0");

            Assert.Equal(5, repeatsAfter);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day6 = new Day6();
            var (repeatsAfter, _) = day6.FindLoop(TEST_DATA);

            Assert.Equal(11137, repeatsAfter);
        }

        [Theory]
        [InlineData("0 2 7 0", 4)]
        public void Part2(string given, int expect)
        {
            var day6 = new Day6();
            var (_, sizeOfLoop) = day6.FindLoop(given);

            Assert.Equal(expect, sizeOfLoop);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day6 = new Day6();
            var (_, sizeOfLoop) = day6.FindLoop(TEST_DATA);

            Assert.Equal(1037, sizeOfLoop);
        }

    }
}