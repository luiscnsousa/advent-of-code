namespace AdventOfCode2015.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day19 : IExercise
    {
        private List<Replacement> replacements;

        private string molecule;

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            this.ParseReplacementsAndMolecule(input);

            return new Answer { Part1 = this.SolvePart1(), Part2 = this.SolvePart2() };
        }

        private object SolvePart1()
        {
            var molecules = new List<string>();
            this.GenerateDistinctMolecules(molecules, this.molecule);

            return molecules.Count;
        }

        private object SolvePart2()
        {
            return this.HowManyStepsToMolecule();
        }

        private void ParseReplacementsAndMolecule(string[] input)
        {
            this.replacements = new List<Replacement>();
            
            var i = 0;
            while (!string.IsNullOrEmpty(input[i]))
            {
                var r = input[i].Split(new[] { "=>" }, StringSplitOptions.None);
                this.replacements.Add(new Replacement { OldValue = r[0].TrimEnd(), NewValue = r[1].TrimStart() });

                i++;
            }

            this.molecule = input[input.Length - 1];
        }

        private void GenerateDistinctMolecules(List<string> molecules, string initialMolecule)
        {
            foreach (var replacement in this.replacements)
            {
                var index = initialMolecule.IndexOf(replacement.OldValue, StringComparison.InvariantCulture);
                while (index != -1)
                {
                    var newMolecule = initialMolecule.Remove(index, replacement.OldValue.Length);
                    newMolecule = newMolecule.Insert(index, replacement.NewValue);

                    if (!molecules.Contains(newMolecule))
                    {
                        molecules.Add(newMolecule);
                    }

                    index = initialMolecule.IndexOf(
                        replacement.OldValue,
                        index + replacement.OldValue.Length,
                        StringComparison.InvariantCulture);
                }
            }
        }

        private int HowManyStepsToMolecule()
        {
            var steps = 0;
            while (!this.molecule.Equals("e"))
            {
                var replacement =
                    this.replacements.Where(r => this.molecule.Contains(r.NewValue))
                        .OrderByDescending(r => r.NewValue.Length)
                        .First();
                
                var index = this.molecule.IndexOf(replacement.NewValue, StringComparison.InvariantCulture);
                this.molecule = this.molecule.Remove(index, replacement.NewValue.Length);
                this.molecule = this.molecule.Insert(index, replacement.OldValue);
                steps++;
            }

            return steps;
        }
    }
}
