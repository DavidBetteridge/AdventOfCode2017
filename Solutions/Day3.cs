using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions
{
    public class Day3
    {
        public int CalculateDistance(int square)
        {
            // Work out which layer on the square holds our value
            var max = 1;
            var height = 1;
            while (square > max)
            {
                height += 2;
                max = height * height;
            }

            // Work out which side of the square
            var midOffset = (height - 1) / 2;
            if (square > max - height)
            {
                // Bottom
                return midOffset + Math.Abs((max - midOffset) - square);
            }
            else if (square > max - (height * 2) + 1)
            {
                //Left
                return midOffset + Math.Abs((max - (height - 1) - midOffset) - square);
            }
            else if (square > max - (height * 3) + 2)
            {
                //Top
                return midOffset + Math.Abs((max - ((height - 1) * 2) - midOffset) - square);
            }
            else
            {
                //Right
                return midOffset + Math.Abs((max - ((height - 1) * 3) - midOffset) - square);
            }
        }
    }
}
