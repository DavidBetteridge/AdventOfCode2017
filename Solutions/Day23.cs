using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day23
    {
        public int SolvePart1(string input)
        {
            var commands = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var registers = new Dictionary<char, long>();
            var result = 0;
            var programCounter = 0L;
            while (true)
            {
                if (programCounter == commands.Length) return result;

                var command = commands[programCounter];

                var parts = command.Split(' ');
                var lhs = 0L;
                var rhs = 0L;
                switch (parts[0])
                {
                    case "set":
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, rhs);
                        programCounter++;
                        break;

                    case "sub":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs - rhs);
                        programCounter++;
                        break;

                    case "mul":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs * rhs);
                        programCounter++;
                        result++;
                        break;

                    case "jnz":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        if (lhs != 0)
                        {
                            programCounter += rhs;
                        }
                        else
                        {
                            programCounter++;
                        }
                        break;

                    default:
                        throw new Exception("Unknown command " + command);
                }
            }
        }

        private void SetValue(char register, Dictionary<char, long> registers, long newValue)
        {
            registers[register] = newValue;
        }

        private long ReadValue(Dictionary<char, long> registers, string parm)
        {
            if (int.TryParse(parm, out var t))
            {
                return t;
            }

            var i = 0L;
            registers.TryGetValue(parm[0], out i);
            return i;
        }
    }
}
