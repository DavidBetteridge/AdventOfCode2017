using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day17
    {
        public (List<int> newState, int newPosition) Spin(List<int> initialState, int initialPosition, int numberOfSteps, int nextValue)
        {
            var location = (initialPosition + numberOfSteps) % initialState.Count;
            initialState.Insert(location + 1, nextValue);
            return (initialState, location + 1);
        }

        public int Part1(int numberOfSteps)
        {
            var state = new List<int>() { 0 };
            var position = 0;

            for (int nextValue = 1; nextValue <= 2017; nextValue++)
            {
                (state, position) = Spin(state, position, numberOfSteps, nextValue);
            }

            return state[(position + 1) % state.Count];
        }
    }
}
