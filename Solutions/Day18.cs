using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions
{
    public class Day18
    {

        public long Solve2(string input)
        {
            var commands = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var registers0 = new Dictionary<char, long>();
            var registers1 = new Dictionary<char, long>();

            var programCounter0 = 0L;
            var programCounter1 = 0L;

            SetValue('p', registers0, 0);
            SetValue('p', registers1, 1);

            var queueFrom0 = new Queue<long>();
            var queueFrom1 = new Queue<long>();

            var workDone0 = true;
            var workDone1 = true;

            var numberSent1To0 = 0;

            while (workDone0 || workDone1)
            {
                var temp = 0;
                (programCounter0, workDone0, _) = RunUntilHalted(registers0, programCounter0, commands, queueFrom0, queueFrom1);
                (programCounter1, workDone1, temp) = RunUntilHalted(registers1, programCounter1, commands, queueFrom1, queueFrom0);
                numberSent1To0 += temp;
            }

            return numberSent1To0;

        }

        private (long pc, bool workdone, int numberSent) RunUntilHalted(Dictionary<char, long> registers,
                                    long programCounter,
                                    string[] commands,
                                    Queue<long> readFrom,
                                    Queue<long> sendTo)
        {
            var workDone = false;
            var numberSent = 0;
            while (true)
            {
                if (programCounter >= commands.Length)
                {
                    // No more commands
                    return (programCounter, workDone, numberSent);
                }

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
                        workDone = true;
                        break;

                    case "set":
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, rhs);
                        programCounter++;
                        workDone = true;

                        break;

                    case "mul":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs * rhs);
                        programCounter++;
                        workDone = true;
                        break;

                    case "mod":
                        lhs = ReadValue(registers, parts[1]);
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs % rhs);
                        programCounter++;
                        workDone = true;
                        break;

                    case "snd":
                        sendTo.Enqueue(ReadValue(registers, parts[1]));
                        programCounter++;
                        workDone = true;
                        numberSent++;
                        break;

                    case "rcv":
                        if (readFrom.Count > 0)
                        {
                            SetValue(parts[1][0], registers, readFrom.Dequeue());
                            programCounter++;
                            workDone = true;
                        }
                        else
                        {
                            // Nothing on the queue - we need to context switch
                            return (programCounter, workDone, numberSent);
                        }
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
                        workDone = true;
                        break;

                    default:
                        throw new Exception("Unknown command " + command);
                }
            }


        }


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
