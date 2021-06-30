namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day21 : IExercise
    {
        private Player player;

        private Boss boss;

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            this.ParseBoss(input);
            this.player = new Player(100);
            var possibleGears = this.GetPossibleGears();

            return new Answer { Part1 = this.SolvePart1(possibleGears), Part2 = this.SolvePart2(possibleGears) };
        }

        private object SolvePart1(List<List<Item>> possibleGears)
        {
            var cost = int.MaxValue;
            foreach (var gear in possibleGears)
            {
                this.player.ApplyNewGear(gear);

                var gearCost = this.player.Gear.Sum(g => g.Cost);

                if (this.PlayerWins() && gearCost < cost)
                {
                    cost = gearCost;
                }
            }

            return cost;
        }

        private object SolvePart2(List<List<Item>> possibleGears)
        {
            var cost = int.MinValue;
            foreach (var gear in possibleGears)
            {
                this.player.ApplyNewGear(gear);

                var gearCost = this.player.Gear.Sum(g => g.Cost);

                if (!this.PlayerWins() && gearCost > cost)
                {
                    cost = gearCost;
                }
            }

            return cost;
        }

        private void ParseBoss(string[] input)
        {
            this.boss = new Boss(
                int.Parse(input[0].Split(' ').Last()),
                int.Parse(input[1].Split(' ').Last()),
                int.Parse(input[2].Split(' ').Last()));
        }

        private List<List<Item>> GetPossibleGears()
        {
            var possibleGears = new List<List<Item>>();
            foreach (var w in Shop.Weapons)
            {
                for (var i = 0; i <= Shop.Armors.Count; i++)
                {
                    var armor = i == Shop.Armors.Count ? null : Shop.Armors[i];
                    for (var j = -1; j < Shop.Rings.Count - 1; j++)
                    {
                        var r1 = j == -1 ? null : Shop.Rings[j];
                        for (var k = j + 1; k <= Shop.Rings.Count; k++)
                        {
                            var r2 = k == Shop.Rings.Count ? null : Shop.Rings[k];
                            
                            var gear = new List<Item> { w };
                            if (armor != null)
                            {
                                gear.Add(armor);
                            }

                            if (r1 != null)
                            {
                                gear.Add(r1);
                            }

                            if (r2 != null)
                            {
                                gear.Add(r2);
                            }

                            possibleGears.Add(gear);
                        }
                    }
                }
            }

            return possibleGears;
        } 

        private bool PlayerWins()
        {
            this.player.Heal();
            this.boss.Heal();
            var isPlayerTurn = true;
            while (this.player.HitPoints > 0 && this.boss.HitPoints > 0)
            {
                Character attacker;
                Character defender;
                if (isPlayerTurn)
                {
                    attacker = this.player;
                    defender = this.boss;
                }
                else
                {
                    attacker = this.boss;
                    defender = this.player;
                }

                var damageDealt = attacker.Damage - defender.Armor;
                if (damageDealt < 1)
                {
                    damageDealt = 1;
                }

                defender.HitPoints -= damageDealt;

                isPlayerTurn = !isPlayerTurn;
            }

            return this.player.HitPoints > 0;
        }
    }
}
