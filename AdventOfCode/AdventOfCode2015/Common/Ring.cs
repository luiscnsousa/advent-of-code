namespace AdventOfCode2015.Common
{
    public class Ring : Item
    {
        public Ring(string name, int cost, int damage, int armor) : base(name, cost)
        {
            this.Damage = damage;
            this.Armor = armor;
        }
    }
}
