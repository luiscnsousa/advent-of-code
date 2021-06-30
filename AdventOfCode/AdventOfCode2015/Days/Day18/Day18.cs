namespace AdventOfCode2015.Days
{
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day18 : IExercise
    {
        private bool[,] Lights;

        private const int Length = 100;

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();
            
            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string[] input)
        {
            this.ParseLights(input);
            var steps = 100;
            while (steps > 0)
            {
                var newLights = new bool[Length, Length];

                for (var i = 0; i < Length; i++)
                {
                    for (var j = 0; j < Length; j++)
                    {
                        var neighborsOn = this.CountNeighborsOn(i, j);
                        if (this.Lights[i, j])
                        {
                            newLights[i, j] = neighborsOn >= 2 && neighborsOn <= 3;
                        }
                        else
                        {
                            newLights[i, j] = neighborsOn == 3;
                        }
                    }
                }

                this.Lights = newLights;

                steps--;
            }
            
            return this.CountLightsOn();
        }

        private object SolvePart2(string[] input)
        {
            this.ParseLights(input);
            var steps = 100;
            this.SetStuckOnLights();
            while (steps > 0)
            {
                var newLights = new bool[Length, Length];

                for (var i = 0; i < Length; i++)
                {
                    for (var j = 0; j < Length; j++)
                    {
                        if ((i == 0 && j == 0) 
                            || (i == 0 && j == Length - 1) 
                            || (i == Length - 1 && j == 0)
                            || (i == Length - 1 && j == Length - 1))
                        {
                            continue;
                        }

                        var neighborsOn = this.CountNeighborsOn(i, j);
                        if (this.Lights[i, j])
                        {
                            newLights[i, j] = neighborsOn >= 2 && neighborsOn <= 3;
                        }
                        else
                        {
                            newLights[i, j] = neighborsOn == 3;
                        }
                    }
                }

                this.Lights = newLights;
                this.SetStuckOnLights();
                steps--;
            }

            return this.CountLightsOn();
        }

        private void ParseLights(string[] input)
        {
            this.Lights = new bool[input.Length, input.Length];

            for (var i = 0; i < input.Length; i++)
            {
                var row = input[i];
                for (var j = 0; j < row.Length; j++)
                {
                    this.Lights[i, j] = row[j] == '#';
                }
            }
        }

        private int CountNeighborsOn(int row, int column)
        {
            var startingRow = row - 1;
            if (startingRow < 0)
            {
                startingRow = 0;
            }

            var endingRow = row + 1;
            if (endingRow > Length - 1)
            {
                endingRow = Length - 1;
            }

            var startingColumn = column - 1;
            if (startingColumn < 0)
            {
                startingColumn = 0;
            }

            var endingColumn = column + 1;
            if (endingColumn > Length - 1)
            {
                endingColumn = Length - 1;
            }

            var count = 0;
            for (var i = startingRow; i <= endingRow; i++)
            {
                for (var j = startingColumn; j <= endingColumn; j++)
                {
                    if (i == row && j == column)
                    {
                        continue;
                    }

                    if (this.Lights[i, j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private int CountLightsOn()
        {
            var count = 0;
            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    if (this.Lights[i, j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void SetStuckOnLights()
        {
            this.Lights[0, 0] = true;
            this.Lights[0, Length - 1] = true;
            this.Lights[Length - 1, 0] = true;
            this.Lights[Length - 1, Length - 1] = true;
        }
    }
}
