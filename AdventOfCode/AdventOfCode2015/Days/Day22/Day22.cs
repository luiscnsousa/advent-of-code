namespace AdventOfCode2015.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day22 : IExercise
    {
        private WizardPlayer player;

        private Boss boss;

        private Random randomizer;

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            this.ParseBoss(input);
            this.player = new WizardPlayer(50, 500);
            this.randomizer = new Random();

            return new Answer { Part1 = this.SolvePart1(), Part2 = this.SolvePart2() };
        }

        private object SolvePart1()
        {
            return this.Solve(false);
        }

        private object SolvePart2()
        {
            return this.Solve(true);
        }

        private object Solve(bool hardDifficulty)
        {
            var cost = int.MaxValue;
            var timer = new Timer { Interval = 60000 };
            timer.Elapsed += (sender, args) => timer.Stop();
            timer.Start();
            while (hardDifficulty ? cost == int.MaxValue : timer.Enabled)
            {
                var spells = this.Fight(hardDifficulty);
                if (spells == null)
                {
                    continue;
                }

                var manaCost = spells.Sum(g => g.Cost);
                if (manaCost < cost)
                {
                    timer.Stop();
                    cost = manaCost;
                    timer.Start();
                }
            }

            return cost == int.MaxValue ? string.Empty : cost.ToString();
        }

        private void ParseBoss(string[] input)
        {
            this.boss = new Boss(
                int.Parse(input[0].Split(' ').Last()),
                int.Parse(input[1].Split(' ').Last()));
        }

        private List<Spell> Fight(bool hardDifficulty)
        {
            this.player.Heal();
            this.boss.Heal();
            var isPlayerTurn = true;
            var spells = new List<Spell>();
            while (this.player.HitPoints > 0 && this.boss.HitPoints > 0)
            {
                if (hardDifficulty && isPlayerTurn)
                {
                    this.player.HitPoints--;
                    if (this.player.HitPoints <= 0)
                    {
                        break;
                    }
                }

                this.player.Armor = 0;

                foreach (var stackedSpell in spells.OfType<LongLastingSpell>().Where(s => s.RemainingDuration > 0))
                {
                    this.CastSpell(stackedSpell);
                    stackedSpell.RemainingDuration--;
                }

                if (isPlayerTurn)
                {
                    var availableSpells =
                        WizardPlayer.Spells.Where(
                            s =>
                            this.player.Mana >= s.Cost
                            && !spells.OfType<LongLastingSpell>()
                                    .Any(lls => lls.Name.Equals(s.Name) && lls.RemainingDuration > 0)).ToList();
                    if (!availableSpells.Any())
                    {
                        this.player.HitPoints = 0;
                        break;
                    }

                    var newSpell = this.GetNextSpell(availableSpells);
                    this.player.Mana -= newSpell.Cost;

                    if (newSpell.Duration == 0)
                    {
                        spells.Add(newSpell);
                        this.CastSpell(newSpell);
                    }
                    else
                    {
                        spells.Add(new LongLastingSpell(newSpell));
                    }
                }
                else
                {
                    var damageDealt = this.boss.Damage - this.player.Armor;
                    if (damageDealt < 1)
                    {
                        damageDealt = 1;
                    }

                    this.player.HitPoints -= damageDealt;
                }
                
                isPlayerTurn = !isPlayerTurn;
            }

            return this.boss.HitPoints <= 0 ? spells : null;
        }

        private Spell GetNextSpell(List<Spell> spells)
        {
            var index = this.randomizer.Next(spells.Count);
            return spells[index];
        }

        private void CastSpell(Spell spell)
        {
            if (spell.Damage > 0)
            {
                this.boss.HitPoints -= spell.Damage;
            }

            if (spell.Leech > 0)
            {
                this.player.HitPoints += spell.Leech;
            }

            if (spell.Armor > 0)
            {
                this.player.Armor += spell.Armor;
            }

            if (spell.Replenish > 0)
            {
                this.player.Mana += spell.Replenish;
            }
        }
    }
}
