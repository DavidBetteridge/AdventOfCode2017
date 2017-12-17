using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Solutions
{
    public class Day17
    {
        private class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
        }

        public int Part1(int numberOfSteps)
        {
            var root = new Node() { Value = 0 };
            root.NextNode = root;

            var current = root;
            var next = 1;
            for (int nextValue = 1; nextValue <= 2017; nextValue++)
            {
                for (int i = 1; i <= numberOfSteps; i++)
                {
                    current = current.NextNode;
                }

                var newNode = new Node() { Value = next };
                newNode.NextNode = current.NextNode;
                current.NextNode = newNode;

                current = newNode;
                next++;
            }

            return current.NextNode.Value;
        }

        public int Part2(int numberOfSteps)
        {
            var position = 0;
            var lastNumber = 0;
            for (int nextNumber = 1; nextNumber <= 50000000; nextNumber++)
            {
                position = (position + numberOfSteps) % nextNumber;

                if (position == 0)
                {
                    lastNumber = nextNumber;
                }
                position++;
            }
            return lastNumber;
        }
    }
}
