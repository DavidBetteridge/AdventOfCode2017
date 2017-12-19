using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions
{
    public class Day19
    {
        public (int steps, string word) Walk(string diagram)
        {
            var lines = diagram.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //Find start
            var currentY = 0;
            var currentX = lines[0].IndexOf('|');

            var word = "";
            var steps = 1;
            var direction = Direction.South;

            while (true)
            {
                switch (direction)
                {
                    case Direction.North:
                        currentY--;
                        break;
                    case Direction.South:
                        currentY++;
                        break;
                    case Direction.West:
                        currentX--;
                        break;
                    case Direction.East:
                        currentX++;
                        break;
                    default:
                        break;
                }

                if (currentX < 0 || currentX == lines[0].Length) break;
                if (currentY < 0 || currentY == lines.Length) break;


                var newChar = lines[currentY][currentX];
                switch (newChar)
                {
                    case '|':
                    case '-':
                        //Keep going
                        steps++;
                        break;
                    case '+':
                        //Change direction
                        if (direction == Direction.West || direction == Direction.East)
                        {
                            //Switch from w/e to n/s
                            if (currentY > 0 && lines[currentY-1][currentX] != ' ')
                                direction = Direction.North;
                            else
                                direction = Direction.South;
                        }
                        else
                        {
                            //Switch from n/s to e/w
                            if (currentX > 0 && lines[currentY][currentX - 1] != ' ')
                                direction = Direction.West;
                            else
                                direction = Direction.East;
                        }
                        steps++;
                        break;
                    case ' ':
                        break;
                    default:
                        steps++;
                        word += newChar;
                        break;
                }

                if (newChar == ' ') break;

            }


            return (steps,word);
        }

        enum Direction
        {
            North = 0,
            South = 1,
            West = 2,
            East = 3
        }

    }
}
