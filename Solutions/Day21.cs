using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Solutions
{
    public class Day21
    {
        public bool[,] VFlip(bool[,] patternArray)
        {

            var size = patternArray.GetUpperBound(0) + 1;
            var newPattern = new bool[size, size];

            for (int row = 0; row < size; row++)
            {
                var readFrom = size - 1;
                for (int column = 0; column < size; column++)
                {
                    newPattern[column, row] = patternArray[readFrom, row];
                    readFrom--;
                }
            }

            return newPattern;
        }

        public bool[,] HFlip(bool[,] patternArray)
        {
            var size = patternArray.GetUpperBound(0) + 1;
            var newPattern = new bool[size, size];

            var readFrom = size - 1;
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    newPattern[column, row] = patternArray[column, readFrom];
                }
                readFrom--;
            }

            return newPattern;
        }

        public List<string> ExpandPattern(string pattern)
        {
            var patternArray = StringToArray(pattern);

            var r1 = RotateClockwise(patternArray);
            var r2 = RotateClockwise(r1);
            var r3 = RotateClockwise(r2);
            var h1 = VFlip(patternArray);
            var h2 = RotateClockwise(h1);
            var h3 = RotateClockwise(h2);
            var h4 = RotateClockwise(h3);
            return new List<string>() { pattern, ArrayToString(r1), ArrayToString(r2), ArrayToString(r3), ArrayToString(h1), ArrayToString(h2), ArrayToString(h3), ArrayToString(h4) };

        }

        public long Part1(string input, string patterns, int iterations)
        {
            var allPatterns = ExpandPatterns(patterns);

            var asArray = StringToArray(input);
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                var inputs = SplitUpInput(asArray);
                var updated = inputs.Select(a =>
                {
                    if (allPatterns.TryGetValue(a, out var p))
                        return p;
                    else
                        throw new Exception("Unknown pattern " + a);
                });
                asArray = RejoinInput(updated);

                display(ArrayToString(asArray));
            }

            var result = 0L;
            for (int column = 0; column <= asArray.GetUpperBound(0); column++)
            {
                for (int row = 0; row <= asArray.GetUpperBound(0); row++)
                {
                    if (asArray[column, row]) result++;
                }
            }

            return result;

        }

        private void display(string input)
        {
            Debug.WriteLine("");
            Debug.WriteLine(input.Replace("/", System.Environment.NewLine));
        }

        private bool[,] RejoinInput(IEnumerable<string> updated)
        {
            var numberOfBlocks = updated.Count();
            var numberPerSide = (int)Math.Sqrt(numberOfBlocks);
            var size = updated.First().IndexOf('/');
            var final = new bool[numberPerSide * size, numberPerSide * size];

            var blockX = 0;
            var blockY = 0;
            foreach (var input in updated)
            {
                var asArray = StringToArray(input);

                for (int column = 0; column < size; column++)
                {
                    for (int row = 0; row < size; row++)
                    {
                        final[column + (blockY * size), row + (blockX * size)] = asArray[column, row];
                    }
                }

                blockX++;
                if (blockX + 1 > numberPerSide)
                {
                    blockX = 0;
                    blockY++;
                }
            }

            Debug.Assert(blockX == 0);
            Debug.Assert(blockY == numberPerSide);

            return final;
        }

        private List<string> SplitUpInput(bool[,] input)
        {
            if ((input.GetUpperBound(0) + 1) % 2 == 0)
            {
                return SplitUp(input, 2);
            }
            else if ((input.GetUpperBound(0) + 1) % 3 == 0)
            {
                return SplitUp(input, 3);
            }
            else
            {
                throw new Exception("Unknown grid size - " + (input.GetUpperBound(0) + 1));
            }
        }

        private List<string> SplitUp(bool[,] full, int size)
        {
            var result = new List<string>();
            var numberToGenerate = (full.GetUpperBound(0) + 1) / size;

            for (int blockX = 0; blockX < numberToGenerate; blockX++)
            {
                for (int blockY = 0; blockY < numberToGenerate; blockY++)
                {
                    var block = new bool[size, size];
                    for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            block[x, y] = full[x + (blockX * size), y + (blockY * size)];
                        }
                    }
                    result.Add(ArrayToString(block));
                }
            }

            return result;
        }

        public Dictionary<string, string> ExpandPatterns(string input)
        {
            var result = new Dictionary<string, string>();

            var patterns = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pattern in patterns)
            {
                var bits = pattern.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                var additionalPatterns = ExpandPattern(bits[0]);
                foreach (var additional in additionalPatterns)
                {
                    if (!result.ContainsKey(additional))
                        result.Add(additional, bits[1]);
                }
            }
            return result;
        }

        public bool[,] RotateClockwise(bool[,] patternArray)
        {
            var size = patternArray.GetUpperBound(0) + 1;
            var newPattern = new bool[size, size];

            for (int row = 0; row < size; row++)
            {
                var readFrom = size - 1;
                for (int column = 0; column < size; column++)
                {
                    newPattern[column, row] = patternArray[row, readFrom];
                    readFrom--;
                }
            }

            return newPattern;
        }

        public string ArrayToString(bool[,] pattern)
        {
            var s = new StringBuilder();
            for (int row = 0; row <= pattern.GetUpperBound(0); row++)
            {
                if (row > 0) s.Append("/");
                for (int column = 0; column <= pattern.GetUpperBound(1); column++)
                {
                    s.Append(pattern[column, row] ? "#" : ".");
                }
            }
            return s.ToString();
        }

        public bool[,] StringToArray(string pattern)
        {
            var lines = pattern.Split('/');
            var result = new bool[lines.Length, lines.Length];

            for (int row = 0; row < lines.Length; row++)
            {
                for (int column = 0; column < lines.Length; column++)
                {
                    result[column, row] = lines[row][column] == '#';
                }
            }

            return result;
        }
    }
}
