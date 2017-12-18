using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions
{
    public class Day18
    {
        public long Solve(string input)
        {
            var commands = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var registers = new Dictionary<char, long>();
            var lastSound = 0L;
            var programCounter = 0L;
            while (true)
            {
                var command = commands[programCounter];

                var parts = command.Split(' ');
                var lhs = 0L;
                var rhs = 0L;
                switch (parts[0])
                {
                    case "add":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs + rhs);
                        programCounter++;
                        break;

                    case "set":
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, rhs);
                        programCounter++;
                        break;

                    case "mul":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs * rhs);
                        programCounter++;
                        break;

                    case "mod":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs % rhs);
                        programCounter++;
                        break;

                    case "snd":
                        lastSound = ReadValue(registers, parts[1]);
                        programCounter++;
                        break;

                    case "rcv":
                        lhs = ReadValue(registers, parts[1]);
                        if (lhs > 0) return lastSound;
                        programCounter++;
                        break;

                    case "jgz":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        if (lhs > 0)
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
