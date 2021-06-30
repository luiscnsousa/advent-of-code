namespace AdventOfCode2015.Common
{
    public abstract class Character
    {
        protected Character(int hitpoints)
        {
            this.fullHealth = hitpoints;
            this.HitPoints = hitpoints;
        }

        private readonly int fullHealth;

        public int HitPoints { get; set; }

        public int Damage { get; set; }

        public int Armor { get; set; }

        public virtual void Heal()
        {
            this.HitPoints = this.fullHealth;
        }
    }
}
