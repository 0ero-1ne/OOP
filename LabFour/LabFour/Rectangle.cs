namespace LabFour
{
    class Rectangle : GeometricFigure
    {
        public double Length { get; set; }
        public double Width { get; set; }

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
            return string.Format("Length - {0}\nWidth - {1}", Length, Width);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Rectangle)) return false;

            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + 1;
        }

        public override void Resize(double length, double width)
        {
            Length = length;
            Width = width;
        }
    }
}
