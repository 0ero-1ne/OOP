using System;

namespace LabThree
{
    class Program
    {
        static void Main()
        {
            Array iArrayOne = new Array(6, 1, 2, 3, 4, 5, 6);
            Array iArrayTwo = new Array(6, 1, 2, 3, 4, 5, 6);
            Array.Developer developer = new Array.Developer();
            Console.WriteLine(StatisticOperation.Length(iArrayOne));
            iArrayTwo.PrintArray();
            Console.WriteLine(iArrayOne > 6);
            Console.WriteLine((iArrayOne == iArrayTwo) + "\n");
            Array iArrayThree = iArrayOne + iArrayTwo;
            iArrayThree.PrintArray();
            Console.WriteLine();
        }
    }
}
