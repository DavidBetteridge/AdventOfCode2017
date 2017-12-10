using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day10
    {
        public object Solve(int numberOfElements, string lengths)
        {
            // Build a list with the elements 0... numberOfElements-1
            var list = new List<int>(numberOfElements);
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(i);
            }

            // Process each length in turn
            var currentPosition = 0;
            var skipSize = 0;
            foreach (var l in lengths.Split(','))
            {
                var length = int.Parse(l);

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

            return list[0] * list[1];
        }

        public string CalculateHash(string input)
        {
            // Convert the input to ascii codes
            var finalInput = new byte[input.Length + 5];
            for (int i = 0; i < input.Length; i++)
            {
                finalInput[i] = ((byte)input[i]);
            }
            finalInput[input.Length] = 17;
            finalInput[input.Length + 1] = 31;
            finalInput[input.Length + 2] = 73;
            finalInput[input.Length + 3] = 47;
            finalInput[input.Length + 4] = 23;


            // Build a list with the elements 0... numberOfElements-1
            const int numberOfElements = 256;
            var list = new List<int>(numberOfElements);
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(i);
            }

            // Apply the rounds
            var currentPosition = 0;
            var skipSize = 0;
            for (int round = 0; round < 64; round++)
            {
                foreach (var length in finalInput)
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
            }

            // Create the dense hash
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

            return denseHash.ToLower();
        }
    }
}
