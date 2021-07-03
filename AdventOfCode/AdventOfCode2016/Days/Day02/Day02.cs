namespace AdventOfCode2016.Days
{
    using AdventOfCode2016.Common;
    using Infrastructure;

    public class Day02 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            return new Answer { Part1 = SolvePart1(input), Part2 = SolvePart2(input) };
        }

        private object SolvePart1(string[] input)
        {
            var keypad = new Keypad();

            foreach (var line in input)
            {
                keypad.PressNextKey(line);
            }
            
            return keypad.Code;
        }

        private object SolvePart2(string[] input)
        {
            var keypad = new Keypad(Keypad.KeypadType.Complex);

            foreach (var line in input)
            {
                keypad.PressNextKey(line);
            }
            
            return keypad.Code;
        }
    }
}