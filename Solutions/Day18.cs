using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Solutions
{
    public class Day18
    {
        class State
        {
            public long NumberOfOperations;
            public long NumberSent;
        }

        public long Solve2(string input)
        {
            var commands = input.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var queueFrom0To1 = new BlockingCollection<long>(new ConcurrentQueue<long>());
            var queueFrom1To0 = new BlockingCollection<long>(new ConcurrentQueue<long>());

            var state0 = new State();
            var state1 = new State();

            var task0 = Task.Run(() => RunUntilHalted(0, commands, queueFrom0To1, queueFrom1To0, state0));
            var task1 = Task.Run(() => RunUntilHalted(1, commands, queueFrom1To0, queueFrom0To1, state1));

            var monitor = Task.Run(() => DetectDeadlock(state0, state1));

            Task.WaitAny(new[] { task0, task1, monitor });

            return state1.NumberSent;
        }

        private async Task DetectDeadlock(State state0, State state1)
        {
            var s0 = Interlocked.Read(ref state0.NumberOfOperations);
            var s1 = Interlocked.Read(ref state1.NumberOfOperations);
            while (true)
            {
                var temp_s0 = Interlocked.Read(ref state0.NumberOfOperations);
                var temp_s1 = Interlocked.Read(ref state1.NumberOfOperations);

                if (temp_s0 == s0 && temp_s1 == s1)
                {
                    return;
                }

                s0 = temp_s0;
                s1 = temp_s1;

                await Task.Delay(10);
            }
        }

        private Task RunUntilHalted(long p,
                                          string[] commands,
                                          BlockingCollection<long> readFrom,
                                          BlockingCollection<long> sendTo,
                                          State state)
        {
            var registers = new Dictionary<char, long>();
            SetValue('p', registers, p);
            var programCounter = 0L;


            while (true)
            {
                if (programCounter >= commands.Length)
                {
                    // No more commands
                    return Task.FromResult(0);
                }

                var command = commands[programCounter];

                var parts = command.Split(' ');
                var lhs = ReadValue(registers, parts[1]);
                var rhs = 0L;

                Interlocked.Increment(ref state.NumberOfOperations);

                switch (parts[0])
                {
                    case "add":
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
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs * rhs);
                        programCounter++;
                        break;

                    case "mod":
                        rhs = ReadValue(registers, parts[2]);
                        SetValue(parts[1][0], registers, lhs % rhs);
                        programCounter++;
                        break;

                    case "snd":
                        sendTo.TryAdd(ReadValue(registers, parts[1]));
                        programCounter++;
                        Interlocked.Increment(ref state.NumberSent);
                        break;

                    case "rcv":
                        readFrom.TryTake(out var l, Timeout.Infinite);
                        SetValue(parts[1][0], registers, l);
                        programCounter++;
                        break;

                    case "jgz":
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
