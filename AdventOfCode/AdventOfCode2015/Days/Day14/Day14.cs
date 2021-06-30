namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day14 : IExercise
    {
        private const int RaceEnd = 2503;

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var reindeers = this.ParseReindeers(input);

            return new Answer { Part1 = this.SolvePart1(reindeers), Part2 = this.SolvePart2(reindeers) };
        }

        private object SolvePart1(List<Reindeer> reindeers)
        {
            var winningReindeerDistance = 0;

            foreach (var reindeer in reindeers)
            {
                var combinedTimes = reindeer.FlyTime + reindeer.RestTime;
                var fullCycles = RaceEnd / combinedTimes;
                var time = combinedTimes * fullCycles;
                var distance = reindeer.FlySpeed * reindeer.FlyTime * fullCycles;
                var isFlying = true;
                while (time < RaceEnd)
                {
                    if (isFlying)
                    {
                        if (time + reindeer.FlyTime <= RaceEnd)
                        {
                            time += reindeer.FlyTime;
                            distance += reindeer.FlySpeed * reindeer.FlyTime;
                        }
                        else
                        {
                            var remainingTime = RaceEnd - time;
                            time += remainingTime;
                            distance += (remainingTime / reindeer.FlyTime) * reindeer.FlySpeed;
                        }
                    }
                    else
                    {
                        time += reindeer.RestTime;
                    }

                    isFlying = !isFlying;
                }

                if (distance > winningReindeerDistance)
                {
                    winningReindeerDistance = distance;
                }
            }

            return winningReindeerDistance;
        }

        private object SolvePart2(List<Reindeer> reindeers)
        {
            var distances = new int[reindeers.Count];
            var points = new int[reindeers.Count];

            for (var i = 0; i <= RaceEnd; i++)
            {
                for (var j = 0; j < reindeers.Count; j++)
                {
                    var reindeer = reindeers[j];
                    
                    var combinedTimes = reindeer.FlyTime + reindeer.RestTime;
                    var fullCycles = i / combinedTimes;
                    var time = combinedTimes * fullCycles;
                    var isFlying = time + reindeer.FlyTime > i;
                    
                    if (isFlying)
                    {
                        distances[j] += reindeer.FlySpeed;
                    }
                }

                var lead = distances.Max();
                for (var k = 0; k < reindeers.Count; k++)
                {
                    if (distances[k] == lead)
                    {
                        points[k]++;
                    }
                }
            }

            return points.Max();
        }

        private List<Reindeer> ParseReindeers(string[] input)
        {
            var reindeers = new List<Reindeer>();

            foreach (var reindeerSpec in input)
            {
                var reindeer = reindeerSpec.Split(' ');

                reindeers.Add(
                    new Reindeer(reindeer[0])
                        {
                            FlySpeed = int.Parse(reindeer[3]),
                            FlyTime = int.Parse(reindeer[6]),
                            RestTime = int.Parse(reindeer[reindeer.Length - 2])
                        });
            }

            return reindeers;
        } 
    }
}
