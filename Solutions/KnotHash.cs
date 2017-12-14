using System;
using System.Collections.Generic;

namespace Solutions
{
    public class KnotHash
    {
        public List<int> BuildListOfNumbers(int numberOfElements)
        {
            // Build a list with the elements 0... numberOfElements-1
            var list = new List<int>(numberOfElements);
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(i);
            }

            return list;
        }

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
                (currentPosition, skipSize) = DoSingleRound(finalInput, list, currentPosition, skipSize);
            }

            // Create the dense hash
            return CalculateDenseHash(numberOfElements, list);
        }

        private string CalculateDenseHash(int numberOfElements, List<int> list)
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

        public (int currentPosition, int skipSize) DoSingleRound(byte[] lengths, List<int> list, int currentPosition, int skipSize)
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
