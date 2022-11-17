using System.Diagnostics;

namespace LabFour
{
    partial class Rectangle : GeometricFigure
    {
        double length;
        public double Length
        {
            get => length;
            set
            {
                Debug.Assert(value > 0);
                length = value;
            }
        }
        double width;
        public double Width
        {
            get => width;
            set
            {
                if (value < 0)
                    throw new NegativeValue("Width of rectangle can not be negative", value);
                else
                    width = value;
            }
        }

        public Rectangle() : base("Rectangle") { }

        public Rectangle(double length) : base("Rectangle")
        {
            Length = length;
        }

        public Rectangle(double length, double width) : this(length)
        {
            Width = width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }

        public override double CalculateSquare()
        {
            return Length * Width;
        }

        public override string ToString()
        {
            return string.Format("Rectangle\tlength - {0} --- width - {1}", Length, Width);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Rectangle)) return false;

            return ToString() == obj.ToString();
        }
    }
}
