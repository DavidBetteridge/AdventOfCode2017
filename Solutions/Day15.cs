using System.Linq;
using System.Collections.Generic;

namespace Solutions
{
    public class Day15
    {
        public long NextValue(long previous, long factor) => (previous * factor) % 2147483647;

        public IEnumerable<long> GeneratorA(long initial)
        {
            var nextValue = initial;
            while (true)
            {
                nextValue = NextValue(nextValue, 16807);
                yield return nextValue;
            }
        }

        public IEnumerable<long> GeneratorB(long initial)
        {
            var nextValue = initial;
            while (true)
            {
                nextValue = NextValue(nextValue, 48271);
                yield return nextValue;
            }
        }

        public bool Compare(long lhs, long rhs)
        {
            var mask = 0b1111_1111_1111_1111;
            return (lhs & mask) == (rhs & mask);
        }

        public int CountMatches(int initialStateA, int initialStateB)
        {
            var generatorA = GeneratorA(initialStateA);
            var generatorB = GeneratorB(initialStateB);
            return generatorA
                    .Zip(generatorB, (f, s) => Compare(f, s))
                    .Take(40000000)
                    .Count(a => a);
        }


        public int CountMatches2(int initialStateA, int initialStateB)
        {
            var generatorA = GeneratorA(initialStateA).Where(a => a % 4 == 0);
            var generatorB = GeneratorB(initialStateB).Where(a => a % 8 == 0);
            return generatorA
                    .Zip(generatorB, (f, s) => Compare(f, s))
                    .Take(5000000)
                    .Count(a => a);
        }
    }
}
