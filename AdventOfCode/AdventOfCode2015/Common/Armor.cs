namespace AdventOfCode2015.Common
{
    public class Armor : Item
    {
        public Armor(string name, int cost, int armor) : base(name, cost)
        {
            this.Armor = armor;
        }
    }
}
