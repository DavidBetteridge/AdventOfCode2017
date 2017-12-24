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

            return AddNode(blocks, 0);
        }

        private int AddNode(List<Block> blocks, int connectWith)
        {
            var result = 0;

            foreach (var block in blocks.Where(b => (b.LHS == connectWith || b.RHS == connectWith) && !b.Seen))
            {
                block.Seen = true;
                var localResult = block.LHS + block.RHS + AddNode(blocks, (block.LHS == connectWith ? block.RHS : block.LHS));
                result = Math.Max(result, localResult);
                block.Seen = false;
            }

            return result;
        }
    }
}
