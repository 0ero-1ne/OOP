using System;

namespace LabFour
{
    class Program
    {
        static void Main()
        {
            Circle circleOne = new Circle(10);
            IGeometricFigure geometric = new Circle(25);
            Rectangle rectangleOne = new Rectangle(10, 10);
            GeometricFigure circleTwo = circleOne as GeometricFigure;
            GeometricFigure rectangleTwo = new Rectangle(10, 20);
            Console.WriteLine("{0} - {1}", circleTwo is Circle, circleTwo is GeometricFigure);
            IGeometricFigure circleThree = new Circle(30);
            Console.WriteLine(circleOne.Radius);
            Console.WriteLine(circleOne is Circle);
            Console.WriteLine(geometric.Show());
            Console.WriteLine(geometric.Calculate(5, 6));
            Printer printer = new Printer();
            Button button = new Button(true);
            Checkbox checkbox = new Checkbox(true);
            Radiobutton radio = new Radiobutton(true);
            object a = new Circle(25);
            Circle CircleFour = a as Circle;

            GeometricFigure[] ArrayOfObjects = new GeometricFigure[3] {
                circleOne,
                rectangleOne,
                rectangleTwo
            };

            foreach (GeometricFigure figure in ArrayOfObjects)
            {
                Console.WriteLine(printer.IAmPrinting(figure) + "\n---");
            }

            IClickable[] ArrayOfButtons = new IClickable[3]
            {
                button,
                checkbox,
                radio
            };

            foreach (IClickable figure in ArrayOfButtons)
            {
                Console.WriteLine(printer.IAmPrinting(figure) + "\n---");
            }
        }
    }
}
