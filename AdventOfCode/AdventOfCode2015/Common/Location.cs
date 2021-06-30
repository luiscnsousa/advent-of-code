namespace AdventOfCode2015.Common
{
    using System.Collections.Generic;

    public class Location
    {
        public Location(string name)
        {
            this.Name = name;
            this.Connections = new List<Connection>();
        }

        public string Name { get; set; }

        public List<Connection> Connections { get; private set; }
    }
}
