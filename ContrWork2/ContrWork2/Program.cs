using System;
using System.Linq;

namespace ContrWork2
{
    public delegate void Screams();

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SuperList<int> superList = new SuperList<int>(1, 2, 3, 4, 5);
                superList.FindElement(4);

                var strings = new[] { "Metal", "Jazz", "Pop", "Rock", "Nu Metal" };

                var resultStrings = from str in strings
                                    where str.StartsWith("M")
                                    where str.Length == 5
                                    select str;

                foreach (var element in resultStrings)
                {
                    Console.WriteLine(element);
                }

                Match match = new Match();
                Fan fan1 = new Fan();
                Fan fan2 = new Fan();

                Screams screams = new Screams(fan1.Scream);
                screams += fan2.Scream;

                match.Gol += screams;

                match.MakePoint();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
