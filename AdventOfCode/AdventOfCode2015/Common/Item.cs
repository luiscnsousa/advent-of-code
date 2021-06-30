namespace AdventOfCode2015.Common
{
    public abstract class Item
    {
        protected Item(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name { get; private set; }

        public int Cost { get; set; }

        public int Damage { get; set; }

        public int Armor { get; set; }
    }
}
