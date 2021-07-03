namespace AdventOfCode2016.Days
{
    using AdventOfCode2016.Common;
    using Infrastructure;

    public class Day01 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];

            return new Answer { Part1 = SolvePart1(input), Part2 = SolvePart2(input) };
        }

        private object SolvePart1(string input)
        {
            var gps = new GPS(new Compass());

            foreach (var step in input.Split(", "))
            {
                gps.Go(step);
            }
            
            return gps.GetDistance();
        }

        private object SolvePart2(string input)
        {
            var gps = new GPS(new Compass());

            string revisit = null;
            foreach (var step in input.Split(", "))
            {
                gps.Go(step);
                revisit = gps.GetPlaceRevisited();
                if (revisit != null)
                {
                    break;
                }
            }

            var revisitPos = revisit.Split(",");
            
            return gps.GetDistance(
                int.Parse(revisitPos[0]),
                int.Parse(revisitPos[1]));
        }
    }
}