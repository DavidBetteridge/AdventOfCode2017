using System.Linq;

namespace Solutions
{
    public class Day10
    {
        public int SolvePart1(int numberOfElements, string lengths)
        {
            var hasher = new KnotHash();

            var list = hasher.BuildListOfNumbers(numberOfElements);
            var finalLengths = lengths.Split(',').Select(l => byte.Parse(l)).ToArray();
            hasher.DoSingleRound(finalLengths, list, currentPosition: 0, skipSize: 0);

            return list[0] * list[1];
        }

        public string CalculateHash(string given)
        {
            var hasher = new KnotHash();
            return hasher.CalculateHash(given);
        }
    }
}
