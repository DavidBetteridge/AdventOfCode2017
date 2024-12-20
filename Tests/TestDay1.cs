using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay1
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void Part1(string input, int expected)
        {
            var day1 = new Day1();
            var actualResult = day1.ComputeSum(input);
            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public void Part1Answer()
        {
            var input = "";
            var day1 = new Day1();
            var actualResult = day1.ComputeSum(input);
            Assert.Equal(1044, actualResult);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void Part2(string input, int expected)
        {
            var day1 = new Day1();
            var actualResult = day1.ComputeSumForPart2(input);
            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public void Part2Answer()
        {
            var input = "";
            var day1 = new Day1();
            var actualResult = day1.ComputeSumForPart2(input);
            Assert.Equal(1054,actualResult);
        }
    }
}
