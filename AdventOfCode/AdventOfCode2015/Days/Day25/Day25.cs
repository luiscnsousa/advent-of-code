namespace AdventOfCode2015.Days
{
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day25 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];

            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string input)
        {
            var rowAndColumn = this.ParseRowAndColumn(input);

            var size = rowAndColumn[0] + rowAndColumn[1];

            var codes = new long[size, size];
            long previousValue = 20151125;
            long multiplier = 252533;
            long divisor = 33554393;
            codes[0, 0] = previousValue;

            for (var i = 1; i < size; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    previousValue = (previousValue * multiplier) % divisor;

                    codes[i - j, j] = previousValue;
                }
            }

            return codes[rowAndColumn[0] - 1, rowAndColumn[1] - 1];
        }

        private object SolvePart2(string input)
        {
            return "YEAH!!!";
        }

        private int[] ParseRowAndColumn(string input)
        {
            var inputParts = input.Split(' ');
            var row = inputParts[inputParts.Length - 3];
            row = row.Substring(0, row.Length - 1);
            var column = inputParts[inputParts.Length - 1];
            column = column.Substring(0, column.Length - 1);
            return new[] { int.Parse(row), int.Parse(column) };
        }
    }
}
