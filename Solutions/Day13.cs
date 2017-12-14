using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day13
    {
        public int Calculate(string input)
        {
            var all = Build(input);

            return all
                    .Where(location => ((location.Position) % (2 * (location.TotalDepth - 1))) == 0)
                    .Sum(l => l.Position * l.TotalDepth);
        }

        private static List<Location> Build(string input)
        {
            var depths = input.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            var all = new List<Location>();
            foreach (var dep in depths)
            {
                var parts = dep.Split(':');
                var location = int.Parse(parts[0]);
                var depth = int.Parse(parts[1].Trim());
                all.Add(new Location() { Position = location, TotalDepth = depth });
            }

            return all;
        }

        public int Escape(string input, int finalLocation)
        {
            var all = Build(input);

            var delay = -1;
            while (true)
            {
                delay++;
                if (!all.Exists((location => ((location.Position+delay) % (2 * (location.TotalDepth - 1))) == 0)))
                {
                    return delay;
                }
            }

        }

        class Location
        {
            public int TotalDepth { get; set; }
            public int Position { get; set; }
        }
    }
}
