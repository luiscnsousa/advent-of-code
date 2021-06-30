namespace AdventOfCode2015.Common
{
    public class CPU
    {
        public CPU()
        {
            this.RegisterA = new Register { Value = 0 };
            this.RegisterB = new Register { Value = 0 };
        }

        public CPU(uint registerA, uint registerB)
        {
            this.RegisterA = new Register { Value = registerA };
            this.RegisterB = new Register { Value = registerB };
        }

        public Register RegisterA { get; set; }

        public Register RegisterB { get; set; }

        public class Register
        {
            public uint Value { get; set; }
        }
    }
}
