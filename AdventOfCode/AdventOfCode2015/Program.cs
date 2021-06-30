namespace AdventOfCode2015
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using AdventOfCode2015.Days;
    using Infrastructure;

    class Program
    {
        //// http://adventofcode.com/
        
        static void Main(string[] args)
        {
            var exercises = new IExercise[]
                                {
                                    new Day01(), new Day02(), new Day03(), new Day04(), new Day05(),
                                    new Day06(), new Day07(), new Day08(), new Day09(), new Day10(),
                                    new Day11(), new Day12(), new Day13(), new Day14(), new Day15(),
                                    new Day16(), new Day17(), new Day18(), new Day19(), new Day20(),
                                    new Day21(), new Day22(), new Day23(), new Day24(), new Day25()
                                };

            if (args.Any())
            {
                exercises =
                    exercises.Where(
                        e =>
                        args.Any(arg => $"Day{arg}".Equals(e.GetType().Name) || $"Day0{arg}".Equals(e.GetType().Name)))
                        .ToArray();
            }
            
            var watch = new Stopwatch();
            foreach (var exercise in exercises)
            {
                watch.Start();
                var answer = exercise.Solve();
                watch.Stop();
                Console.Write($"{exercise.GetType().Name} -> {answer}");
                Console.WriteLine($";  {watch.ElapsedMilliseconds}ms");
                watch.Reset();
            }

            Console.ReadLine();
        }
    }
}