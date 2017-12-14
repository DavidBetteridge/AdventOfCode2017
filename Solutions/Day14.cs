using System;
using System.Diagnostics;
using System.Linq;

namespace Solutions
{
    public class Day14
    {
        public (int regions, int usedSquares) Count(string key)
        {
            var hasher = new KnotHash();

            var usedSquares = 0;
            var regions = 0;
            var cells = new int[128, 128];
            for (int row = 0; row < 128; row++)
            {
                var hash = hasher.CalculateHash($"{key}-{row}");
                var binary = HashToBinary(hash);

                for (int column = 0; column < 128; column++)
                {
                    cells[column, row] = (binary[column] == '1' ? 0 : -1);
                    if (binary[column] == '1') usedSquares++;
                }
            }

            for (int row = 0; row < 128; row++)
            {
                for (int column = 0; column < 128; column++)
                {
                    if (cells[column, row] == 0)
                    {
                        regions++;
                        cells[column, row] = regions;

                        //Look Right
                        if (column < 127)
                            ClearIfSet(cells, column + 1, row, regions);

                        //Look Down
                        if (row < 127)
                            ClearIfSet(cells, column, row + 1, regions);
                    }

                }
            }

            return (usedSquares, regions);
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

        public string HashToBinary(string hexstring)
          => String.Join(String.Empty, hexstring.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

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
    }
}
