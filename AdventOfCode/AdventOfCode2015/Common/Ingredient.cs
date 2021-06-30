namespace AdventOfCode2015.Common
{
    public class Ingredient
    {
        public Ingredient(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Durability { get; set; }

        public int Flavor { get; set; }

        public int Texture { get; set; }

        public int Calories { get; set; }
    }
}
