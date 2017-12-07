using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day7
    {
        public string FindBase(string given)
        {
            var nodes = new Dictionary<string, Node>();
            var lines = given.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var name = line.Substring(0, line.IndexOf(' '));
                var newNode = new Node() { Name = name , Children=new List<Node>()};
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


            return node.Name;
        }


        private class Node
        {
            public string Name { get; set; }
            public int Weight { get; set; }

            public Node Parent { get; set; }
            public List<Node> Children { get; set; }
        }
    }
}
