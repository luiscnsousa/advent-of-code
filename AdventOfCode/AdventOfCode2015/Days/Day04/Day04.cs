namespace AdventOfCode2015.Days
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day04 : IExercise
    {
        private static bool UseMultiTasking = true;

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput()[0];
            
            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string input)
        {
            return UseMultiTasking 
                ? this.MultiTaskProcess(input, "00000")
                : this.Process(input, "00000");
        }

        private object SolvePart2(string input)
        {
            return UseMultiTasking
                ? this.MultiTaskProcess(input, "000000")
                : this.Process(input, "000000");
        }

        private int Process(string secretKey, string startingWith)
        {
            var wantedNumber = 0;
            var hash = string.Empty;
            using (MD5 md5Hash = MD5.Create())
            {
                while (!hash.StartsWith(startingWith))
                {
                    wantedNumber++;
                    var source = $"{secretKey}{wantedNumber}";
                    hash = GetMd5Hash(md5Hash, source);
                }
            }

            return wantedNumber;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        #region MultiTask version

        private const int Interval = 50000;

        private int currentMax;

        private int wantedInt;

        private readonly object lockObj = new object();

        private Tuple<int, int> GetNextInterval()
        {
            int from, to;
            lock (this.lockObj)
            {
                from = this.currentMax + 1;
                this.currentMax += Interval;
                to = this.currentMax;
            }

            return new Tuple<int, int>(from, to);
        }

        private int MultiTaskProcess(string secretKey, string startingWith)
        {
            this.wantedInt = 0;
            this.currentMax = 0;
            var tasks = new Task[Environment.ProcessorCount];
            for (var i = 0; i < tasks.Length; i++)
            {
                var t = new Task(
                    () =>
                        {
                            using (MD5 md5Hash = MD5.Create())
                            {
                                while (this.wantedInt == 0)
                                {
                                    var interval = this.GetNextInterval();
                                    var currentInt = interval.Item1;
                                    while (currentInt <= interval.Item2 && this.wantedInt == 0)
                                    {
                                        var source = $"{secretKey}{currentInt}";
                                        var hash = GetMd5Hash(md5Hash, source);
                                        if (hash.StartsWith(startingWith))
                                        {
                                            this.wantedInt = currentInt;
                                        }

                                        currentInt++;
                                    }
                                }
                            }
                        });
                tasks[i] = t;
                t.Start();
            }

            Task.WaitAny(tasks);
            return this.wantedInt;
        }

        #endregion
    }
}
