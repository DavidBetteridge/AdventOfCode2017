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
                            .ToList();
            var size = numbers.Count();

            // Which block contains the highest allocation,  picking
            // the first one in the case of a tie.
            var largestValue = numbers.Max(value => value);
            var largestBlock = numbers.FindIndex(b => b == largestValue);

            // How many do we have to give out?
            var sharedAllocation = largestValue / size;
            var leftOver = largestValue % size;

            numbers = numbers
                        .Select((value, index) =>
                        {
                            if (index >= largestBlock + 1 && index <= largestBlock + leftOver)
                            {
                                //Between the largest block and the end
                                return value + sharedAllocation + 1;
                            }
                            else if (index <= ((largestBlock + leftOver) - size))
                            {
                                //between the start of largest block
                                return value + sharedAllocation + 1;
                            }
                            else if (index == largestBlock)
                            {
                                //the largest block
                                return sharedAllocation;
                            }
                            else
                            {
                                //where we have ran out of extra
                                return value + sharedAllocation;
                            }
                        })
                        .ToList();

            return string.Join(" ", numbers);
        }

        public (int repeatsAfter, int loopSize) FindLoop(string given)
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

            return (result, result - seen[currentPattern]);
        }
    }
}
