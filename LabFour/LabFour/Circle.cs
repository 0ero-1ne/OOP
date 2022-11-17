using System;

namespace LabFour
{
    sealed class Circle : GeometricFigure
    {
        double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0 || value >= 150)
                {
                    throw new ValueOutOfRange("The radius must be over 0 and less then 150", value);
                }
                else
                {
                    radius = value;
                }
            }
        }

        public Circle() : base("Circle") { }

        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Resize(double radius)
        {
            Radius = radius;
        }

        public override int Calculate(int a, int b)
        {
            return a - b;
        }

        public override string ToString()
        {
            return string.Format("Circle\tradius - {0}", Radius);
        }
    }
}
