namespace AdventOfCode2015.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day07 : IExercise
    {
        private List<Wire> wires;

        private const string Separator = "->";

        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var answer = new Answer { Part1 = this.SolvePart1(input) };

            answer.Part2 = this.SolvePart2((ushort)answer.Part1);

            return answer;
        }

        private object SolvePart1(string[] input)
        {
            this.wires = new List<Wire>();

            foreach (var connection in input)
            {
                this.ProcessConnection(connection);
            }

            var wireA = this.GetWire("a").Signal().Value;

            return wireA;
        }

        private object SolvePart2(ushort input)
        {
            this.GetWire("b").Signal = () => new Signal(input);

            foreach (var wire in this.wires)
            {
                wire.ResetSignal();
            }

            var wireA = this.GetWire("a").Signal().Value;

            return wireA;
        }

        private void ProcessConnection(string connection)
        {
            var separatorIndex = connection.IndexOf(Separator, StringComparison.InvariantCultureIgnoreCase);
            var source = connection.Substring(0, separatorIndex).TrimEnd();
            var destination = connection.Substring(separatorIndex + Separator.Length).TrimStart();
            var input = source.Split(' ');

            Func<Signal> signalIn = null;
            Gate gateIn = null;

            if (input.Length == 3)
            {
                BitwiseOperator op;
                if (!Enum.TryParse(input[1], out op))
                {
                    return;
                }

                gateIn = new Gate(op)
                {
                    SignalIn1 = this.GetConnection(input[0]),
                    SignalIn2 = this.GetConnection(input[2])
                };
            }
            else if (input.Length == 2)
            {
                BitwiseOperator op;
                if (!Enum.TryParse(input[0], out op))
                {
                    return;
                }

                gateIn = new Gate(op)
                {
                    SignalIn1 = this.GetConnection(input[1])
                };
            }
            else if (input.Length == 1)
            {
                signalIn = this.GetConnection(input[0]);
            }

            var output = this.GetWire(destination);
            output.Signal = gateIn != null ? () => gateIn.SignalOut : signalIn;
        }

        private Func<Signal> GetConnection(string value)
        {
            ushort ushortValue;
            if (ushort.TryParse(value, out ushortValue))
            {
                return () => new Signal(ushortValue);
            }

            var wire = this.GetWire(value);

            return () => wire.Signal();
        }

        private Wire GetWire(string id)
        {
            var wire = this.wires.SingleOrDefault(w => w.Id.Equals(id));
            if (wire == null)
            {
                wire = new Wire(id);
                this.wires.Add(wire);
            }

            return wire;
        }
    }
}
