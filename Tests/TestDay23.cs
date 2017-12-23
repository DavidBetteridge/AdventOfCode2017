using Solutions;
using Xunit;

namespace Tests
{
    public class TestDay23
    {
        [Fact]
        public void Part1_Answer()
        {
            var day23 = new Day23();
            var actual = day23.Solve_Part1(PUZZLE_INPUT);
            Assert.Equal(5929, actual);
        }


        [Fact]
        public void Part2_Answer()
        {
            var day23 = new Day23();
            var actualH = day23.Solve_Part2(PUZZLE_INPUT);
            Assert.Equal(907, actualH);
        }

        private const string PUZZLE_INPUT = @"set b 79
set c b
jnz a 2
jnz 1 5
mul b 100
sub b -100000
set c b
sub c -17000
set f 1
set d 2
set e 53950
set g d
mul g e
sub g b
jnz g 2
set f 0
sub e -1
set g e
sub g b
jnz g -8
sub d -1
set g d
sub g b
jnz g -13
jnz f 2
sub h -1
set g b
sub g c
jnz g 2
jnz 1 3
sub b -17
jnz 1 -23";
    }
}
