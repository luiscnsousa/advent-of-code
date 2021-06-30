namespace AdventOfCode2015.Days
{
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day23 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            return new Answer { Part1 = this.SolvePart1(input), Part2 = this.SolvePart2(input) };
        }

        private object SolvePart1(string[] input)
        {
            var cpu = new CPU();
            this.RunInstructions(cpu, input);

            return cpu.RegisterB.Value;
        }

        private object SolvePart2(string[] input)
        {
            var cpu = new CPU(1, 0);
            this.RunInstructions(cpu, input);

            return cpu.RegisterB.Value;
        }

        private void RunInstructions(CPU cpu, string[] instructions)
        {
            var index = 0;
            while (index >=0 && index < instructions.Length)
            {
                var instruction = instructions[index].Split(' ');
                CPU.Register r;
                int offset;

                switch (instruction[0])
                {
                    case "hlf":
                        r = this.GetRegister(cpu, instruction[1]);
                        r.Value /= 2;
                        index++;
                        break;
                    case "tpl":
                        r = this.GetRegister(cpu, instruction[1]);
                        r.Value *= 3;
                        index++;
                        break;
                    case "inc":
                        r = this.GetRegister(cpu, instruction[1]);
                        r.Value++;
                        index++;
                        break;
                    case "jmp":
                        offset = int.Parse(instruction[1]);
                        index += offset;
                        break;
                    case "jie":
                        r = this.GetRegister(cpu, instruction[1].Remove(instruction[1].Length - 1));
                        if (r.Value % 2 == 0)
                        {
                            offset = int.Parse(instruction[2]);
                            index += offset;
                        }
                        else
                        {
                            index++;
                        }
                        break;
                    case "jio":
                        r = this.GetRegister(cpu, instruction[1].Remove(instruction[1].Length - 1));
                        if (r.Value == 1)
                        {
                            offset = int.Parse(instruction[2]);
                            index += offset;
                        }
                        else
                        {
                            index++;
                        }
                        break;
                }
            }
        }

        private CPU.Register GetRegister(CPU cpu, string register)
        {
            return (CPU.Register)cpu.GetType().GetProperty($"Register{register.ToUpper()}").GetValue(cpu);
        }
    }
}
