using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day24
    {
        class Block
        {
            public int LHS { get; set; }
            public int RHS { get; set; }
            public bool Seen { get; set; }
        }

        public int SolvePart1(string input)
        {
            var blocks = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(l => new Block() { LHS = int.Parse(l.Split('/')[0]), RHS = int.Parse(l.Split('/')[1]) })
                               .ToList();

            return AddNodeForPart1(blocks, 0);
        }

        private int AddNodeForPart1(List<Block> blocks, int connectWith)
        {
            var result = 0;

            foreach (var block in blocks.Where(b => (b.LHS == connectWith || b.RHS == connectWith) && !b.Seen))
            {
                block.Seen = true;
                var localResult = block.LHS + block.RHS + AddNodeForPart1(blocks, (block.LHS == connectWith ? block.RHS : block.LHS));
                result = Math.Max(result, localResult);
                block.Seen = false;
            }

            return result;
        }


        public int SolvePart2(string input)
        {
            var blocks = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(l => new Block() { LHS = int.Parse(l.Split('/')[0]), RHS = int.Parse(l.Split('/')[1]) })
                               .ToList();

            var (_, result) = AddNodeForPart2(blocks, 0, 0);
            return result;
        }

        private (int lengthOfBridge, int strengthOfBridge) AddNodeForPart2(List<Block> blocks, int currentLength, int connectWith)
        {
            var longestSoFar = currentLength;
            var strength = 0;

            foreach (var block in blocks.Where(b => (b.LHS == connectWith || b.RHS == connectWith) && !b.Seen))
            {
                block.Seen = true;
                var needToConnectWith = (block.LHS == connectWith ? block.RHS : block.LHS);
                var (l, s) = AddNodeForPart2(blocks, currentLength + 1, needToConnectWith);
                if (l > longestSoFar)
                {
                    longestSoFar = l;
                    strength = s + block.LHS + block.RHS;
                }
                else if (l == longestSoFar && ((s + block.LHS + block.RHS) > strength))
                {
                    longestSoFar = l;
                    strength = s + block.LHS + block.RHS;
                }
                block.Seen = false;
            }

            return (longestSoFar, strength);
        }

    }
}
