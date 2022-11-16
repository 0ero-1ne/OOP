using System;

namespace LabFour
{
    class Program
    {
        static void Main()
        {
            try
            {
                Circle circleOne = null;
                UI container = new UI();
                container.AddElement(circleOne);
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
        }
    }
}
