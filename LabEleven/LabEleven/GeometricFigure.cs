namespace LabEleven
{
    abstract class GeometricFigure : IGeometricFigure
    {
        public string Name { get; set; }

        public GeometricFigure()
        {
            Name = "Abstract figure";
        }

        public GeometricFigure(string name)
        {
            Name = name;
        }

        public virtual double CalculatePerimeter()
        {
            return 0;
        }

        public virtual double CalculateSquare()
        {
            return 0;
        }

        public string Show()
        {
            return Name;
        }

        public virtual void Resize(double radius) { }

        public virtual void Resize(double length, double width) { }

        public virtual int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}
