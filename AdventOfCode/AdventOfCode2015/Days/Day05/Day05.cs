namespace AdventOfCode2015.Days
{
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day05 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string[] input)
        {
            var niceStrings = input.Count(this.isNice1);

            return niceStrings;
        }

        private object SolvePart2(string[] input)
        {
            var niceStrings = input.Count(this.isNice2);

            return niceStrings;
        }

        private bool isNice1(string s)
        {
            var pos = 0;
            var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
            var numberOfVowels = 0;
            while (numberOfVowels < 3 && pos < s.Length)
            {
                if (vowels.Contains(s[pos]))
                {
                    numberOfVowels++;
                }

                pos++;
            }

            if (numberOfVowels < 3)
            {
                return false;
            }

            pos = 0;
            var twiceInARow = false;
            while (!twiceInARow && pos < s.Length - 1)
            {
                if (s[pos] == s[pos + 1])
                {
                    twiceInARow = true;
                }

                pos++;
            }

            if (!twiceInARow)
            {
                return false;
            }

            pos = 0;
            var substrings = new[] { "ab", "cd", "pq", "xy" };
            var isNaughty = false;
            while (!isNaughty && pos < substrings.Length)
            {
                if (s.Contains(substrings[pos]))
                {
                    isNaughty = true;
                }

                pos++;
            }

            return !isNaughty;
        }

        private bool isNice2(string s)
        {
            var pos = 0;
            var twiceWithoutOverlap = false;
            while (!twiceWithoutOverlap && pos < s.Length - 2)
            {
                var s1 = s.Substring(pos + 2);
                if (s1.Contains(s.Substring(pos, 2)))
                {
                    twiceWithoutOverlap = true;
                }

                pos++;
            }

            if (!twiceWithoutOverlap)
            {
                return false;
            }

            pos = 0;
            var repeat = false;
            while (!repeat && pos < s.Length - 2)
            {
                if (s[pos] == s[pos + 2])
                {
                    repeat = true;
                }

                pos++;
            }

            return repeat;
        }
    }
}
