namespace AdventOfCode2015.Days
{
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day20 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];

            return new Answer { Part1 = this.SolvePart1(int.Parse(input), 775000), Part2 = this.SolvePart2(int.Parse(input), 785000) };
        }
        
        // The "seed" is just to speed things up. Instead of starting from 1, the algorithm starts from seed.
        private object SolvePart1(int input, int seed) 
        {
            var i = seed > 0 ? seed : 0;

            var found = false;
            while (!found)
            {
                i++;
                var sum = i * 10;
                for (var j = 1; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        sum += j * 10;
                    }
                }

                if (sum >= input)
                {
                    found = true;
                }
            }
            
            //var elves = new List<Elf>();
            //var houses = new List<int> { 0 };
            //while (houses[i] != input)
            //{
            //    i++;
            //    houses.Add(0);
            //    var newElf = new Elf(i);
            //    elves.Add(newElf);
            //    houses[i] += newElf.Presents;
            //    for (var j = 0; j <= (i / 2) - 1; j++)
            //    {
            //        var elf = elves[j];
            //        while (elf.CurrentHouse + elf.Number <= i)
            //        {
            //            elf.CurrentHouse += elf.Number;
            //            houses[elf.CurrentHouse] += elf.Presents;
            //        }
            //    }
            //}

            return i;
        }

        private object SolvePart2(int input, int seed)
        {
            var i = seed > 0 ? seed : 0;

            var found = false;
            while (!found)
            {
                i++;
                var sum = i * 11;
                for (var j = 1; j <= i / 2; j++)
                {
                    if (i % j == 0 && i <= j * 50)
                    {
                        sum += j * 11;
                    }
                }

                if (sum >= input)
                {
                    found = true;
                }
            }

            return i;
        }
    }
}
