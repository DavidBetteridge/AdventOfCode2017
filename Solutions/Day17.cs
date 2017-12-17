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


        public (List<int> newState, int newPosition) Spin(List<int> initialState, int initialPosition, int numberOfSteps, int nextValue)
        {
            var location = (initialPosition + numberOfSteps) % initialState.Count;
            if (location == 0) Debug.WriteLine(nextValue);
            initialState.Insert(location + 1, nextValue);
            return (initialState, location + 1);
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

            var root = new Node() { Value = 0 };
            root.NextNode = root;

            var current = root;
            var next = 1;
            for (int nextValue = 1; nextValue <= 50000000; nextValue++)
            {
                for (int i = 1; i <= numberOfSteps; i++)
                {
                    current = current.NextNode;
                }

                Debug.WriteLineIf(current.Value == 0, nextValue);

                var newNode = new Node() { Value = next };
                newNode.NextNode = current.NextNode;
                current.NextNode = newNode;

                current = newNode;
                next++;
            }

            return root.NextNode.Value;
        }
    }
}
