using System;
using System.Collections.Generic;

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

        public int FindFirstValueBiggerThan(int valueBiggerThan)
        {
            var grid = new Dictionary<string, int>();

            // Start with a 1 in the centre
            var x = 0;
            var y = 0;
            var length = 1;

            grid.Add($"{x},{y}", 1);

            while (true)
            {
                //Walk to the right
                length++;
                for (int i = 1; i < length; i++)
                {
                    x++;
                    var total = SumSquares(grid, x, y);
                    grid.Add($"{x},{y}", total);
                    if (total > valueBiggerThan) return total;
                }

                //Walk up
                for (int i = 1; i < length; i++)
                {
                    y--;
                    var total = SumSquares(grid, x, y);
                    grid.Add($"{x},{y}", total);
                    if (total > valueBiggerThan) return total;
                }

                //Walk to the left
                length += 1;
                for (int i = 1; i < length; i++)
                {
                    x--;
                    var total = SumSquares(grid, x, y);
                    grid.Add($"{x},{y}", total);
                    if (total > valueBiggerThan) return total;
                }

                //Walk down
                for (int i = 1; i < length; i++)
                {
                    y++;
                    var total = SumSquares(grid, x, y);
                    grid.Add($"{x},{y}", total);
                    if (total > valueBiggerThan) return total;
                }
            }

        }

        private int SumSquares(Dictionary<string, int> grid, int xPos, int yPos)
        {
            var result = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    var key = $"{xPos + x},{yPos + y}";
                    grid.TryGetValue(key, out var value);
                    result += value;
                }
            }
            return result;
        }
    }
}
