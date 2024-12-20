using System;

namespace Solutions
{
    public class Day11
    {

        public (int distance, int max) Walk(string route)
        {
            int Distance(int x1, int y1, int z1) =>
                (Math.Abs(x1 - 0) + Math.Abs(y1 - 0) + Math.Abs(z1 - 0)) / 2;

            var steps = route.Split(',');

            var x = 0;
            var y = 0;
            var z = 0;
            var max = 0;
            var distanceNow = 0;

            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        y++;
                        z--;
                        break;

                    case "nw":
                        y++;
                        x--;
                        break;

                    case "ne":
                        x++;
                        z--;
                        break;

                    case "s":
                        y--;
                        z++;
                        break;

                    case "sw":
                        x--;
                        z++;
                        break;

                    case "se":
                        y--;
                        x++;
                        break;

                    default:
                        throw new System.Exception("Unknown step type " + step);
                }

                distanceNow = Distance(x, y, z);
                max = Math.Max(max, distanceNow);
            }

            return (distanceNow, max);
        }
    }
}
