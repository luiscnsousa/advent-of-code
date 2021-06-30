namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day03 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];
            
            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string input)
        {
            var santaPosition = new Position { X = 0, Y = 0 };
            var delivery = new List<Position> { new Position(santaPosition) };
            foreach (var direction in input)
            {
                delivery.Add(this.GetNextPosition(delivery, direction, santaPosition));
            }
            
            return this.GetNumberOfHousesWithPresent(delivery);
        }

        private object SolvePart2(string input)
        {
            var santaPosition = new Position { X = 0, Y = 0 };
            var robotPosition = new Position { X = 0, Y = 0 };
            var delivery = new List<Position> { new Position(santaPosition), new Position(robotPosition) };
            var isSanta = true;
            foreach (var direction in input)
            {
                var position = isSanta
                                   ? this.GetNextPosition(delivery, direction, santaPosition, robotPosition)
                                   : this.GetNextPosition(delivery, direction, robotPosition, santaPosition);
                delivery.Add(position);
                isSanta = !isSanta;
            }
            
            return this.GetNumberOfHousesWithPresent(delivery);
        }
        
        private Position GetNextPosition(List<Position> delivery, char direction, Position p1, Position p2 = null)
        {
            switch (direction)
            {
                case '^':
                    if (p1.X == 0)
                    {
                        for (var i = delivery.Count - 1; i >= 0; i--)
                        {
                            delivery[i].X++;
                        }

                        if (p2 != null)
                        {
                            p2.X++;
                        }
                    }
                    else
                    {
                        p1.X--;
                    }

                    break;

                case 'v':
                    p1.X++;
                    break;

                case '<':
                    if (p1.Y == 0)
                    {
                        for (var i = delivery.Count - 1; i >= 0; i--)
                        {
                            delivery[i].Y++;
                        }

                        if (p2 != null)
                        {
                            p2.Y++;
                        }
                    }
                    else
                    {
                        p1.Y--;
                    }

                    break;

                case '>':
                    p1.Y++;
                    break;
            }

            return new Position { X = p1.X, Y = p1.Y };
        }

        private int GetNumberOfHousesWithPresent(List<Position> delivery)
        {
            var rows = delivery.Max(p => p.X) + 1;
            var columns = delivery.Max(p => p.Y) + 1;
            var grid = new int[rows, columns];
            foreach (var position in delivery)
            {
                grid[position.X, position.Y]++;
            }

            var housesWithPresent = 0;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (grid[i, j] > 0)
                    {
                        housesWithPresent++;
                    }
                }
            }

            return housesWithPresent;
        }
    }
}
