namespace AdventOfCode2015.Days
{
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day01 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];

            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string input)
        {
            var floor = 0;
            foreach (var c in input)
            {
                floor = this.NextFloor(floor, c);
            }

            return floor;
        }

        private object SolvePart2(string input)
        {
            int floor = 0, position = 0;
            while (floor != -1 && position < input.Length)
            {
                floor = this.NextFloor(floor, input[position]);
                position++;
            }

            return position;
        }

        private int NextFloor(int floor, char c)
        {
            if (c == '(')
            {
                return ++floor;
            }

            if (c == ')')
            {
                return --floor;
            }

            return floor;
        }
    }
}
