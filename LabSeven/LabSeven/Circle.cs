using System;

namespace LabSeven
{
    class Circle
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

        public Circle() { }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return string.Format("Circle radius - {0}", Radius);
        }
    }
}
