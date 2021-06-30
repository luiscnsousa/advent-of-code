namespace Infrastructure
{
    public class Answer
    {
        public object Part1 { get; set; }

        public object Part2 { get; set; }

        public override string ToString()
        {
            var toString = string.Empty;

            var part1 = this.Part1?.ToString();
            if (!string.IsNullOrEmpty(part1))
            {
                toString += $"{nameof(this.Part1)}: {part1}";
            }

            var part2 = this.Part2?.ToString();
            if (!string.IsNullOrEmpty(part2))
            {
                toString += $"; {nameof(this.Part2)}: {part2}";
            }

            return toString;
        }
    }
}
