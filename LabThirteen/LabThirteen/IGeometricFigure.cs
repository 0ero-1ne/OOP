namespace LabThirteen
{
    public interface IGeometricFigure
    {
        string Show();
        void Resize(double radius);
        void Resize(double length, double width);
        int Calculate(int a, int b);
    }
}
