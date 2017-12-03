using System;
using System.Linq;

namespace Solutions
{
    public class Day1
    {
        public int ComputeSum(string input)
        {
            // Put the first number on the end to allow for the circular array
            var fullInput = input + input.Substring(0, 1);
            return input.ToCharArray()
                        .Where((d, i) => d == fullInput[i + 1])
                        .Sum(d => d - '0');
        }

        public int ComputeSumForPart2(string input)
        {
            var offset = input.Length / 2;
            return input.ToCharArray()
                        .Where((d, i) => d == input[(i + offset) % input.Length])
                        .Sum(d => d - '0');
        }
    }
}
