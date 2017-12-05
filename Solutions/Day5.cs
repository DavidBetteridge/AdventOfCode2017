using System;
using System.Linq;

namespace Solutions
{
    public class Day5
    {
        public int ExecuteToEnd(string instructions, int currentPC, Func<int, int> incrementor)
        {
            var memory = instructions
                            .Split(new[] { " ", Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries)
                            .Select(a => int.Parse(a))
                            .ToArray();

            var result = 0;
            while (currentPC != -1)
            {
                var newPC = currentPC + memory[currentPC];

                if (newPC >= memory.Length)
                {
                    // We have exited
                    currentPC = -1;
                }
                else
                {
                    memory[currentPC] = incrementor(memory[currentPC]);
                    currentPC = newPC;
                }

                result++;
            }
            return result;
        }
    }
}
