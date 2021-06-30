namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day11 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];

            var answer = new Answer { Part1 = this.SolvePart1(input) };
            answer.Part2 = this.SolvePart2((string)answer.Part1);

            return answer;
        }

        private object SolvePart1(string input)
        {
            return this.GetNextPassword(input);
        }

        private object SolvePart2(string input)
        {
            return this.GetNextPassword(input);
        }

        private string GetNextPassword(string input)
        {
            var nextPassword = input;
            var meetRequirements = false;
            var limit = new string('z', input.Length);
            var lastIndex = nextPassword.Length - 1;

            while (!meetRequirements && !nextPassword.Equals(limit))
            {
                var c = nextPassword[lastIndex];
                if (c == 'z')
                {
                    var i = lastIndex;
                    c = 'a';
                    var wrapped = true;
                    while (wrapped)
                    {
                        nextPassword = nextPassword.Remove(i, 1);
                        nextPassword = nextPassword.Insert(i, new string(c, 1));
                        i--;
                        wrapped = i >= 0 && nextPassword[i] == 'z';
                    }

                    if (i >= 0)
                    {
                        c = nextPassword[i];
                        c++;
                        nextPassword = nextPassword.Remove(i, 1);
                        nextPassword = nextPassword.Insert(i, new string(c, 1));
                    }
                }
                else
                {
                    c++;
                    nextPassword = nextPassword.Remove(lastIndex, 1);
                    nextPassword = nextPassword.Insert(lastIndex, new string(c, 1));
                }


                var noForbiddenLetters = !nextPassword.Contains("i")
                    && !nextPassword.Contains("o")
                    && !nextPassword.Contains("l");
                if (!noForbiddenLetters)
                {
                    continue;
                }


                var increasingStraight = false;
                var j = 0;
                while (!increasingStraight && j < nextPassword.Length - 2)
                {
                    var substring = nextPassword.Substring(j, 3);
                    if (substring[1] == (substring[0] + 1) && substring[2] == (substring[0] + 2))
                    {
                        increasingStraight = true;
                    }

                    j++;
                }

                if (!increasingStraight)
                {
                    continue;
                }


                var nonOverlappingPairs = new List<string>();
                var k = 0;
                while (nonOverlappingPairs.Count < 2 && k < nextPassword.Length - 1)
                {
                    var substring = nextPassword.Substring(k, 2);
                    if (substring[0] == substring[1] && !nonOverlappingPairs.Contains(substring))
                    {
                        nonOverlappingPairs.Add(substring);
                        k++;
                    }

                    k++;
                }

                if (nonOverlappingPairs.Count >= 2)
                {
                    meetRequirements = true;
                }
            }

            return nextPassword;
        }
    }
}
