using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { "###/###/###", "###/###/###", "###/###/###",
                                "###/###/###"};

            Console.WriteLine(ArrayToString(RejoinInput(input)));
            Console.ReadKey();
        }


        public static string ArrayToString(bool[,] pattern)
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
        private static bool[,] RejoinInput(IEnumerable<string> updated)
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

            Debug.Assert(blockX == 0);
            Debug.Assert(blockY == numberPerSide);

            return final;
        }

        public static bool[,] StringToArray(string pattern)
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
