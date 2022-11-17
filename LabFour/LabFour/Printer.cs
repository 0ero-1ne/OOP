namespace LabFour
{
    class Printer
    {
        public Printer() { }

        public string IAmPrinting(GeometricFigure obj)
        {
            if (obj == null)
            {
                throw new NullObject("The object should not store a null value");
            }
            return obj.ToString();
        }
    }
}
