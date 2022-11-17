using System;

namespace LabFour
{
    class Program
    {
        static void Main()
        {
            try
            {
                Circle circleOne = new Circle(-1);
                UI container = new UI();
                Rectangle rectangle = new Rectangle(10, 20);
                Console.WriteLine(rectangle.CalculateSquare());
                Controller controller = new Controller(container);
                Printer printer = new Printer();
                Console.WriteLine(printer.IAmPrinting(rectangle));
            }
            catch (ValueOutOfRange e)
            {
                Console.WriteLine("Error message: " + e.Message);
                Console.WriteLine("Error value: " + e.Value);
            }
            catch (NullObject e)
            {
                Console.WriteLine("Error message: " + e.Message);
            }
            catch (NegativeValue e)
            {
                Console.WriteLine("Error message: " + e.Message);
                Console.WriteLine("Error value: " + e.Value);
            }
            finally
            {
                Console.WriteLine("End of the program");
            }
        }
    }
}
