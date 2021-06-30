namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day24 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var packages = input.Select(weight => new Package(int.Parse(weight))).OrderByDescending(p => p.Weight).ToList();

            return new Answer { Part1 = this.SolvePart(packages, 3), Part2 = this.SolvePart(packages, 4) };
        }

        private object SolvePart(List<Package> packages, int numberOfBags)
        {
            var totalWeight = packages.Sum(p => p.Weight);
            if (totalWeight % numberOfBags != 0)
            {
                return string.Empty;
            }

            var totalPerBag = totalWeight / numberOfBags;

            var combinations = new List<List<Package>>();
            this.MakeAllPackagesCombinations(combinations, new List<Package>(), packages, totalPerBag);
            
            return this.QuantumEntanglement(combinations.OrderBy(c => c.Count).ThenBy(this.QuantumEntanglement).First());
        }

        private long QuantumEntanglement(List<Package> bag)
        {
            long result = 1;
            foreach (var package in bag)
            {
                result *= package.Weight;
            }

            return result;
        }

        private void MakeAllPackagesCombinations(List<List<Package>> combinations, List<Package> currentCombination, List<Package> availablePackages, int remainingWeight)
        {
            if (remainingWeight == 0)
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
                    if (!combinations.Any(combination => combination.All(currentCombination.Contains)))
                    {
                        combinations.Add(currentCombination.ToList());
                    }
                }
            }
            else if (remainingWeight > 0)
            {
                if (combinations.Any() && combinations.First().Count < currentCombination.Count)
                {
                    return;
                }

                var packages = availablePackages.ToList();

                foreach (var package in packages)
                {
                    availablePackages.Remove(package);
                    currentCombination.Add(package);
                    this.MakeAllPackagesCombinations(
                        combinations,
                        currentCombination,
                        availablePackages,
                        remainingWeight - package.Weight);
                    availablePackages.Add(package);
                    currentCombination.Remove(package);
                }
            }
        }
    }
}
