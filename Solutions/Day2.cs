using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day2
    {
        public int ComputeChecksum(string spreadsheet)
        {
            return spreadsheet.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)))
                              .Select(row => row.Max() - row.Min())
                              .Sum();
        }

        public int ComputeChecksumPart2(string spreadsheet)
        {
            int GetDivisor(IEnumerable<int> numbers)
            {
                var orderedNumbers = numbers.OrderBy(a => a).ToList();

                for (int start = 0; start < orderedNumbers.Count() - 1; start++)
                {
                    for (int end = start + 1; end < orderedNumbers.Count(); end++)
                    {
                        if (orderedNumbers[end] % orderedNumbers[start] == 0)
                        {
                            return orderedNumbers[end] / orderedNumbers[start];
                        }
                    }
                }
                return 0;
            }

            return spreadsheet.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(a => int.Parse(a)))
                              .Select(GetDivisor)
                              .Sum();
        }
    }
}
