namespace AdventOfCode2015.Common
{
    public class Reindeer
    {
        public Reindeer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int FlySpeed { get; set; }

        public int FlyTime { get; set; }

        public int RestTime { get; set; }
    }
}
