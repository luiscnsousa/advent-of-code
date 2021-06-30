namespace AdventOfCode2015.Days
{
    using System;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day06 : IExercise
    {
        const int Rows = 1000, Columns = 1000;

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string[] input)
        {
            var decoration = new bool[Rows, Columns];
            foreach (var instruction in input)
            {
                var decodedInstruction = this.DecodeInstruction(instruction);
                var operation = decodedInstruction.Item1;
                var from = decodedInstruction.Item2;
                var to = decodedInstruction.Item3;

                for (var i = from.X; i <= to.X; i++)
                {
                    for (var j = from.Y; j <= to.Y; j++)
                    {
                        decoration[i, j] = this.OperateLight1(decoration[i, j], operation);
                    }
                }
            }

            var lights = 0;
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (decoration[i, j])
                    {
                        lights++;
                    }
                }
            }

            return lights;
        }

        private object SolvePart2(string[] input)
        {
            var decoration = new int[Rows, Columns];
            foreach (var instruction in input)
            {
                var decodedInstruction = this.DecodeInstruction(instruction);
                var operation = decodedInstruction.Item1;
                var from = decodedInstruction.Item2;
                var to = decodedInstruction.Item3;

                for (var i = from.X; i <= to.X; i++)
                {
                    for (var j = from.Y; j <= to.Y; j++)
                    {
                        decoration[i, j] = this.OperateLight2(decoration[i, j], operation);
                    }
                }
            }

            var lights = 0;
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    lights += decoration[i, j];
                }
            }

            return lights;
        }

        private Tuple<string, Position, Position> DecodeInstruction(string instruction)
        {
            var pos = 0;
            var instructionBits = instruction.Split(' ');
            var operation = instructionBits[pos];
            if (operation.Equals("turn"))
            {
                operation += $" {instructionBits[++pos]}";
            }

            var from = instructionBits[++pos].Split(',');
            pos++;
            var to = instructionBits[++pos].Split(',');

            return new Tuple<string, Position, Position>(
                operation,
                new Position(int.Parse(from[0]), int.Parse(from[1])),
                new Position(int.Parse(to[0]), int.Parse(to[1])));
        }

        private bool OperateLight1(bool state, string operation)
        {
            switch (operation)
            {
                case "turn on":
                    return true;
                case "turn off":
                    return false;
                default:
                    return !state;
            }
        }

        private int OperateLight2(int state, string operation)
        {
            switch (operation)
            {
                case "turn on":
                    return state + 1;
                case "turn off":
                    return state == 0 ? state : state - 1;
                default:
                    return state + 2;
            }
        }
    }
}
