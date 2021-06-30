namespace AdventOfCode2015.Days
{
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day02 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string[] input)
        {
            var totalArea = 0;
            foreach (var presentDimensions in input)
            {
                var dimensions = presentDimensions.Split('x');
                var l = int.Parse(dimensions[0]);
                var w = int.Parse(dimensions[1]);
                var h = int.Parse(dimensions[2]);
                var areas = new[] { l * w, w * h, h * l };
                totalArea += (areas.Sum() * 2) + areas.Min();
            }

            return totalArea;
        }

        private object SolvePart2(string[] input)
        {
            var totalRibbon = 0;
            foreach (var presentDimensions in input)
            {
                var dimensions = presentDimensions.Split('x').Select(int.Parse).ToList();
                dimensions.Sort();

                var ribbon = dimensions[0] + dimensions[0] + dimensions[1] + dimensions[1];
                totalRibbon += ribbon + dimensions.Aggregate((a, x) => a * x);
            }

            return totalRibbon;
        }
    }
}
