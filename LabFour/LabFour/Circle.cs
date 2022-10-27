using System;

namespace LabFour
{
    sealed class Circle : GeometricFigure
    {
        public double Radius { get; set; }

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
            return string.Format("Radius - {0}", Radius);
        }
    }
}
