using System.Linq;
using System.Collections.Generic;

namespace Solutions
{
    public class Day12
    {
        public int CountConnections(string connections)
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

                    childNode.Parent = newNode;
                    newNode.Children.Add(childNode);
                }
            }

            var rootNode = nodes["0"];
            return Count(rootNode);
        }

        private int Count(Node rootNode)
        {
            var total = 1;
            rootNode.Counted = true;

            foreach (var node in rootNode.Children.Where(n => !n.Counted))
            {
                total += Count(node);
            }

            return total;
        }

        private class Node
        {
            public string Name { get; }
            public Node Parent { get; set; }
            public List<Node> Children { get; set; }

            public bool Counted { get; set; }

            public Node(string name)
            {
                this.Name = name;
                this.Children = new List<Node>();
            }
        }
    }
}
