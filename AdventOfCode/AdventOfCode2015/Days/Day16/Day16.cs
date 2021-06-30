namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day16 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var sues = this.ParseSues(input);

            return new Answer { Part1 = this.SolvePart1(sues), Part2 = this.SolvePart2(sues) };
        }

        private object SolvePart1(List<Sue> sues)
        {
            var wantedSue =
                sues.Single(
                    s =>
                    (!s.children.HasValue || s.children.Value == 3) 
                    && (!s.cats.HasValue || s.cats.Value == 7)
                    && (!s.samoyeds.HasValue || s.samoyeds.Value == 2)
                    && (!s.pomeranians.HasValue || s.pomeranians.Value == 3)
                    && (!s.akitas.HasValue || s.akitas.Value == 0) 
                    && (!s.vizslas.HasValue || s.vizslas.Value == 0)
                    && (!s.goldfish.HasValue || s.goldfish.Value == 5) 
                    && (!s.trees.HasValue || s.trees.Value == 3)
                    && (!s.cars.HasValue || s.cars.Value == 2) 
                    && (!s.perfumes.HasValue || s.perfumes.Value == 1));

            return wantedSue.Number;
        }

        private object SolvePart2(List<Sue> sues)
        {
            var wantedSue =
                sues.Single(
                    s =>
                    (!s.children.HasValue || s.children.Value == 3)
                    && (!s.cats.HasValue || s.cats.Value > 7)
                    && (!s.samoyeds.HasValue || s.samoyeds.Value == 2)
                    && (!s.pomeranians.HasValue || s.pomeranians.Value < 3)
                    && (!s.akitas.HasValue || s.akitas.Value == 0)
                    && (!s.vizslas.HasValue || s.vizslas.Value == 0)
                    && (!s.goldfish.HasValue || s.goldfish.Value < 5)
                    && (!s.trees.HasValue || s.trees.Value > 3)
                    && (!s.cars.HasValue || s.cars.Value == 2)
                    && (!s.perfumes.HasValue || s.perfumes.Value == 1));

            return wantedSue.Number;
        }

        private List<Sue> ParseSues(string[] input)
        {
            var sues = new List<Sue>();
            var type = typeof(Sue);
            foreach (var s in input)
            {
                var sue = s.Split(' ');
                var newSue = new Sue(int.Parse(sue[1].Substring(0, sue[1].Length - 1)));

                type.GetProperty(sue[2].Substring(0, sue[2].Length - 1))
                    .SetValue(newSue, int.Parse(sue[3].Substring(0, sue[3].Length - 1)));
                type.GetProperty(sue[4].Substring(0, sue[4].Length - 1))
                    .SetValue(newSue, int.Parse(sue[5].Substring(0, sue[5].Length - 1)));
                type.GetProperty(sue[6].Substring(0, sue[6].Length - 1))
                    .SetValue(newSue, int.Parse(sue[7]));

                sues.Add(newSue);
            }

            return sues;
        } 
    }
}
