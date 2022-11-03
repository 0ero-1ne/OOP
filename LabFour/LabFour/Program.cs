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
            GeometricFigure circleTwo = circleOne;
            GeometricFigure rectangleTwo = new Rectangle(10, 20);
            Console.WriteLine("IS operator: {0} - {1}", circleTwo is Circle, circleTwo is GeometricFigure);
            Console.WriteLine("IS operator with other types: {0} - {1}", circleTwo is Rectangle, circleTwo is IGeometricFigure);
            Console.WriteLine(circleOne.Radius);
            Console.WriteLine(circleOne is Circle);
            Console.WriteLine(geometric.Show());
            Console.WriteLine(geometric.Calculate(5, 6));
            Console.WriteLine(rectangleTwo.Name);

            Printer printer = new Printer();

            Radiobutton radio = new Radiobutton(true);
            IClickable radioTwo = new Radiobutton();

            object a = new Circle(25);
            Circle CircleFour = a as Circle;

            radio.Click();
            radioTwo.Click();

            GeometricFigure[] ArrayOfObjects = new GeometricFigure[3] {
                circleOne,
                rectangleOne,
                rectangleTwo
            };

            foreach (GeometricFigure figure in ArrayOfObjects)
            {
                Console.WriteLine(printer.IAmPrinting(figure) + "\n---");
            }
        }
    }
}
