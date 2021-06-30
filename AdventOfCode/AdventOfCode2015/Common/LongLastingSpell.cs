namespace AdventOfCode2015.Common
{
    public class LongLastingSpell : Spell
    {
        public LongLastingSpell(Spell spell)
            : base(spell.Name, spell.Cost, spell.Damage, spell.Armor, spell.Leech, spell.Replenish, spell.Duration)
        {
            this.RemainingDuration = spell.Duration;
        }

        public LongLastingSpell(string name, int cost, int damage, int armor, int leech, int replenish, int duration)
            : base(name, cost, damage, armor, leech, replenish, duration)
        {
            this.RemainingDuration = duration;
        }

        public int RemainingDuration { get; set; }
    }
}
