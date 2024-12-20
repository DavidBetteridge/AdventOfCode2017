using System.Linq;

namespace Solutions
{
    public class Day1
    {
        public int ComputeSum(string input)
        {
            return input.ToCharArray()
                        .Where((d, i) => d == input[(i + 1) % input.Length])
                        .Sum(d => d - '0');
        }

        public int ComputeSumForPart2(string input)
        {
            return input.ToCharArray()
                        .Where((d, i) => d == input[(i + (input.Length / 2)) % input.Length])
                        .Sum(d => d - '0');
        }
    }
}
