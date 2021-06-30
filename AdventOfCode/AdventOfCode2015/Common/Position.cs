namespace AdventOfCode2015.Common
{
    public class Position
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position(Position p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
