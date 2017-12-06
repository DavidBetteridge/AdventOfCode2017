using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day6
    {
        public string NextIteration(string given)
        {
            var numbers = given
                            .Split(' ')
                            .Select(a => int.Parse(a))
                            .ToArray();

            // Which block contains the highest allocation,  picking
            // the first one in the case of a tie.
            var largest = 0;
            var largestBlock = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > largest)
                {
                    largest = numbers[i];
                    largestBlock = i;
                }
            }

            // Empty out the highest block
            numbers[largestBlock] = 0;

            // Allocate the amount to each block in turn.
            //var index = (largestBlock + 1) % numbers.Count();
            //var leftToAllocate = largest;
            //while (leftToAllocate > 0)
            //{
            //    numbers[index]++;
            //    leftToAllocate--;
            //    index = (index + 1) % numbers.Count();
            //}

            var sharedAllocation = largest / numbers.Count();
            var leftOver = largest % numbers.Count();
            for (int i = largestBlock + 1; i < numbers.Length + largestBlock + 1; i++)
            {
                numbers[i % numbers.Length] += sharedAllocation;
                if (leftOver > 0)
                {
                    numbers[i % numbers.Length]++;
                    leftOver--;
                }
            }

            return string.Join(" ", numbers);
        }

        public int NumberOfCycles(string given)
        {
            var seen = new Dictionary<string, int>();
            var currentPattern = given;
            var result = 0;

            while (!seen.ContainsKey(currentPattern))
            {
                seen.Add(currentPattern, result);
                result++;
                currentPattern = NextIteration(currentPattern);
            }

            return result - seen[currentPattern];
        }

        public int RepeatsAfter(string given)
        {
            var seen = new HashSet<string>();
            var currentPattern = given;
            var result = 0;

            while (!seen.Contains(currentPattern))
            {
                seen.Add(currentPattern);
                result++;
                currentPattern = NextIteration(currentPattern);
            }

            return result;

        }
    }
}
