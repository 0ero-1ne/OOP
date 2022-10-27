namespace LabFour
{
    class Printer
    {
        public Printer() { }

        public string IAmPrinting(GeometricFigure obj)
        {
            return obj.ToString();
        }

        public string IAmPrinting(IClickable obj)
        {
            return obj.ToString();
        }
    }
}
