using System.Linq;
using System.Collections.Generic;
using System;

namespace Solutions
{
    public class Day12
    {
        public int CountConnections(string connections)
        {
            var nodes = Build(connections);
            var rootNode = nodes["0"];
            return Count(rootNode,1);
        }

        private static Dictionary<string, Node> Build(string connections)
        {
            var nodes = new Dictionary<string, Node>();
            var lines = connections.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var name = line.Substring(0, line.IndexOf(' '));
                var children = line.Substring(line.IndexOf("<->") + 3).Split(new[] { ", " }, System.StringSplitOptions.RemoveEmptyEntries);

                if (!nodes.TryGetValue(name, out var newNode))
                {
                    newNode = new Node(name);
                    nodes.Add(name, newNode);
                }

                // Now add it's children
                foreach (var child in children)
                {
                    var childName = child.Trim();
                    if (!nodes.TryGetValue(childName, out var childNode))
                    {
                        childNode = new Node(childName);
                        nodes.Add(childName, childNode);
                    }

                    newNode.Children.Add(childNode);
                }
            }

            return nodes;
        }

        public int CountGroups(string connections)
        {
            var nodes = Build(connections);
            var groupNumber = 0;

            var root = nodes.Values.FirstOrDefault(n => n.GroupNumber == 0);
            while (root != null)
            {
                groupNumber++;
                Count(root, groupNumber);
                root = nodes.Values.FirstOrDefault(n => n.GroupNumber == 0);
            }

            return groupNumber;
        }

        private int Count(Node rootNode,int groupNumber)
        {
            var total = 1;
            rootNode.GroupNumber = groupNumber;

            foreach (var node in rootNode.Children.Where(n => n.GroupNumber==0))
            {
                total += Count(node, groupNumber);
            }

            return total;
        }

        private class Node
        {
            public string Name { get; }
            public List<Node> Children { get; set; }

            public int GroupNumber { get; set; }

            public Node(string name)
            {
                this.Name = name;
                this.Children = new List<Node>();
            }
        }
    }
}
