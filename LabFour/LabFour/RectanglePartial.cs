namespace LabFour
{
    partial class Rectangle : GeometricFigure
    {
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
