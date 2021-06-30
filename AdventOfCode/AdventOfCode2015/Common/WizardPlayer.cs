namespace AdventOfCode2015.Common
{
    using System.Collections.Generic;

    public class WizardPlayer : Player
    {
        public WizardPlayer(int hitpoints, int mana) : base(hitpoints)
        {
            this.Mana = mana;
            this.fullMana = mana;
        }

        private readonly int fullMana;

        public int Mana { get; set; }

        public static List<Spell> Spells = new List<Spell>
                                               {
                                                   new Spell("Magic Missile", 53, 4, 0, 0, 0, 0),
                                                   new Spell("Drain", 73, 2, 0, 2, 0, 0),
                                                   new Spell("Shield", 113, 0, 7, 0, 0, 6),
                                                   new Spell("Poison", 173, 3, 0, 0, 0, 6),
                                                   new Spell("Recharge", 229, 0, 0, 0, 101, 5)
                                               };

        public override void Heal()
        {
            base.Heal();
            this.Mana = this.fullMana;
        }
    }
}
