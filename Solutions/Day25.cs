using System.Linq;
namespace Solutions
{
    public class Day25
    {
        public int SolvePart1()
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

            var tape = new bool[NUMBER_OF_STEPS];
            var position = NUMBER_OF_STEPS / 2;
            var state = A;

            for (int step = 0; step < NUMBER_OF_STEPS; step++)
            {
                switch (state)
                {
                    case A:
                        if (!tape[position])
                        {
                            tape[position] = true;
                            position = (position + RIGHT) % NUMBER_OF_STEPS;
                            state = B;
                        }
                        else
                        {
                            tape[position] = false;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = E;
                        }
                        break;

                    case B:
                        if (!tape[position])
                        {
                            tape[position] = true;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = C;
                        }
                        else
                        {
                            tape[position] = false;
                            position = (position + RIGHT) % NUMBER_OF_STEPS;
                            state = A;
                        }
                        break;

                    case C:
                        if (!tape[position])
                        {
                            tape[position] = true;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = D;
                        }
                        else
                        {
                            tape[position] = false;
                            position = (position + RIGHT) % NUMBER_OF_STEPS;
                            // state = C;
                        }
                        break;

                    case D:
                        if (!tape[position])
                        {
                            tape[position] = true;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = E;
                        }
                        else
                        {
                            tape[position] = false;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = F;
                        }
                        break;

                    case E:
                        if (!tape[position])
                        {
                            tape[position] = true;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = A;
                        }
                        else
                        {
                            tape[position] = true;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = C;
                        }
                        break;

                    case F:
                        if (!tape[position])
                        {
                            tape[position] = true;
                            position = (position + LEFT) % NUMBER_OF_STEPS;
                            state = E;
                        }
                        else
                        {
                            tape[position] = true;
                            position = (position + RIGHT) % NUMBER_OF_STEPS;
                            state = A;
                        }
                        break;

                    default:
                        break;
                }
            }

            return tape.Count(symbol => symbol);
        }
    }
}
