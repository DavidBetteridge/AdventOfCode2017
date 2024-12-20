using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay14
    {
        [Fact]
        public void Part1()
        {
            var day14 = new Day14();
            var (actual, _) = day14.Count("flqrgnkx");
            Assert.Equal(8108, actual);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day14 = new Day14();
            var (actual, _) = day14.Count("jzgqcdpd");
            Assert.Equal(8074, actual);
        }

        [Fact]
        public void Part2()
        {
            var day14 = new Day14();
            var (_, actual) = day14.Count("flqrgnkx");
            Assert.Equal(1242, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day14 = new Day14();
            var (_, actual) = day14.Count("jzgqcdpd");
            Assert.Equal(1212, actual);
        }
    }
}
