namespace AdventOfCode2015.Common
{
    using System.Collections.Generic;
    using System.Linq;

    public class Player : Character
    {
        public Player(int hitpoints) : base(hitpoints)
        {
            this.Gear = new List<Item>();
        }

        public List<Item> Gear { get; private set; }

        public void ApplyNewGear(List<Item> gear)
        {
            this.Gear = gear;
            this.Damage = this.Gear.Sum(g => g.Damage);
            this.Armor = this.Gear.Sum(g => g.Armor);
        }
    }
}
