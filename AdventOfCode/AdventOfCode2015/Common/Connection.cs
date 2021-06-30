namespace AdventOfCode2015.Common
{
    public class Connection
    {
        public Connection(Location destination, int distance)
        {
            this.Destination = destination;
            this.Distance = distance;
        }

        public Location Destination { get; private set; }

        public int Distance { get; private set; }
    }
}
