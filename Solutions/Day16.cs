using System;

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

        public char[] Exchange(char[] programs, int A, int B)
        {
            var temp = programs[A];
            programs[A] = programs[B];
            programs[B] = temp;

            return programs;
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

        public char[] Dance(char[] programs, string moves)
        {
            var commands = moves.Split(',');
            foreach (var command in commands)
            {
                if (command.StartsWith("x"))
                {
                    var parms = command.Substring(1).Split('/');
                    programs = Exchange(programs, int.Parse(parms[0]), int.Parse(parms[1]));
                }
                else if (command.StartsWith("p"))
                {
                    var parms = command.Substring(1).Split('/');
                    programs = Partner(programs, parms[0][0], parms[1][0]);
                }
                else if (command.StartsWith("s"))
                {
                    programs = Spin(programs, int.Parse(command.Substring(1)));
                }
                else
                {
                    throw new Exception("Unknown command");
                }
            }

            return programs;
        }
    }
}
