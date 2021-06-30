namespace AdventOfCode2015.Common
{
    using System;

    public class Gate
    {
        public Gate(BitwiseOperator op)
        {
            this.Operator = op;
        }

        public BitwiseOperator Operator { get; set; }

        public Func<Signal> SignalIn1 { get; set; }

        public Func<Signal> SignalIn2 { get; set; }

        public Signal SignalOut
        {
            get
            {
                switch (this.Operator)
                {
                    case BitwiseOperator.NOT:
                        return new Signal((ushort)~this.SignalIn1().Value);
                    case BitwiseOperator.AND:
                        return new Signal((ushort)(this.SignalIn1().Value & this.SignalIn2().Value));
                    case BitwiseOperator.OR:
                        return new Signal((ushort)(this.SignalIn1().Value | this.SignalIn2().Value));
                    case BitwiseOperator.LSHIFT:
                        return new Signal((ushort)(this.SignalIn1().Value << this.SignalIn2().Value));
                    case BitwiseOperator.RSHIFT:
                        return new Signal((ushort)(this.SignalIn1().Value >> this.SignalIn2().Value));
                    default:
                        return new Signal(0);
                }
            }
        }
    }
}
