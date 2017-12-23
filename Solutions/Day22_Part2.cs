using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day22_Part2
    {

        public enum Direction
        {
            North = 0,
            South = 1,
            East = 2,
            West = 3
        }

        public enum State
        {
            Clean = 0,
            Weakened = 1,
            Infected = 2,
            Flagged = 3
        }

        public Dictionary<(int, int), State> LoadMap(string input)
        {
            var rows = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var result = new Dictionary<(int, int), State>(5000);

            for (int y = 0; y < rows.Length; y++)
            {
                var row = rows[y];
                for (int x = 0; x < row.Length; x++)
                {
                    if (row[x] == '#')
                    {
                        result.Add((x - (row.Length / 2), y - (rows.Length / 2)), State.Infected);
                    }
                    else
                    {
                        result.Add((x - (row.Length / 2), y - (rows.Length / 2)), State.Clean);
                    }
                }
            }
            return (result);
        }

        public int Part2(Dictionary<(int, int), State> map, int numberOfBursts)
        {
            var direction = Direction.North;
            var x = 0;
            var y = 0;
            var result = 0;
            for (int burst = 0; burst < numberOfBursts; burst++)
            {
                var currentState = State.Clean;
                map.TryGetValue((x, y), out currentState);


                switch (currentState)
                {
                    case State.Clean:
                        direction = TurnLeft(direction);
                        map[(x, y)] = State.Weakened;
                        break;
                    case State.Weakened:
                        map[(x, y)] = State.Infected;
                        result++;
                        break;
                    case State.Infected:
                        direction = TurnRight(direction);
                        map[(x, y)] = State.Flagged;
                        break;
                    case State.Flagged:
                        direction = TurnAround(direction);
                        map[(x, y)] = State.Clean;
                        break;
                    default:
                        throw new Exception("");
                }

                switch (direction)
                {
                    case Direction.North:
                        y--;
                        break;
                    case Direction.South:
                        y++;
                        break;
                    case Direction.East:
                        x++;
                        break;
                    case Direction.West:
                        x--;
                        break;
                    default:
                        throw new Exception("");
                }

            }
            return result;

        }

        private Direction TurnAround(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return Direction.South;
                case Direction.South:
                    return Direction.North;
                case Direction.East:
                    return Direction.West;
                case Direction.West:
                    return Direction.East;
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
