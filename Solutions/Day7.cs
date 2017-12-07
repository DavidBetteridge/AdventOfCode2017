using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day7
    {
        public string FindBase(string given)
        {
            var rootNode = BuildTree(given);
            return rootNode.Name;
        }

        private static Node BuildTree(string given)
        {
            var nodes = new Dictionary<string, Node>();
            var lines = given.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var name = line.Substring(0, line.IndexOf(' '));

                var s = line.IndexOf('(') + 1;
                var weight = line.Substring(s, line.IndexOf(')') - s);
                var newNode = new Node() { Name = name, Children = new List<Node>(),  Weight= int.Parse(weight) };
                nodes.Add(name, newNode);
            }

            foreach (var line in lines.Where(l => l.Contains("->")))
            {
                var name = line.Substring(0, line.IndexOf(' '));
                var children = line.Substring(line.IndexOf("->") + 2).Split(new[] { ", " }, System.StringSplitOptions.RemoveEmptyEntries);
                var thisNode = nodes[name];
                foreach (var child in children)
                {
                    var childNode = nodes[child.Trim()];
                    childNode.Parent = thisNode;
                    thisNode.Children.Add(childNode);
                }
            }

            // Pick any node and walk up till we find the root.
            var node = nodes.First().Value;
            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }

        public int FindIdealWeight(string given)
        {
            var rootNode = BuildTree(given);

            return CalculateWeights(rootNode);
        }
 

        private int CalculateWeights(Node node)
        {
            node.TotalWeight = node.Weight;
            if (!node.Children.Any()) return -1;  //Leaf node

            foreach (var child in node.Children)
            {
                var adjustment = CalculateWeights(child);
                if (adjustment != -1) return adjustment;
                node.TotalWeight += child.TotalWeight;
            }

            // Do we have a problem with any of our children?
            var children = node.Children.GroupBy(a => a.TotalWeight);
            if (children.Count() > 1)
            {
                // One of our children has a different value
                var wrongChild = children.First(a => a.Count() == 1).First();
                var correctChild = children.First(a => a.Count() > 1).First();
                var adjustment = correctChild.TotalWeight - wrongChild.TotalWeight;
                return wrongChild.Weight + adjustment;
            }

            return -1;
        }

        private class Node
        {
            public string Name { get; set; }
            public int Weight { get; set; }

            public Node Parent { get; set; }
            public List<Node> Children { get; set; }

            public int TotalWeight { get; set; }
        }
    }
}
