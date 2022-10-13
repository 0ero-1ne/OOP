using System;

namespace LabThree
{
    class Program
    {
        static void Main()
        {
            Array iArrayOne = new Array(6, 1, 2, 3, 4, 5, 6);
            string str = "Hello, World!";
            Console.WriteLine(StatisticOperation.Length(iArrayOne));
            Array iArrayTwo = iArrayOne.RemoveFirstFiveElements();
            iArrayTwo.PrintArray();
        }
    }
}
