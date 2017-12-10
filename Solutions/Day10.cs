using System.Collections.Generic;

namespace Solutions
{
    public class Day10
    {
        public object Solve(int numberOfElements, string lengths)
        {
            // Build a list with the elements 0... numberOfElemet-1
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
    }
}
