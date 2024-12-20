using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay4
    {
        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void Part1(string input, bool expectedResult)
        {
            var day4 = new Day4();
            var actualResult = day4.CheckPassPhrase(input);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Part1Answer()
        {
         
            var day4 = new Day4();
            var actualResult = day4.CountValidPassPhrases(TEST_INPUT);
            Assert.Equal(466,actualResult);
        }

        [Theory]
        [InlineData("abcde fghij", true)]
        [InlineData("abcde xyz ecdab", false)]
        [InlineData("a ab abc abd abf abj", true)]
        [InlineData("iiii oiii ooii oooi oooo", true)]
        [InlineData("oiii ioii iioi iiio", false)]
        public void Part2(string input, bool expectedResult)
        {
            var day4 = new Day4();
            var actualResult = day4.CheckPassPhraseWithExtraRules(input);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Part2Answer()
        {
            var day4 = new Day4();
            var actualResult = day4.CountValidPassPhrasesWithExtraRules(TEST_INPUT);
            Assert.Equal(251, actualResult);
        }

    }

}
