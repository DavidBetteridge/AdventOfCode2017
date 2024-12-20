using System;
using System.Collections.Generic;
using System.Linq;
namespace Solutions
{
    public class Day25
    {
        const int NUMBER_OF_STEPS = 12208951;
        const int A = 1;
        const int B = 2;
        const int C = 3;
        const int D = 4;
        const int E = 5;
        const int F = 6;
        const int RIGHT = +1;
        const int LEFT = -1;

        private Dictionary<(int state, bool set), (int newState, bool newSet, int movement)> rules;

        public int SolvePart1()
        {
            rules = new Dictionary<(int state, bool set), (int newState, bool newSet, int movement)>
            {
                [(A, false)] = (B, true, RIGHT),
                [(A, true)] = (E, false, LEFT),
                [(B, false)] = (C, true, LEFT),
                [(B, true)] = (A, false, RIGHT),
                [(C, false)] = (D, true, LEFT),
                [(C, true)] = (C, false, RIGHT),
                [(D, false)] = (E, true, LEFT),
                [(D, true)] = (F, false, LEFT),
                [(E, false)] = (A, true, LEFT),
                [(E, true)] = (C, true, LEFT),
                [(F, false)] = (E, true, LEFT),
                [(F, true)] = (A, true, RIGHT)
            };

            var seed = (position: NUMBER_OF_STEPS / 2,
                        state: A,
                        tape: new bool[NUMBER_OF_STEPS]);

            var (_, _, tape) = Enumerable.Range(1, NUMBER_OF_STEPS)
                                .Aggregate(seed, (state, _) => NextState(state.position, state.state, state.tape));

            return tape.Count(symbol => symbol);
        }

        private (int position, int state, bool[] tape) NextState(int position, int state, bool[] tape)
        {
            var rule = rules[(state, tape[position])];
            tape[position] = rule.newSet;
            return ((position + rule.movement) % NUMBER_OF_STEPS, rule.newState, tape);
        }
    }
}
