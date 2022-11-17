using System;

namespace LabFour
{
    class NegativeValue : Exception
    {
        public double Value { get; set; }
        public NegativeValue(string message, double value) : base(message)
        {
            Value = value;
        }
    }
}
