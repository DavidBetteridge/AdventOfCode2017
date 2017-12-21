using System;
using System.Collections.Generic;
using System.Linq;


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
            var h1 = HFlip(patternArray);
            var h2 = HFlip(r1);
            var h3 = HFlip(r2);
            var h4 = HFlip(r3);

            return new List<string>() { pattern, ArrayToString(r1), ArrayToString(r2), ArrayToString(r3), ArrayToString(h1), ArrayToString(h2), ArrayToString(h3), ArrayToString(h4) };

        }

        public int Part1(string input, string patterns)
        {
            var allPatterns = ExpandPatterns(patterns);

            for (int iteration = 0; iteration < 5; iteration++)
            {
                var (inputs, size) = SplitUpInput(input);
                var updated = inputs.Select(a => allPatterns[a]);
                input = RejoinInput(updated, size);
            }


            return input.Replace("/", "").Replace(".", "").Count();

        }

        private string RejoinInput(IEnumerable<string> updated, int size)
        {
            var numberOfBlocks = updated.Count();
            var numberPerSide = (int)Math.Sqrt(numberOfBlocks);
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
                        final[column + (blockX * size), row + (blockY * size)] = asArray[column, row];
                    }
                }

                blockX++;
                if (blockX + 1 > numberPerSide)
                {
                    blockX = 0;
                    blockY++;
                }
            }

            return ArrayToString(final);
        }

        private (List<string>, int size) SplitUpInput(string input)
        {
            var full = StringToArray(input);

            if (full.GetUpperBound(0) + 1 % 2 == 0)
            {
                return SplitUp(full, 2);
            }
            else
            {
                return SplitUp(full, 3);
            }

        }

        private (List<string>, int size) SplitUp(bool[,] full, int size)
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

            return (result, size);
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
            var s = "";
            for (int row = 0; row <= pattern.GetUpperBound(0); row++)
            {
                if (s != "") s += "/";
                for (int column = 0; column <= pattern.GetUpperBound(1); column++)
                {
                    s += pattern[column, row] ? "#" : ".";
                }
            }
            return s;
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
