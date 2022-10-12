using System;

namespace LabThree
{
    class Program
    {
        static void Main()
        {
            Array iArray = new Array(5, 1, 2, 3, 4, 5);
            iArray.RemoveElement(4);
            Console.WriteLine(iArray[0]);
        }
    }
}
