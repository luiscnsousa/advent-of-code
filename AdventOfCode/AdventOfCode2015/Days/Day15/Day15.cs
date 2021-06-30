namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day15 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var ingredients = this.ParseIngredients(input);

            var combinations = new List<int[]>();

            this.MakeAllPossibleCombinations(combinations, new int[ingredients.Length], 0, 100);

            var scores = this.CalculateScores(ingredients, combinations);

            return new Answer { Part1 = this.SolvePart1(scores), Part2 = this.SolvePart2(ingredients, combinations, scores) };
        }

        private object SolvePart1(List<int> scores)
        {

            return scores.Max();
        }

        private object SolvePart2(Ingredient[] ingredients, List<int[]> combinations, List<int> scores)
        {
            var calories = new List<int>();
            foreach (var combination in combinations)
            {
                var ingredientsCalories = 0;
                for (var i = 0; i < combination.Length; i++)
                {
                    ingredientsCalories += combination[i] * ingredients[i].Calories;
                }

                calories.Add(ingredientsCalories);
            }

            var recipes500scores = new List<int>();
            for (var i = 0; i < calories.Count; i++)
            {
                if (calories[i] == 500)
                {
                    recipes500scores.Add(scores[i]);
                }
            }
            
            return recipes500scores.Max();
        }
        
        private Ingredient[] ParseIngredients(string[] input)
        {
            var ingredients = new Ingredient[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                var ingredient = input[i].Split(' ');
                ingredients[i] =
                    new Ingredient(ingredient[0].Substring(0, ingredient[0].Length - 1))
                        {
                            Capacity = int.Parse(ingredient[2].Substring(0, ingredient[2].Length - 1)),
                            Durability = int.Parse(ingredient[4].Substring(0, ingredient[4].Length - 1)),
                            Flavor = int.Parse(ingredient[6].Substring(0, ingredient[6].Length - 1)),
                            Texture = int.Parse(ingredient[8].Substring(0, ingredient[8].Length - 1)),
                            Calories = int.Parse(ingredient[10])
                        };
            }

            return ingredients;
        }

        private void MakeAllPossibleCombinations(List<int[]> combinations, int[] combination, int ingredientIndex, int remainingSpons)
        {
            if (ingredientIndex == combination.Length - 1)
            {
                combination[ingredientIndex] = remainingSpons;
                combinations.Add(combination.ToArray());
            }
            else
            {
                for (var i = remainingSpons; i >= 0; i--)
                {
                    combination[ingredientIndex] = i;
                    this.MakeAllPossibleCombinations(combinations, combination, ingredientIndex + 1, remainingSpons - i);
                }
            }
        }

        private List<int> CalculateScores(Ingredient[] ingredients, List<int[]> combinations)
        {
            var scores = new List<int>();
            var properties = new[] { "Capacity", "Durability", "Flavor", "Texture" };
            foreach (var combination in combinations)
            {
                var propertyScore = new int[properties.Length];
                for (var i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    propertyScore[i] = 0;
                    for (var j = 0; j < ingredients.Length; j++)
                    {
                        propertyScore[i] += combination[j]
                                         * (int)typeof(Ingredient).GetProperty(property).GetValue(ingredients[j]);
                    }

                    if (propertyScore[i] < 0)
                    {
                        propertyScore[i] = 0;
                    }
                }

                var recipeScore = propertyScore[0];
                for (var i = 1; i < propertyScore.Length; i++)
                {
                    recipeScore *= propertyScore[i];
                }

                scores.Add(recipeScore);
            }

            return scores;
        }
    }
}
