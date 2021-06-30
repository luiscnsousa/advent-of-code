namespace AdventOfCode2015.Common
{
    public class Elf
    {
        public Elf(int number)
        {
            this.Number = number;
            this.CurrentHouse = number;
        }

        public int Number { get; private set; }

        public int CurrentHouse { get; set; }

        public int Presents => this.Number * 10;
    }
}
