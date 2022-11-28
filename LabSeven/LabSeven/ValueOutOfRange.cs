using System;

namespace LabSeven
{
    class ValueOutOfRange : Exception
    {
        public double Value { get; set; }
        public ValueOutOfRange(string message, double value) : base(message)
        {
            Value = value;
        }
    }
}
