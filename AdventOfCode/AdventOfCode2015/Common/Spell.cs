namespace AdventOfCode2015.Common
{
    public class Spell : Item
    {
        public Spell(string name, int cost, int damage, int armor, int leech, int replenish, int duration) : base(name, cost)
        {
            this.Damage = damage;
            this.Armor = armor;
            this.Leech = leech;
            this.Replenish = replenish;
            this.Duration = duration;
        }

        public int Replenish { get; set; }

        public int Leech { get; set; }

        public int Duration { get; set; }
    }
}
