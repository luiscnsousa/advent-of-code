namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day17 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var containers = this.ParseContainers(input);
            
            return new Answer { Part1 = this.SolvePart1(containers), Part2 = this.SolvePart2(containers) };
        }

        private object SolvePart1(List<Container> containers)
        {
            var combinations = new List<List<Container>>();

            //this.MakeAllContainersCombinations1(combinations, new List<Container>(), containers, 150);

            return combinations.Count;
        }

        private object SolvePart2(List<Container> containers)
        {
            var combinations = new List<List<Container>>();

            this.MakeAllContainersCombinations2(combinations, new List<Container>(), containers, 150);

            return combinations.Count;
        }

        private List<Container> ParseContainers(string[] input)
        {
            var containers = new List<Container>();
            foreach (var s in input)
            {
                containers.Add(new Container(int.Parse(s)));
            }

            return containers;
        }

        private void MakeAllContainersCombinations1(List<List<Container>> combinations, List<Container> currentCombination, List<Container> availableContainers, int remainingLiters)
        {
            if (remainingLiters == 0)
            {
                var exists =
                    combinations.Where(c => c.Count == currentCombination.Count)
                        .Any(combination => combination.All(currentCombination.Contains));

                if (!exists)
                {
                    combinations.Add(currentCombination.ToList());
                }
            }
            else if (remainingLiters > 0)
            {
                var containers = availableContainers.ToList();

                foreach (var container in containers)
                {
                    availableContainers.Remove(container);
                    currentCombination.Add(container);
                    this.MakeAllContainersCombinations1(
                        combinations,
                        currentCombination,
                        availableContainers,
                        remainingLiters - container.Capacity);
                    availableContainers.Add(container);
                    currentCombination.Remove(container);
                }
            }
        }

        private void MakeAllContainersCombinations2(List<List<Container>> combinations, List<Container> currentCombination, List<Container> availableContainers, int remainingLiters)
        {
            if (remainingLiters == 0)
            {
                if (!combinations.Any())
                {
                    combinations.Add(currentCombination.ToList());
                }
                else if (currentCombination.Count < combinations.First().Count)
                {
                    combinations.Clear();
                    combinations.Add(currentCombination.ToList());
                }
                else if (currentCombination.Count == combinations.First().Count)
                {
                    var exists =
                           combinations.Where(c => c.Count == currentCombination.Count)
                               .Any(combination => combination.All(currentCombination.Contains));

                    if (!exists)
                    {
                        combinations.Add(currentCombination.ToList());
                    }
                }
            }
            else if (remainingLiters > 0)
            {
                if (combinations.Any() && combinations.First().Count < currentCombination.Count)
                {
                    return;
                }

                var containers = availableContainers.ToList();

                foreach (var container in containers)
                {
                    availableContainers.Remove(container);
                    currentCombination.Add(container);
                    this.MakeAllContainersCombinations2(
                        combinations,
                        currentCombination,
                        availableContainers,
                        remainingLiters - container.Capacity);
                    availableContainers.Add(container);
                    currentCombination.Remove(container);
                }
            }
        }
    }
}
