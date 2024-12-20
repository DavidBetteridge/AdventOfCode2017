using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day3
    {
        public int CalculateDistance(int square)
        {
            // Work out which layer on the square holds our value
            var height = (int)(Math.Ceiling(Math.Sqrt(square)));
            if (height % 2 == 0) height++;
            var max = height * height;

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
            grid.Add($"{x},{y}", 1);

            foreach (var moveInDirection in Directions())
            {
                (x, y) = Walk(x, y, moveInDirection);
                var total = SumSquares(grid, x, y);
                grid.Add($"{x},{y}", total);
                if (total > valueBiggerThan) return total;
            }

            return 0;

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


        private (int newX, int newY) Walk(int currentX, int currentY, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return (currentX, currentY - 1);
                case Direction.Down:
                    return (currentX, currentY + 1);
                case Direction.East:
                    return (currentX + 1, currentY);
                case Direction.West:
                    return (currentX - 1, currentY);
                default:
                    throw new Exception("Unknown direction");
            }
        }

        private IEnumerable<Direction> Directions()
        {
            var length = 0;

            while (true)
            {
                length++;
                for (int i = 0; i < length; i++)
                {
                    yield return Direction.East;
                }

                for (int i = 0; i < length; i++)
                {
                    yield return Direction.Up;
                }

                length++;
                for (int i = 0; i < length; i++)
                {
                    yield return Direction.West;
                }

                for (int i = 0; i < length; i++)
                {
                    yield return Direction.Down;
                }
            }
        }
    }

    enum Direction
    {
        Up = 1,
        Down = 2,
        East = 3,
        West = 4
    }
}
