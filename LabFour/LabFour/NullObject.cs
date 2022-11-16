using System;

namespace LabFour
{
    class NullObject : Exception
    {
        public NullObject(string message) : base(message) { }
    }
}
