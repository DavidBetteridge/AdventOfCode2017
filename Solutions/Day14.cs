using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Solutions
{
    public class Day14
    {
        public string CalculateHash(string input)
        {
            // Convert the input to ascii codes
            var finalInput = new byte[input.Length + 5];
            for (int i = 0; i < input.Length; i++)
            {
                finalInput[i] = ((byte)input[i]);
            }
            Array.Copy(new byte[5] { 17, 31, 73, 47, 23 }, 0, finalInput, input.Length, 5);

            // Build a list with the elements 0... numberOfElements-1
            const int numberOfElements = 256;
            var list = BuildListOfNumbers(numberOfElements);

            // Apply the rounds
            var currentPosition = 0;
            var skipSize = 0;
            for (int round = 0; round < 64; round++)
            {
                (currentPosition, skipSize) = DoRound(finalInput, list, currentPosition, skipSize);
            }

            // Create the dense hash
            return CalculateDenseHash(numberOfElements, list);
        }

        public int CountRegions(string key)
        {
            var result = 0;
            var cells = new int[128, 128];
            for (int row = 0; row < 128; row++)
            {
                var hash = CalculateHash($"{key}-{row}");
                var binary = HashToBinary(hash);

                for (int column = 0; column < 128; column++)
                {
                    cells[column, row] = (binary[column] == '1' ? 0 : -1);
                }
            }

            for (int row = 0; row < 128; row++)
            {
                for (int column = 0; column < 128; column++)
                {
            //        Print(cells);
                    if (cells[column, row] == 0)
                    {
                        result++;
                        cells[column, row] = result;

                        //Look Right
                        if (column < 127)
                            ClearIfSet(cells, column + 1, row, result);

                        //Look Down
                        if (row < 127)
                            ClearIfSet(cells, column, row + 1, result);
                    }

                }
            }


            return result;
        }

        private void Print(int[,] cells)
        {
            for (int row = 0; row < 128; row++)
            {
                var r = "";
                for (int column = 0; column < 128; column++)
                {
                    if (cells[column, row] == -1)
                    {
                        r += ".";
                    }
                    else if (cells[column, row] == 0)
                    {
                        r += "#";
                    }
                    else
                    {
                        r += cells[column, row];
                    }
                }
                Debug.WriteLine(r);
            }
        }

        private void ClearIfSet(int[,] cells, int x, int y, int groupNumber)
        {
            if (cells[x, y] == 0)
            {
                cells[x, y] = groupNumber;
                if (x > 0) ClearIfSet(cells, x - 1, y, groupNumber);
                if (x < 127) ClearIfSet(cells, x + 1, y, groupNumber);
                if (y > 0) ClearIfSet(cells, x, y - 1, groupNumber);
                if (y < 127) ClearIfSet(cells, x, y + 1, groupNumber);
            }
        }

        public int CountUsedSquares(string key)
        {
            var result = 0;
            for (int row = 0; row < 128; row++)
            {
                var hash = CalculateHash($"{key}-{row}");
                var binary = HashToBinary(hash);
                result += binary.Replace("0", "").Length;
            }
            return result;
        }

        public string HashToBinary(string hexstring)
        {
            return String.Join(String.Empty,
  hexstring.Select(
    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
  )
);
        }

        private static List<int> BuildListOfNumbers(int numberOfElements)
        {
            // Build a list with the elements 0... numberOfElements-1
            var list = new List<int>(numberOfElements);
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private static string CalculateDenseHash(int numberOfElements, List<int> list)
        {
            var denseHash = "";
            for (int blockStart = 0; blockStart < numberOfElements; blockStart += 16)
            {
                var runningTotal = list[blockStart];
                for (int e = 1; e < 16; e++)
                {
                    runningTotal ^= list[blockStart + e];
                }
                denseHash += runningTotal.ToString("X2");
            }

            return denseHash.ToLower(); ;
        }

        private static (int currentPosition, int skipSize) DoRound(byte[] lengths, List<int> list, int currentPosition, int skipSize)
        {
            var numberOfElements = list.Count;
            foreach (var length in lengths)
            {
                var temp = new List<int>();
                for (int elementNumber = 0; elementNumber < length; elementNumber++)
                {
                    temp.Add(list[(currentPosition + elementNumber) % numberOfElements]);
                }
                for (int elementNumber = 0; elementNumber < length; elementNumber++)
                {
                    var rhs = ((currentPosition + length) - elementNumber - 1) % numberOfElements;
                    list[rhs] = temp[elementNumber];
                }

                currentPosition += (length + skipSize);
                currentPosition = currentPosition % numberOfElements;
                skipSize++;
            }

            return (currentPosition, skipSize);
        }
    }
}
