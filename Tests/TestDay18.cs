using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay18
    {
        [Fact]
        public void Part1()
        {
            var day18 = new Day18();
            var commands = @"set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2";
            var actual = day18.Solve(commands);
            Assert.Equal(4, actual); 
        }

        [Fact]
        public void Part1_Answer()
        {
            var day18 = new Day18();
            var actual = day18.Solve(PUZZLE_INPUT);
            Assert.Equal(3423, actual);
        }

        [Fact]
        public void Part2()
        {
            var day18 = new Day18();
            var actual = day18.Solve2(@"snd 1
snd 2
snd p
rcv a
rcv b
rcv c
rcv d");
            Assert.Equal(3, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day18 = new Day18();
            var actual = day18.Solve2(PUZZLE_INPUT);
            Assert.Equal(7493, actual);
        }

    }
}
