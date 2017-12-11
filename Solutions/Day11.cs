using System;

namespace Solutions
{
    public class Day11
    {
        public int Walk(string route)
        {


            var steps = route.Split(',');

            var x = 0;
            var y = 0;
            var z = 0;

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
            }


            return (Math.Abs(x - 0) + Math.Abs(y - 0) + Math.Abs(z - 0)) / 2;

        }
    }
}
