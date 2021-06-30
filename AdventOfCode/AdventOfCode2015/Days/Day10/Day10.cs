namespace AdventOfCode2015.Days
{
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day10 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];

            var lookAndSay40 = this.SolvePart1(input);
            var answer = new Answer
                             {
                                 Part1 = ((string)lookAndSay40).Length,
                                 Part2 = ((string)this.SolvePart2((string)lookAndSay40)).Length
                             };
            
            return answer;
        }

        private object SolvePart1(string input)
        {
            return this.LookAndSay(input, 40);
        }

        private object SolvePart2(string input)
        {
            return this.LookAndSay(input, 10);
        }

        private string LookAndSay(string input, int iterations)
        {
            var result = input;

            for (var i = 0; i < iterations; i++)
            {
                var next = string.Empty;
                var currentNumber = result[0];
                var count = 0;
                for (var j = 0; j < result.Length; j++)
                {
                    if (result[j] == currentNumber)
                    {
                        count++;
                    }
                    else
                    {
                        next += $"{count}{currentNumber}";
                        count = 1;
                        currentNumber = result[j];
                    }
                }

                next += $"{count}{currentNumber}";
                result = next;
            }

            return result;
        }
    }
}
