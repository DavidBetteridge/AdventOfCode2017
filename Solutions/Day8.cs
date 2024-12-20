using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day8
{
    public class Day8
    {
        public Instruction Parse(string instruction)
        {
            var result = new Instruction();
            var parts = instruction.Split(' ');
            result.Register = parts[0];
            result.Operation = parts[1] == "inc" ? Operation.Inc : Operation.Dec;
            result.Offset = int.Parse(parts[2]);
            result.ConditionRegister = parts[4];

            switch (parts[5])
            {
                case ">":
                    result.ConditionType = Condition.GT;
                    break;
                case ">=":
                    result.ConditionType = Condition.GTE;
                    break;
                case "==":
                    result.ConditionType = Condition.EQ;
                    break;
                case "<":
                    result.ConditionType = Condition.LT;
                    break;
                case "<=":
                    result.ConditionType = Condition.LTE;
                    break;
                case "!=":
                    result.ConditionType = Condition.NEQ;
                    break;
                default:
                    throw new Exception("Unknown condition " + parts[5]);
            }

            result.ConditionValue = int.Parse(parts[6]);

            return result;
        }

        public int FindLargest(string instructions)
        {
            var lines = instructions.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            var registers = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                var instruction = Parse(line);
                if (EvaluateCondition(instruction,registers))
                {
                    UpdateRegister(instruction, registers);
                }
            }

            return registers.Values.Max();
        }

        public int FindHighest(string instructions)
        {
            var lines = instructions.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            var registers = new Dictionary<string, int>();
            var highest = 0;

            foreach (var line in lines)
            {
                var instruction = Parse(line);
                if (EvaluateCondition(instruction, registers))
                {
                    highest = Math.Max(highest, UpdateRegister(instruction, registers));
                }
            }

            return highest;
        }


        public bool EvaluateCondition(Instruction instruction, Dictionary<string, int> registers)
        {
            registers.TryGetValue(instruction.ConditionRegister, out var LHS);

            switch (instruction.ConditionType)
            {
                case Condition.GT:
                    return LHS > instruction.ConditionValue;
                case Condition.LT:
                    return LHS < instruction.ConditionValue;
                case Condition.EQ:
                    return LHS == instruction.ConditionValue;
                case Condition.NEQ:
                    return LHS != instruction.ConditionValue;
                case Condition.GTE:
                    return LHS >= instruction.ConditionValue;
                case Condition.LTE:
                    return LHS <= instruction.ConditionValue;
                default:
                    throw new Exception("Unknown condition type - " + instruction.ConditionType);
            }
        }

        public int UpdateRegister(Instruction instruction, Dictionary<string, int> registers)
        {
            var exists = registers.TryGetValue(instruction.Register, out var LHS);
            var sign = instruction.Operation == Operation.Inc ? 1 : -1;
            var newValue = LHS + (sign * instruction.Offset);
            registers[instruction.Register] = newValue;
            return newValue;
        }


    }

    public class Instruction
    {
        public string Register { get; set; }
        public Operation Operation { get; set; }
        public int Offset { get; set; }
        public string ConditionRegister { get; set; }
        public Condition ConditionType { get; set; }
        public int ConditionValue { get; set; }
    }

    public enum Operation
    {
        Inc = 1,
        Dec = 2
    }

    public enum Condition
    {
        GT = 1,
        LT = 2,
        EQ = 3,
        NEQ = 4,
        GTE = 5,
        LTE = 6
    }

}
