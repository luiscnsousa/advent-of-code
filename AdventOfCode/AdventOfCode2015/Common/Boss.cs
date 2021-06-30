namespace AdventOfCode2015.Common
{
    public class Boss : Character
    {
        public Boss(int hitpoints, int damage, int armor) : base(hitpoints)
        {
            this.Damage = damage;
            this.Armor = armor;
        }

        public Boss(int hitpoints, int damage) : base(hitpoints)
        {
            this.Damage = damage;
            this.Armor = 0;
        }
    }
}
