using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day16
    {
        public char[] Spin(char[] programs, int X)
        {
            var result = new char[programs.Length];

            for (int i = 0; i < programs.Length; i++)
            {
                result[(i + X) % programs.Length] = programs[i];
            }

            return result;
        }

        public char[] Copy(char[] programs)
        {
            var result = new char[programs.Length];

            for (int i = 0; i < programs.Length; i++)
            {
                result[i] = programs[i];
            }

            return result;
        }


        public char[] Partner(char[] programs, char A, char B)
        {
            for (int i = 0; i < programs.Length; i++)
            {
                if (programs[i] == A)
                    programs[i] = B;
                else if (programs[i] == B)
                    programs[i] = A;
            }

            return programs;
        }

        private List<Func<char[], char[]>> BuildMoves(char[] programs, string moves)
        {
            var results = new List<Func<char[], char[]>>();
            var commands = moves.Split(',');
            foreach (var command in commands)
            {
                if (command.StartsWith("x"))
                {
                    var parms = command.Substring(1).Split('/');
                    results.Add((a => Exchange(a, int.Parse(parms[0]), int.Parse(parms[1]))));
                }
                else if (command.StartsWith("p"))
                {
                    var parms = command.Substring(1).Split('/');
                    results.Add((a => Partner(a, parms[0][0], parms[1][0])));
                }
                else if (command.StartsWith("s"))
                {
                    results.Add((a => Spin(a, int.Parse(command.Substring(1)))));
                }
                else
                {
                    throw new Exception("Unknown command");
                }
            }

            return results;
        }



        public char[] Exchange(char[] programs, int A, int B)
        {
            var temp = programs[A];
            programs[A] = programs[B];
            programs[B] = temp;

            return programs;
        }

        public char[] Dance(char[] programs, string moves, int rounds)
        {
            var commands = BuildMoves(programs, moves);
            var repeatsAfter = 0;
            var original = Copy(programs);
            for (int i = 0; i < rounds; i++)
            {
                foreach (var command in commands)
                {
                    programs = command(programs);
                }

                if (string.Join("", programs) == "abcdefghijklmnop")
                {
                    repeatsAfter = i;
                    break;
                }
            }

            if (repeatsAfter > 0)
            {
                programs = original;
                var complete = Math.Floor((double)rounds / (repeatsAfter + 1));
                var leftOver = rounds - (complete * (repeatsAfter + 1));

                for (int i = 0; i < leftOver; i++)
                {
                    foreach (var command in commands)
                    {
                        programs = command(programs);
                    }
                }
            }

            return programs;
        }
    }
}
