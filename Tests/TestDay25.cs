using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay25
    {
        [Fact]
        public void Part1_Answer()
        {
            var day25 = new Day25();
            var actual = day25.SolvePart1();
            Assert.Equal(4387, actual);
        }
    }
}
