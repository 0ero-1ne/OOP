using System;

namespace LabSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Circle circle = new Circle(10);
                Array<Circle> circleArray = new Array<Circle>();
                circleArray.AddElement(circle);
                circleArray.CopyToFile(circle);
                var circleTwo = circleArray.DeserializeObject();
                Console.WriteLine(circleTwo.ToString());
            }
            catch (ValueOutOfRange ex)
            {
                Console.WriteLine("Error message: " + ex.Message);
                Console.WriteLine("Error value: " + ex.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error message: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("End...");
            }
        }
    }
}
