namespace AdventOfCode2015.Days
{
    using System;
    using System.Globalization;
    using AdventOfCode2015.Common;
    using Infrastructure;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Day12 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];

            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string input)
        {
            return this.ParseAndSum1(JsonConvert.DeserializeObject<JToken>(input));
        }

        private object SolvePart2(string input)
        {
            return this.ParseAndSum2(JsonConvert.DeserializeObject<JToken>(input));
        }

        private int ParseAndSum1(JToken jToken)
        {
            var sum = 0;

            var jTokenValue = jToken as JValue;
            if (jTokenValue != null)
            {
                int intValue;
                if (int.TryParse(jTokenValue.ToString(CultureInfo.InvariantCulture), out intValue))
                {
                    sum += intValue;
                }

                return sum;
            }

            foreach (var value in jToken.Values())
            {
                sum += this.ParseAndSum1(value);
            }

            return sum;
        }

        private int ParseAndSum2(JToken jToken)
        {
            var sum = 0;

            var jTokenValue = jToken as JValue;
            if (jTokenValue != null)
            {
                int intValue;
                if (int.TryParse(jTokenValue.ToString(CultureInfo.InvariantCulture), out intValue))
                {
                    sum += intValue;
                }

                return sum;
            }

            foreach (var value in jToken)
            {
                var hasRed = false;
                var jObjectValue = value as JObject;
                if (jObjectValue != null)
                {
                    var objectValues = jObjectValue.Values();
                    foreach (var objectValue in objectValues)
                    {
                        var objectValueToken = objectValue as JValue;
                        if (objectValueToken != null)
                        {
                            hasRed = objectValueToken.ToString(CultureInfo.InvariantCulture)
                                .Equals("red", StringComparison.InvariantCultureIgnoreCase);
                        }

                        if (hasRed)
                        {
                            break;
                        }
                    }
                }

                if (!hasRed)
                {
                    sum += this.ParseAndSum2(value);
                }
            }

            return sum;
        }
    }
}
