namespace AdventOfCode2015.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day09 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var locations = this.BuildNetwork(input);

            var distances = this.CalculateRoutes(locations);

            return new Answer { Part1 = this.SolvePart1(distances), Part2 = this.SolvePart2(distances) };
        }

        private object SolvePart1(List<int> distances)
        {
            return distances.Min();
        }

        private object SolvePart2(List<int> distances)
        {
            return distances.Max();
        }

        private List<Location> BuildNetwork(string[] input)
        {
            var locations = new List<Location>();
            foreach (var trip in input)
            {
                var tripParts = trip.Split(new[] { "to", "=" }, StringSplitOptions.None);
                var from = tripParts[0].Trim();
                var to = tripParts[1].Trim();
                var distance = int.Parse(tripParts[2].Trim());

                var fromLocation = locations.SingleOrDefault(l => l.Name.Equals(from));
                if (fromLocation == null)
                {
                    fromLocation = new Location(from);
                    locations.Add(fromLocation);
                }

                var toLocation = locations.SingleOrDefault(l => l.Name.Equals(to));
                if (toLocation == null)
                {
                    toLocation = new Location(to);
                    locations.Add(toLocation);
                }

                if (fromLocation.Connections.All(c => c.Destination != toLocation))
                {
                    fromLocation.Connections.Add(new Connection(toLocation, distance));
                }

                if (toLocation.Connections.All(c => c.Destination != fromLocation))
                {
                    toLocation.Connections.Add(new Connection(fromLocation, distance));
                }
            }

            return locations;
        }

        private List<int> CalculateRoutes(List<Location> locations)
        {
            var distances = new List<int>();
            foreach (var location in locations)
            {
                distances.AddRange(this.Travel(locations, new List<Location> { location }, new List<int>(), 0));
            }

            return distances;
        } 

        private List<int> Travel(List<Location> locations, List<Location> route, List<int> distances, int currentDistance)
        {
            var currentLocation = route.Last();
            if (locations.Count == route.Count)
            {
                //Console.WriteLine($"{currentLocation.Name} = {currentDistance}");

                distances.Add(currentDistance);
                return distances;
            }

            var possibleDestinations = currentLocation.Connections.Where(c => !route.Contains(c.Destination));
            foreach (var connection in possibleDestinations)
            {
                //Console.Write($"{currentLocation.Name} -> ");

                var newRoute = route.ToList();
                newRoute.Add(connection.Destination);

                var newDistance = currentDistance + connection.Distance;

                this.Travel(locations, newRoute, distances, newDistance);
            }

            return distances;
        }
    }
}
