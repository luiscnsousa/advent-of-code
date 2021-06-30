namespace AdventOfCode2015.Common
{
    public class Weapon : Item
    {
        public Weapon(string name, int cost, int damage) : base(name, cost)
        {
            this.Damage = damage;
        }
    }
}
