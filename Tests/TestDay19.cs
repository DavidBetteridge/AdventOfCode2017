using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay19
    {
        [Fact]
        public void Part1()
        {
            var day19 = new Day19();
            var (_, actual) = day19.Walk(@"     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ 
");
            Assert.Equal("ABCDEF", actual);
        }

        [Fact]
        public void Part2()
        {
            var day19 = new Day19();
            var (steps,_) = day19.Walk(@"     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ 
");
            Assert.Equal(38, steps);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day19 = new Day19();
            var (_, actual) = day19.Walk(PUZZLE_INPUT);
            Assert.Equal("YOHREPXWN", actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day19 = new Day19();
            var (steps, _) = day19.Walk(PUZZLE_INPUT);
            Assert.Equal(16734, steps);
        }

    }
}
