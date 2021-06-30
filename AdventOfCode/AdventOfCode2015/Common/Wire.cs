namespace AdventOfCode2015.Common
{
    using System;

    public class Wire
    {
        public Wire(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        private Signal currentSignal;

        private Func<Signal> signal;

        public Func<Signal> Signal
        {
            get
            {
                if (this.currentSignal == null)
                {
                    this.currentSignal = this.signal();
                }
                
                return () => this.currentSignal;
            }

            set
            {
                this.signal = value;
                this.currentSignal = null;
            }
        }

        public void ResetSignal()
        {
            this.currentSignal = null;
        }
    }
}
