namespace AdventOfCode2016
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using AdventOfCode2016.Days;
    using Infrastructure;

    class Program
    {
        //// https://adventofcode.com/2016
        
        static void Main(string[] args)
        {
            var exercises = new IExercise[]
            {
                new Day01(), new Day02()
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