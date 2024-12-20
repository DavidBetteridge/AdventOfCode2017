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
            (int fst, int snd) OrderTuple(int fst, int snd) => (fst: Math.Max(fst, snd), snd: Math.Min(fst, snd));

            int GetDivisor(IEnumerable<int> numbers)
            {
                var divisor = numbers
                               .SelectMany((fst, i) => numbers.Skip(i + 1).Select(snd => OrderTuple(fst, snd)))
                               .FirstOrDefault(t => t.fst % t.snd == 0);

                if (divisor.snd == 0)
                    return 0;
                else
                    return divisor.fst / divisor.snd;

            }

            return spreadsheet.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(a => int.Parse(a)))
                              .Select(GetDivisor)
                              .Sum();
        }
    }
}
