namespace AdventOfCode2015.Days
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day08 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var answer = new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
            
            return answer;
        }

        private object SolvePart1(string[] input)
        {
            var charsOfCode = 0;
            var charsInMemory = 0;
            foreach (var s in input)
            {
                charsOfCode += s.Length;

                var substring = s.Substring(1, s.Length - 2);

                var hexPattern = @"\\x[A-Fa-f0-9]{2}";
                if (Regex.IsMatch(substring, hexPattern))
                {
                    var matches = Regex.Matches(substring, hexPattern);
                    foreach (var match in matches.OfType<Match>().Select(m => m.Value).Distinct())
                    {
                        var hex = match.Substring(2, 2);
                        uint decval = Convert.ToUInt32(hex, 16);
                        char character = Convert.ToChar(decval);
                        substring = substring.Replace(match, $"{character}");
                    }
                }

                charsInMemory += substring.Replace("\\\"", "\"").Replace("\\\\", "\\").Length;
            }

            return charsOfCode - charsInMemory;
        }

        private object SolvePart2(string[] input)
        {
            var charsOfCode = 0;
            var totalChars = 0;
            foreach (var s in input)
            {
                charsOfCode += s.Length;
                var escapedString = s.Replace("\"", "\"\"").Replace("\\", "\\\\");
                escapedString = $"\"{escapedString}\"";
                totalChars += escapedString.Length;
            }

            return totalChars - charsOfCode;
        }
    }
}
