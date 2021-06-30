namespace AdventOfCode2015.Common
{
    using System.Collections.Generic;

    public static class Shop
    {
        public static List<Weapon> Weapons = new List<Weapon>
                                                 {
                                                     new Weapon("Dagger", 8, 4),
                                                     new Weapon("Shortsword", 10, 5),
                                                     new Weapon("Warhammer", 25, 6),
                                                     new Weapon("Longsword", 40, 7),
                                                     new Weapon("Greataxe", 74, 8)
                                                 };


        public static List<Armor> Armors = new List<Armor>
                                               {
                                                   new Armor("Leather", 13, 1),
                                                   new Armor("Chainmail", 31, 2),
                                                   new Armor("Splintmail", 53, 3),
                                                   new Armor("Bandedmail", 75, 4),
                                                   new Armor("Platemail", 102, 5)
                                               };


        public static List<Ring> Rings = new List<Ring>
                                             {
                                                 new Ring("Damage +1", 25, 1, 0),
                                                 new Ring("Damage +2", 50, 2, 0),
                                                 new Ring("Damage +3", 100, 3, 0),
                                                 new Ring("Defense +1", 20, 0, 1),
                                                 new Ring("Defense +2", 40, 0, 2),
                                                 new Ring("Defense +3", 80, 0, 3),
                                             };
    }
}
