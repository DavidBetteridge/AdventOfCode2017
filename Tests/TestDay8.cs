using Solutions;
using Solutions.Day8;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestDay8
    {

        [Fact]
        public void Part1()
        {
            var day8 = new Day8();
            var actual = day8.FindLargest(@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10");
            Assert.Equal(1, actual);
        }

        [Fact]
        public void Part1_CheckParser()
        {
            var day8 = new Day8();
            var actual = day8.Parse("b inc 5 if a > 1");

            Assert.Equal("b", actual.Register);
            Assert.Equal(Operation.Inc, actual.Operation);
            Assert.Equal(5, actual.Offset);
            Assert.Equal("a", actual.ConditionRegister);
            Assert.Equal(Condition.GT, actual.ConditionType);
            Assert.Equal(1, actual.ConditionValue);
        }

        [Fact]
        public void Part1_TestFalsePredicate()
        {
            var day8 = new Day8();

            var instruction = new Instruction();
            instruction.ConditionRegister = "a";
            instruction.ConditionType = Condition.EQ;
            instruction.ConditionValue = 10;

            var registers = new Dictionary<string, int>();

            var actual = day8.EvaluateCondition(instruction, registers);

            Assert.False(actual);
        }

        [Fact]
        public void Part1_TestTruePredicate()
        {
            var day8 = new Day8();

            var instruction = new Instruction();
            instruction.ConditionRegister = "b";
            instruction.ConditionType = Condition.GTE;
            instruction.ConditionValue = 100;

            var registers = new Dictionary<string, int>();
            registers.Add("b", 101);

            var actual = day8.EvaluateCondition(instruction, registers);

            Assert.True(actual);
        }

        [Fact]
        public void Part1_UpdateExistingRegister()
        {
            var day8 = new Day8();

            var instruction = new Instruction();
            instruction.Register = "b";
            instruction.Operation = Operation.Dec;
            instruction.Offset = 12;

            var registers = new Dictionary<string, int>();
            registers.Add("b", 100);

            day8.UpdateRegister(instruction, registers);

            Assert.Equal(88, registers["b"]);
        }


        [Fact]
        public void Part1_SetNewRegister()
        {
            var day8 = new Day8();

            var instruction = new Instruction();
            instruction.Register = "a";
            instruction.Operation = Operation.Inc;
            instruction.Offset = -100;

            var registers = new Dictionary<string, int>();

            day8.UpdateRegister(instruction, registers);

            Assert.Equal(-100, registers["a"]);
        }

        [Fact]
        public void Part1_Answer()
        {
            var day8 = new Day8();
            var actual = day8.FindLargest(TEST_INPUT);
            Assert.Equal(6611, actual);
        }



        [Fact]
        public void Part2()
        {
            var day8 = new Day8();
            var actual = day8.FindHighest(@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10");
            Assert.Equal(10, actual);
        }

        [Fact]
        public void Part2_Answer()
        {
            var day8 = new Day8();
            var actual = day8.FindHighest(TEST_INPUT);
            Assert.Equal(6619, actual);
        }

    }
}
