namespace AdventOfCode2015.Common
{
    public class Sue
    {
        public Sue(int number)
        {
            this.Number = number;
        }

        public int Number { get; private set; }

        public int? children { get; set; }

        public int? cats { get; set; }

        public int? samoyeds { get; set; }

        public int? pomeranians { get; set; }

        public int? akitas { get; set; }

        public int? vizslas { get; set; }

        public int? goldfish { get; set; }

        public int? trees { get; set; }

        public int? cars { get; set; }

        public int? perfumes { get; set; }
    }
}
