using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day22_Part1
    {
        private string Key(int x, int y) => $"{x},{y}";

        public enum Direction
        {
            North = 0,
            South = 1,
            East = 2,
            West = 3
        }

        public HashSet<string> LoadMap(string input)
        {
            var rows = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var result = new HashSet<string>();

            for (int y = 0; y < rows.Length; y++)
            {
                var row = rows[y];
                for (int x = 0; x < row.Length; x++)
                {
                    if (row[x] == '#')
                    {
                        result.Add(Key(x - (row.Length / 2), y - (rows.Length / 2)));
                    }
                }
            }
            return result;
        }

        public int Part1(HashSet<string> map, int numberOfBursts)
        {
            var direction = Direction.North;
            var x = 0;
            var y = 0;
            var result = 0;
            for (int burst = 0; burst < numberOfBursts; burst++)
            {
                var infected = false;
                (direction, x, y, infected) = Burst(map, direction, x, y);
                if (infected) result++;
            }
            return result;

        }

        public (Direction Direction, int X, int Y, bool infected) Burst(HashSet<string> map, Direction currentDirection, int currentX, int currentY)
        {
            var currentKey = Key(currentX, currentY);
            Direction newDirection;
            var infected = false;
            if (map.Contains(currentKey))
            {
                //Was infected
                newDirection = TurnRight(currentDirection);
                map.Remove(currentKey);
                infected = false;
            }
            else
            {
                //Was clean
                newDirection = TurnLeft(currentDirection);
                map.Add(currentKey);
                infected = true;
            }

            var (newX, newY) = MoveForward(currentX, currentY, newDirection);

            return (newDirection, newX, newY, infected);
        }

        private (int X, int Y) MoveForward(int X, int Y, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return (X, Y - 1);
                case Direction.South:
                    return (X, Y + 1);
                case Direction.East:
                    return (X + 1, Y);
                case Direction.West:
                    return (X - 1, Y);
                default:
                    throw new Exception("");
            }
        }

        private Direction TurnLeft(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return Direction.West;
                case Direction.South:
                    return Direction.East;
                case Direction.East:
                    return Direction.North;
                case Direction.West:
                    return Direction.South;
                default:
                    throw new Exception("");
            }
        }

        private Direction TurnRight(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return Direction.East;
                case Direction.South:
                    return Direction.West;
                case Direction.East:
                    return Direction.South;
                case Direction.West:
                    return Direction.North;
                default:
                    throw new Exception("");
            }
        }
    }
}
